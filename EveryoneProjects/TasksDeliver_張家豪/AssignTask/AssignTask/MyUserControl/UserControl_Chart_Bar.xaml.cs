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

namespace AssignTask
{
    /// <summary>
    /// UserControl_Chart_Bar.xaml 的互動邏輯
    /// </summary>
    public partial class UserControl_Chart_Bar : UserControl
    {
        public UserControl_Chart_Bar()
        {
            InitializeComponent();
        }

        private string my_EmployeeID;
        public int us_EmployeeID
        {
            get;
            set;
        }
    }

     
    public class MyChartItem
    {
        public MyChartItem(string name, int taskCount)
        {
            this.Name = name;
            this.Task = taskCount;
        }
        public string Name
        {
            get;
            set;
        }
        public int Task
        {
            get;
            set;
        }
    }

    public class ChartCollection : Collection<MyChartItem>
    {
        ProjectManagementEntities DbContext = new ProjectManagementEntities();       
        public ChartCollection()
        {
            var q = from p in this.DbContext.Tasks
                    where p.EmployeeID !=null
                    group p by p.Employee.EmployeeName into g
                    select new { Name = g.Key, count = g.Count(), MyGroup = g };
            foreach (var item in q.ToList())
            {
                Add(new MyChartItem(item.Name, item.count));
            }
        }
    }
}
