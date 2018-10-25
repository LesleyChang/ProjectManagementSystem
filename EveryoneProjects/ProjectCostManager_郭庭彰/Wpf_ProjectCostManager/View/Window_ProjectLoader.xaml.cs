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
    /// Window_ProjectLoader.xaml 的互動邏輯
    /// </summary>
    public partial class Window_ProjectLoader : Window
    {
        public Window_ProjectLoader()
        {
            InitializeComponent();
        }

        public string ProjectID { get; set; }
        public string ProjectName { get; set; }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ProjectManagementEntities dbContext = new ProjectManagementEntities();
            System.Windows.Data.CollectionViewSource projectViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("projectViewSource")));
            // 透過設定 CollectionViewSource.Source 屬性載入資料: 
            projectViewSource.Source = dbContext.Project.ToList();
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var p = this.projectDataGrid.SelectedValue as Project;
            ProjectID = p.ProjectID;
            ProjectName = p.ProjectName;
            DialogResult = true;
        }
    }
}
