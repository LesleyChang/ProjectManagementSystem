//using PMEntityModel;
using ProjectManagementModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wpf_ProjectCostManager.View;
using Wpf_ProjectCostManager.ViewModel;

namespace Wpf_ProjectCostManager
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class ProjectCostManagerPage : Window
    {
        public ProjectCostManagerPage()
        {
            InitializeComponent();

            List<Project> projects = dbContext.Project.ToList();

            foreach (var i in projects)
            {
                UC_Project P = new UC_Project();
                P.ProjectID = i.ProjectID;
                P.ProjectName = i.ProjectName;

                if (((DateTime)i.EndDate).Ticks - ((DateTime)i.StartDate).Ticks == 0)
                {
                    P.progressBar.Value = 100;
                }
                else
                {
                    P.progressBar.Value = Convert.ToDouble((DateTime.Now.Ticks - ((DateTime)i.StartDate).Ticks)) / Convert.ToDouble((((DateTime)i.EndDate).Ticks - ((DateTime)i.StartDate).Ticks)) * 100;
                }
                P.Height = 165;
                P.Width = 158;
                P.Tag = i;
                P.Margin = new Thickness(5);
                P.Click += OpenProject;
                this.wrapPanel.Children.Add(P);
            }
        }

        private void OpenProject(object sender, MouseEventArgs e)
        {
            UC_Project p = sender as UC_Project;
            Project project = p.Tag as Project;
            Window_ProjectDetails w = new Window_ProjectDetails();

            string DeptName = dbContext.Department.Where(x => x.DepartmentID == project.RequiredDeptID).Select(x => x.DepartmentName).Single();

            w.ProjectID = project.ProjectID;
            w.ProjectName = project.ProjectName;
            w.ProgressByTasks = p.progressBar.Value;
            w.RequiredDepartment = DeptName;
            if(project.Budget != null)
            {
                w.TotalCost = (double)project.Budget;
            }
            else
            {
                w.TotalCost = 0;
            }
            w.Show();
        }

        ProjectManagementEntities dbContext = new ProjectManagementEntities();
        ObservableCollection<DisplayResource> MyProjects;
        CollectionViewSource taskResourceViewSource;

        private void Add(object sender, RoutedEventArgs e)
        {
            string ProjectID = this.tb_ProjectID.Text;
            if (dbContext.Project.Where(p => p.ProjectID == ProjectID).ToList().Count != 0)
            {
                Window_ExpenseAdder w = new Window_ExpenseAdder();
                w.ProjectID = this.tb_ProjectID.Text;
                w.Show();
            }
            else
            {
                MessageBox.Show("請輸入正確的專案代號!");
            }
        }

        private void Search(object sender, RoutedEventArgs e)
        {
            string ProjectID = this.tb_ProjectID.Text;
            if (dbContext.Project.Where(p => p.ProjectID == ProjectID).ToList().Count != 0)
            {
                taskResourceViewSource = this.Resources["taskResourceViewSource"] as CollectionViewSource;

                var q2 = from c in dbContext.ResourceCategory
                         select c.CategoryName;
                this.resourceNameColumn.ItemsSource = q2.ToList();

                var q = from p in dbContext.Project
                        join w in dbContext.Works on p.ProjectID equals w.ProjectID
                        join t in dbContext.Tasks on w.WorkID equals t.WorkID
                        join tr in dbContext.TaskResource on t.TaskID equals tr.TaskID
                        join c in dbContext.ResourceCategory on tr.CategoryID equals c.CategoryID
                        where p.ProjectID == this.tb_ProjectID.Text
                        select new DisplayResource { ResourceID = tr.ResourceID, ResourceName = tr.ResourceName, CategoryName = c.CategoryName, Quantity = tr.Quantity, Unit = tr.Unit, UnitPrice = tr.UnitPrice, SubTotal = (tr.UnitPrice * tr.Quantity), Date = DateTime.Now, Description = tr.Description };

                MyProjects = new ObservableCollection<DisplayResource>();

                foreach (var i in q.ToList())
                {
                    MyProjects.Add(i);
                }
                // 透過設定 CollectionViewSource.Source 屬性載入資料: 
                taskResourceViewSource.Source = MyProjects;
                this.taskResourceDataGrid.IsReadOnly = true;
            }
            else
            {
                MessageBox.Show("請輸入正確的專案代號!");
            }
        }

        private void Modify(object sender, RoutedEventArgs e)
        {
            this.taskResourceDataGrid.IsReadOnly = false;
        }

        private void Remove(object sender, RoutedEventArgs e)
        {
            if (this.taskResourceDataGrid.IsReadOnly == false)
            {
                DisplayResource dr = this.taskResourceDataGrid.SelectedItem as DisplayResource;
                var q = from p in dbContext.TaskResource
                        where p.ResourceID == dr.ResourceID
                        select p;
                if (q.ToList().FirstOrDefault() != null)
                {
                    dbContext.TaskResource.Remove(q.ToList().FirstOrDefault());
                }
                this.MyProjects.Remove(dr);
            }
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            this.taskResourceDataGrid.IsReadOnly = true;

            foreach (var g in this.taskResourceDataGrid.Items)
            {
                DisplayResource i = g as DisplayResource;

                var q = from p in dbContext.TaskResource
                        where p.ResourceID == i.ResourceID
                        select p;
                if (q.ToList().FirstOrDefault() != null)
                {
                    foreach (var tr in q.ToList())
                    {
                        int CatID = (from c in dbContext.ResourceCategory
                                     where c.CategoryName == i.CategoryName
                                     select c.CategoryID).Single();

                        tr.CategoryID = CatID;
                        tr.Date = i.Date;
                        tr.Description = i.Description;
                        tr.Quantity = i.Quantity;
                        tr.ResourceName = i.ResourceName;
                        tr.Unit = i.Unit;
                        tr.UnitPrice = i.UnitPrice;
                    }
                }
            }


            try
            {
                dbContext.SaveChanges();
                MessageBox.Show("存檔成功!");
            }
            catch (Exception)
            {

            }
        }

        private void LoadProject(object sender, RoutedEventArgs e)
        {
            Window_ProjectLoader w = new Window_ProjectLoader();
            if ((bool)w.ShowDialog())
            {
                this.tb_ProjectID.Text = w.ProjectID;
                this.tb_ProjectName.Text = w.ProjectName;
            }
        }

        private void tb_ProjectID_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (this.tb_ProjectID.Text != "")
            {
                this.btn_add.IsEnabled = true;
                this.btn_search.IsEnabled = true;
            }
        }

        private void Reverse(object sender, RoutedEventArgs e)
        {
            Search(sender, e);
        }
    }
}
