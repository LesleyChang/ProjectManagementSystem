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
//using PMEntityModel;

namespace Wpf_ProjectCostManager.View
{
    /// <summary>
    /// Window_CategoryAdder.xaml 的互動邏輯
    /// </summary>
    public partial class Window_CategoryAdder : Window
    {
        public Window_CategoryAdder()
        {
            InitializeComponent();
        }

        ProjectManagementEntities dbContext = new ProjectManagementEntities();

        private void Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void OK(object sender, RoutedEventArgs e)
        {
            if(this.tb_CatName.Text != "")
            {
                dbContext.ResourceCategory.Add(new ResourceCategory { CategoryName = this.tb_CatName.Text });
                try
                {
                    dbContext.SaveChanges();
                    DialogResult = true;
                    MessageBox.Show("新增成功!");
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }
            }
            else
            {
                MessageBox.Show("請輸入費用類別名稱");
            }
        }
    }
}
