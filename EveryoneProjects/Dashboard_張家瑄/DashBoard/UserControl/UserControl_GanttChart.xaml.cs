using Braincase.GanttChart;
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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DashBoard
{
    /// <summary>
    /// UserControl_MyGanttChart.xaml 的互動邏輯
    /// </summary>
    public partial class UserControl_MyGanttChart : System.Windows.Controls.UserControl
    {
        public UserControl_MyGanttChart()
        {
            InitializeComponent();
            InitializeGanttHost();
            ProjectsComboBox.SelectedIndex = 0;
            TimeViewComboBox.SelectedIndex = 1;
        }

        public void InitializeGanttHost()
        {
            _Chart = new Braincase.GanttChart.Chart();
            this._Chart.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Chart.Font = new System.Drawing.Font("Microsoft JhengHei UI", 8F);
            this._Chart.Location = new System.Drawing.Point(0, 0);
            this._Chart.Margin = new System.Windows.Forms.Padding(0);
            this._Chart.Name = "_Chart";
            this._Chart.Size = new System.Drawing.Size(671, 496);
            this._Chart.TabIndex = 0;
            this._Chart.TimeResolution = Braincase.GanttChart.TimeResolution.Day;

            Project1 = new ProjectManager() { Start = new DateTime(2018,11,1)};
            var task1 = new MyTask(Project1) { Name = "Project 1" };
            var task2 = new MyTask(Project1) { Name = "Task 1" };
            var task3 = new MyTask(Project1) { Name = "Task 2" };
            var task4 = new MyTask(Project1) { Name = "Task 3" };
            var task5 = new MyTask(Project1) { Name = "Task 4" };
            var task6 = new MyTask(Project1) { Name = "Task 5" };
            var task7 = new MyTask(Project1) { Name = "Task 6" };
            Project1.Add(task1);
            Project1.Add(task2);
            Project1.Add(task3);
            Project1.Add(task4);
            Project1.Add(task5);
            Project1.Add(task6);
            Project1.Add(task7);
            Project1.SetDuration(task1, TimeSpan.FromDays(3));
            Project1.SetDuration(task2, TimeSpan.FromDays(5));
            Project1.SetDuration(task3, TimeSpan.FromDays(7));
            Project1.SetDuration(task4, TimeSpan.FromDays(4));
            Project1.SetDuration(task5, TimeSpan.FromDays(3));
            Project1.SetDuration(task6, TimeSpan.FromDays(5));
            Project1.Group(task1, task2);
            Project1.Group(task1, task3);
            Project1.Group(task1, task4);
            Project1.Group(task1, task5);
            Project1.Group(task1, task6);
            Project1.Group(task1, task7);
            Project1.Relate(task2, task3);
            Project1.Relate(task2, task4);
            Project1.Relate(task4, task5);
            Project1.Relate(task4, task6);
            Project1.Relate(task6, task7);
            Project1.Relate(task5, task7);

            var span = DateTime.Today - Project1.Start;
            Project1.Now = span;
            Projects.Add(Project1);

             Project1 = new ProjectManager() { Start = new DateTime(2018, 11, 16) };
             task1 = new MyTask(Project1) { Name = "Project 2" };
             task2 = new MyTask(Project1) { Name = "Task 1" };
             task3 = new MyTask(Project1) { Name = "Task 2" };
             task4 = new MyTask(Project1) { Name = "Task 3" };
             task5 = new MyTask(Project1) { Name = "Task 4" };
             task6 = new MyTask(Project1) { Name = "Task 5" };
             task7 = new MyTask(Project1) { Name = "Task 6" };
            Project1.Add(task1);
            Project1.Add(task2);
            Project1.Add(task3);
            Project1.Add(task4);
            Project1.Add(task5);
            Project1.Add(task6);
            Project1.Add(task7);
            Project1.SetDuration(task7, TimeSpan.FromDays(4));
            Project1.SetDuration(task2, TimeSpan.FromDays(5));
            Project1.SetDuration(task3, TimeSpan.FromDays(12));
            Project1.SetDuration(task4, TimeSpan.FromDays(6));
            Project1.SetDuration(task5, TimeSpan.FromDays(3));
            Project1.SetDuration(task6, TimeSpan.FromDays(8));
            Project1.Group(task1, task2);
            Project1.Group(task1, task3);
            Project1.Group(task1, task4);
            Project1.Group(task1, task5);
            Project1.Group(task1, task6);
            Project1.Group(task1, task7);
            Project1.Relate(task2, task3);
            Project1.Relate(task2, task4);
            Project1.Relate(task2, task5);
            Project1.Relate(task4, task6);
            Project1.Relate(task3, task7);
            Project1.Relate(task5, task7);

            span = DateTime.Today - Project1.Start;
            Project1.Now = span;
            Projects.Add(Project1);

            Project1 = new ProjectManager() { Start = new DateTime(2018, 10, 26) };
            task1 = new MyTask(Project1) { Name = "Project 3" };
            task2 = new MyTask(Project1) { Name = "Task 1" };
            task3 = new MyTask(Project1) { Name = "Task 2" };
            task4 = new MyTask(Project1) { Name = "Task 3" };
            task5 = new MyTask(Project1) { Name = "Task 4" };
            task6 = new MyTask(Project1) { Name = "Task 5" };
            task7 = new MyTask(Project1) { Name = "Task 6" };
            var task8 = new MyTask(Project1) { Name = "Task 7" };
            Project1.Add(task1);
            Project1.Add(task2);
            Project1.Add(task3);
            Project1.Add(task4);
            Project1.Add(task5);
            Project1.Add(task6);
            Project1.Add(task7);
            Project1.Add(task8);            
            Project1.SetDuration(task2, TimeSpan.FromDays(5));
            Project1.SetDuration(task3, TimeSpan.FromDays(12));
            Project1.SetDuration(task4, TimeSpan.FromDays(6));
            Project1.SetDuration(task5, TimeSpan.FromDays(3));
            Project1.SetDuration(task6, TimeSpan.FromDays(8));
            Project1.SetDuration(task7, TimeSpan.FromDays(12));
            Project1.SetDuration(task8, TimeSpan.FromDays(18));
            Project1.Group(task1, task2);
            Project1.Group(task1, task3);
            Project1.Group(task1, task4);
            Project1.Group(task1, task5);
            Project1.Group(task1, task6);
            Project1.Group(task1, task7);
            Project1.Relate(task2, task4);
            Project1.Relate(task2, task6);
            Project1.Relate(task2, task5);
            Project1.Relate(task4, task6);
            Project1.Relate(task3, task7);
            Project1.Relate(task5, task8);

            span = DateTime.Today - Project1.Start;
            Project1.Now = span;
            Projects.Add(Project1);


            //_Chart.Init(Project1);

            //_Chart.CreateTaskDelegate = delegate () { return new MyTask(Project1); };
            this.GanttHost.Child = _Chart;
            TimeViewComboBox.ItemsSource = typeof(TimeResolution).GetEnumNames();
            TimeViewComboBox.SelectedIndex = 1;
            
            foreach (var p in Projects.ToList())
            {                
                ProjectNames.Add(p.Tasks.FirstOrDefault());
            }
            ProjectsComboBox.ItemsSource = ProjectNames.ToList();
            
        }



        public Chart _Chart;
        public ProjectManager Project1;
        public ObservableCollection<ProjectManager> Projects = new ObservableCollection<ProjectManager>();
        public ObservableCollection<Braincase.GanttChart.Task> ProjectNames = new ObservableCollection<Braincase.GanttChart.Task>();
        private void TimeViewComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           var item = TimeViewComboBox.SelectedItem;
            if (item == null) return;
            switch (((TimeResolution)Enum.Parse(typeof(TimeResolution), item.ToString())))
            {
                case TimeResolution.Day:
                    this._Chart.TimeResolution = TimeResolution.Day;
                    _Chart.Invalidate();
                    GanttHost.InvalidateVisual();
                    break;                
                case TimeResolution.Week:
                    this._Chart.TimeResolution = TimeResolution.Week;
                    _Chart.Invalidate();
                    GanttHost.InvalidateVisual();
                    break;
            }
        }

        private void ProjectsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (var p in Projects)
            {
                Braincase.GanttChart.Task _task = p.Tasks.FirstOrDefault();
                if(_task == ((Braincase.GanttChart.Task)ProjectsComboBox.SelectedItem))
                {
                    _Chart.Init(p);
                    _Chart.Invalidate();
                    GanttHost.InvalidateVisual();
                    return;
                }
            }
           
        }
    }
    public class MyTask : Braincase.GanttChart.Task
    {
        public MyTask(ProjectManager manager)
            : base()
        {
            Manager = manager;
        }

        private ProjectManager Manager { get; set; }

        public new TimeSpan Start { get { return base.Start; } set { Manager.SetStart(this, value); } }
        public new TimeSpan End { get { return base.End; } set { Manager.SetEnd(this, value); } }
        public new TimeSpan Duration { get { return base.Duration; } set { Manager.SetDuration(this, value); } }
        public new float Complete { get { return base.Complete; } set { Manager.SetComplete(this, value); } }
    }
    public class ProjectsCollection
    {
        public ProjectsCollection()
        {
            Items = new ObservableCollection<ProjectManager>();
        }
        public ObservableCollection<ProjectManager> Items;
    }
}
