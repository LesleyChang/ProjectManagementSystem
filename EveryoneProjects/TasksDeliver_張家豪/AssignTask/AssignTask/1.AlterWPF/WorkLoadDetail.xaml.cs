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

namespace AssignTask._1.AlterWPF
{
    /// <summary>
    /// WorkLoadDetail.xaml 的互動邏輯
    /// </summary>
    public partial class WorkLoadDetail : Window
    {
        public WorkLoadDetail()
        {
            InitializeComponent();
            FillGridInformation();
            FillGrid_CountInformation();
            FillChartBarInformation();
        }

        public string queryList //Todo Get projectPM
        {
            get;
            set;
        }


        ProjectManagementEntities dBContext = new ProjectManagementEntities();
        private void FillGrid_CountInformation()
        {
            try
            {
                var q = from p in this.dBContext.Tasks.AsEnumerable()
                        where p.EmployeeID != null
                        group p by p.Employee.EmployeeName into g
                        select new { Name = g.Key, count = g.Count(), MyGroup = g };

                foreach (var item in q.ToList())
                {
                    this.groupdatagrid.Items.Add(new MyItem { EmPCount = item.count, EmployeeName = item.Name });
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
       
        private void FillGridInformation()
        {
            var q = from p in this.dBContext.Tasks
                    where p.EmployeeID != null
                    select p;
            foreach (var item in q.ToList())
            {
                detailGrid1.Items.Add(new MyItem
                {
                    EmployeeName = item.Employee.EmployeeName,
                    Task = item.TaskName,
                    StartDate = item.StartDate,
                    EndDate = item.EndDate,
                    ProjectName = item.Works.Project.ProjectName,
                });
            }
        }

        private void FillChartBarInformation()
        {
            UserControl_Chart_Bar workloadbar = new UserControl_Chart_Bar { Width = 790, Height = 200, Margin = new Thickness(10)};
            this.detailWrap1.Children.Add(workloadbar);
        }
    }
}
