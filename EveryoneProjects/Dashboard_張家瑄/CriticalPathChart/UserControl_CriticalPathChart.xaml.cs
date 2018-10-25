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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CriticalPathChart
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class UserControl_CriticalPathChart : UserControl
    {
        public UserControl_CriticalPathChart()
        {
            InitializeComponent();

            Task task1 = new Task() { Name = "task 1", Duration = 10 };
            Task task2 = new Task() { Name = "task 2", Duration = 17 };
            Task task3 = new Task() { Name = "task 3", Duration = 14, Predecessors = new List<Task>() { task1 } };
            Task task4 = new Task() { Name = "task 4", Duration = 15, Predecessors = new List<Task>() { task1, task2 } };
            Task task5 = new Task() { Name = "task 5", Duration = 3, Predecessors = new List<Task>() { task3 } };
            Task task6 = new Task() { Name = "task 6", Duration = 14, Predecessors = new List<Task>() { task3, task4 } };
            Task task7 = new Task() { Name = "task 7", Duration = 6, Predecessors = new List<Task>() { task5 } };
            Task task8 = new Task() { Name = "task 8", Duration = 8, Predecessors = new List<Task>() { task1 } };
            TasksFromDB.Items.Add(task1);
            TasksFromDB.Items.Add(task2);
            TasksFromDB.Items.Add(task3);
            TasksFromDB.Items.Add(task4);
            TasksFromDB.Items.Add(task5);
            TasksFromDB.Items.Add(task6);
            TasksFromDB.Items.Add(task7);
            TasksFromDB.Items.Add(task8);
            Project1 = new Project(TasksFromDB) { Name = "Project1" };

            TasksFromDB = new Tasks();
             task1 = new Task() { Name = "task 1", Duration = 12 };
             task2 = new Task() { Name = "task 2", Duration = 7 };
             task3 = new Task() { Name = "task 3", Duration = 14, Predecessors = new List<Task>() { task1 } };
             task4 = new Task() { Name = "task 4", Duration = 15, Predecessors = new List<Task>() { task2 } };
             task5 = new Task() { Name = "task 5", Duration = 8, Predecessors = new List<Task>() { task3 } };
             task7 = new Task() { Name = "task 7", Duration = 16, Predecessors = new List<Task>() { task3, task4 } };
             task8 = new Task() { Name = "task 8", Duration = 3, Predecessors = new List<Task>() { task1 } };
            TasksFromDB.Items.Add(task1);
            TasksFromDB.Items.Add(task2);
            TasksFromDB.Items.Add(task3);
            TasksFromDB.Items.Add(task4);
            TasksFromDB.Items.Add(task5);
            TasksFromDB.Items.Add(task7);
            TasksFromDB.Items.Add(task8);
            Project2 = new Project(TasksFromDB) { Name = "Project2"};

            TasksFromDB = new Tasks();
            task1 = new Task() { Name = "task 1", Duration = 20 };
            task2 = new Task() { Name = "task 2", Duration = 17 };
            task3 = new Task() { Name = "task 3", Duration = 14, Predecessors = new List<Task>() { task1 } };
            task4 = new Task() { Name = "task 4", Duration = 15, Predecessors = new List<Task>() { task1, task2 } };
            task5 = new Task() { Name = "task 5", Duration = 13, Predecessors = new List<Task>() { task3 } };
            task6 = new Task() { Name = "task 6", Duration = 16, Predecessors = new List<Task>() { task5 } };
            task7 = new Task() { Name = "task 7", Duration = 13, Predecessors = new List<Task>() { task1 } };
            Task task9 = new Task() { Name = "task 9", Duration = 6, Predecessors = new List<Task>() { task5 } };
            TasksFromDB.Items.Add(task1);
            TasksFromDB.Items.Add(task2);
            TasksFromDB.Items.Add(task3);
            TasksFromDB.Items.Add(task4);
            TasksFromDB.Items.Add(task5);
            TasksFromDB.Items.Add(task6);
            TasksFromDB.Items.Add(task7);
            Project3 = new Project(TasksFromDB) { Name = "Project3" };

            projectsViewModel.ProjectItems.Add(Project1);
            projectsViewModel.ProjectItems.Add(Project2);
            projectsViewModel.ProjectItems.Add(Project3);
            this.DataContext = projectsViewModel;
            //ProjectsComboBox.SelectedIndex = 0;
        }

        Project Project1;
        Project Project2;
        Project Project3;
        public Tasks TasksFromDB = new Tasks();
        ProjectsViewModel projectsViewModel = new ProjectsViewModel();

        public void ProjectsComboBoxSelect()
        {
            ProjectsComboBox.SelectedIndex = 0;
        }
        private void ProjectsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // CPM_Chart = new UserControl_CriticalPath();
            ResetMainCanvas();
            CPM_Chart.ProjectSelected = ProjectsComboBox.SelectedItem as Project;
            CPM_Chart.DrawTaskItems();
            DrawPathLines();
        }

        private void ResetMainCanvas()
        {
            foreach (var item in CPM_Chart.MainCanvas.Children)
            {
                if(item is Line)
                {
                    ((Line)item).Visibility = Visibility.Collapsed;
                }
                else if(item is UserControl_TaskItem)
                {
                    ((UserControl_TaskItem)item).Visibility = Visibility.Collapsed;
                }
            }
        }

        private void DrawPathLines()
        {
            CPM_Chart.ProjectSelected.StartPoint = new Point(CPM_Chart.StartBlock.TranslatePoint(new Point(0, 0), this.CPM_Chart.MainCanvas).X + this.CPM_Chart.StartBlock.ActualWidth,
                                                    CPM_Chart.StartBlock.TranslatePoint(new Point(0, 0), this.CPM_Chart.MainCanvas).Y + (this.CPM_Chart.StartBlock.ActualHeight / 2));
            CPM_Chart.ProjectSelected.EndPoint = new Point(CPM_Chart.EndBlock.TranslatePoint(new Point(0, 0), this.CPM_Chart.MainCanvas).X,
                                                  CPM_Chart.EndBlock.TranslatePoint(new Point(0, 0), this.CPM_Chart.MainCanvas).Y + (this.CPM_Chart.EndBlock.ActualHeight / 2));

            CPM_Chart.ProjectSelected.GeneratePathLines();
            foreach (var line in CPM_Chart.ProjectSelected.PathLines)
            {
                CPM_Chart.MainCanvas.Children.Add(line);
            }
        }
    }
}
