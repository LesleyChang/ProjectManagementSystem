using ProjectManagementModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AssignTask
{
    /// <summary>
    /// EmployeeDetail.xaml 的互動邏輯
    /// </summary>
    public partial class EmployeeDetail : Window
    {
        public EmployeeDetail()
        {
            InitializeComponent();
            
        }

        private string m_usEmployeeName;

        public string usEmployeeName
        {
            get
            {
                return m_usEmployeeName;
            }
            set
            {
                m_usEmployeeName = value; 
                this.FillDetailData(m_usEmployeeName);               
            }
        }

        ProjectManagementEntities DbContext = new ProjectManagementEntities();
        private void FillDetailData(string m_usEmployeeName)
        {
            var q = from p in this.DbContext.Tasks
                    where p.Employee.EmployeeName == m_usEmployeeName && p.EmployeeID!=null
                    select p;
            foreach (var item in q.ToList())
            {
                this.grid1.Items.Add(new MyItem { Task = item.TaskName, Work = item.Works.WorkName, TaskStatus = item.Works.Status.StatusName, EstWorkTime = item.EstWorkTime.ToString()});
            }
            FillBarData(m_usEmployeeName);
        }
        private void FillBarData(string m_usEmployeeName)
        {
            //1.假設某人接了A案子TaskA預計WorkTime為16小時，B案子TaskB預計WorkTime為8小時
            //2.假設 Task A & B都要一周內完成
            //3.以一周工時來計算40小時
            var q2 = this.DbContext.Tasks.Where(p => p.Employee.EmployeeName == m_usEmployeeName).Sum(p => p.EstWorkTime);
                     
            this.workloadBar1.Value = 0;        
            this.workloadBar1.Maximum = 40;
            if (q2 == null) q2 = 0;

            this.worktimeSumLabel1.Content = q2 +" Hours";

            try
            {
                this.workloadBar1.Value = (int)q2;

                double p = (double)q2 / 40.0;

                if (q2> this.workloadBar1.Maximum)
                {                    
                    this.workloadBar1.Value = (int)q2 - (int)this.workloadBar1.Maximum;
                    //p = this.workloadBar1.Value / 40;
                    this.workloadBar1.Foreground = new SolidColorBrush(Colors.Orange);
                    if (q2 >= 80)
                    {
                        this.workloadBar1.Foreground = new SolidColorBrush(Colors.Red);
                    }
                    MessageBox.Show(m_usEmployeeName + "目前承接工作至少需要兩個禮拜才能完成", "注意!"+m_usEmployeeName+"快被操死了", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                    decimal myValue = (decimal)p;
                    NumberFormatInfo percentageFormat = new NumberFormatInfo { PercentPositivePattern = 1, PercentNegativePattern = 1 };
                    this.barValueLabel.Content = myValue.ToString("P0", percentageFormat);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
