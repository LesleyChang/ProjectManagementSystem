//using PMEntityModel;
using ProjectManagementModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Wpf_ProjectCostManager.MyUserControls;

namespace Wpf_ProjectCostManager.View
{
    /// <summary>
    /// Window_AddRxpense.xaml 的互動邏輯
    /// </summary>
    public partial class Window_ExpenseAdder : Window
    {
        public Window_ExpenseAdder()
        {
            InitializeComponent();

            var q = dbContext.ResourceCategory.Select(p => p.CategoryName);
            CatNames = q.ToList();

            this.Resource1.Add += Add;
            this.Resource1.Remove += Remove;
            this.Resource1.QuantityChanged += QuantityChanged;
            this.Resource1.UnitPriceChanged += UnitPriceChanged;
            this.Resource1.SubTotalChanged += SubTotalChanged;
        }

        ProjectManagementEntities dbContext = new ProjectManagementEntities();
        List<string> CatNames;
        List<ProjectManagementModel.Tasks> Tasks;

        private string m_ProjectID;
        internal string ProjectID
        {
            set
            {
                m_ProjectID = value;
                var q = from p in dbContext.Project
                        from w in p.Works
                        from t in w.Tasks
                        where p.ProjectID == value
                        select t;
                Tasks = q.ToList();
            }
        }

        private void Resource1_Loaded(object sender, RoutedEventArgs e)
        {
            this.Resource1.Date = DateTime.Now;
            foreach (var i in CatNames)
            {
                this.Resource1.Categories.Add(i);
            }
            foreach (var t in Tasks)
            {
                this.Resource1.Tag = t.TaskID;
                this.Resource1.TaskNames.Add(t.TaskName);
            }
        }
        private void Add(object sender, RoutedEventArgs e)
        {
            UC_Resource resource = new UC_Resource();
            resource.Date = DateTime.Now;
            foreach (var i in CatNames)
            {
                resource.Categories.Add(i);
            }
            foreach (var t in Tasks)
            {
                resource.Tag = t.TaskID;
                resource.TaskNames.Add(t.TaskName);
            }
            resource.Add += Add;
            resource.Remove += Remove;
            resource.QuantityChanged += QuantityChanged;
            resource.UnitPriceChanged += UnitPriceChanged;
            resource.SubTotalChanged += SubTotalChanged;
            resource.Margin = new Thickness(0, 5, 0, 0);

            this.sp_Resources.Children.Add(resource);
        }
        private void Remove(object sender, RoutedEventArgs e)
        {
            UC_Resource resource = sender as UC_Resource;
            if (resource != this.Resource1)
            {
                this.sp_Resources.Children.Remove(resource);
            }
        }
        private void SubTotalChanged(object sender, TextChangedEventArgs e)
        {
            UC_Resource r = sender as UC_Resource;
            if (r.Quantity != 0)
            {
                r.UnitPrice = r.SubTotal / r.Quantity;
            }
        }
        private void UnitPriceChanged(object sender, TextChangedEventArgs e)
        {
            UC_Resource r = sender as UC_Resource;
            if (r.Quantity != 0)
            {
                r.SubTotal = r.Quantity * r.UnitPrice;
            }
        }
        private void QuantityChanged(object sender, TextChangedEventArgs e)
        {
            UC_Resource r = sender as UC_Resource;
            if (r.UnitPrice != 0)
            {
                r.SubTotal = r.Quantity * r.UnitPrice;
            }
        }
        private void SetDate(object sender, RoutedEventArgs e)
        {
            foreach (UC_Resource i in this.sp_Resources.Children)
            {
                i.Date = Resource1.Date;
            }
        }
        private void AddCategory(object sender, RoutedEventArgs e)
        {
            Window w = new Window_CategoryAdder();
            w.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            if ((bool)w.ShowDialog())
            {
                var q = dbContext.ResourceCategory.Select(p => p.CategoryName);
                CatNames = q.ToList();
                foreach (UC_Resource i in this.sp_Resources.Children)
                {
                    i.Categories.Clear();
                    foreach (string s in CatNames)
                    {
                        i.Categories.Add(s);
                    }
                }
            }
        }
        private void Save(object sender, RoutedEventArgs e)
        {
            foreach (UC_Resource i in this.sp_Resources.Children)
            {
                if (i.Date != null && i.ResourceName != null && i.Quantity != 0 && i.Unit != null && i.UnitPrice != 0 && i.SelectedCategory != null)
                {
                    var q = dbContext.ResourceCategory.Where(p => p.CategoryName == i.SelectedCategory).Select(p => p.CategoryID);
                    int ID = q.ToList().Single();
                    dbContext.TaskResource.Add(new TaskResource { TaskID = (int)i.Tag, Date = i.Date, ResourceName = i.ResourceName, CategoryID = ID, Quantity = i.Quantity, Unit = i.Unit, UnitPrice = i.UnitPrice });
                    try
                    {
                        dbContext.SaveChanges();
                        MessageBox.Show("新增成功!");
                    }
                    catch (Exception exp)
                    {

                        MessageBox.Show(exp.Message);
                    }
                }
                else
                {
                    MessageBox.Show("請確認所有欄位均已填妥");
                }
            }
        }
        private void Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
