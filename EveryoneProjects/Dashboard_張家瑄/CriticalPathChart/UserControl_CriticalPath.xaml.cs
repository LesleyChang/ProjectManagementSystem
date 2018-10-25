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
using System.Windows.Shapes;

namespace CriticalPathChart
{
    /// <summary>
    /// UserControl_CriticalPath.xaml 的互動邏輯
    /// </summary>
    public partial class UserControl_CriticalPath : UserControl
    {
        public UserControl_CriticalPath()
        {
            InitializeComponent();
            
        }

        public void DrawTaskItems()
        {
            foreach (var tasks in ProjectSelected.TasksCollection)
            {
                foreach (var item in tasks.Items)
                {
                    UserControl_TaskItem taskItem = new UserControl_TaskItem(); 
                    taskItem.NameBlock.Text = item.Name;
                    taskItem.DurationBlock.Text = item.Duration.ToString();
                    this.MainCanvas.Children.Add(taskItem);
                    Canvas.SetLeft(taskItem, item.CanvasLeft);
                    Canvas.SetTop(taskItem, item.CanvasTop);
                }
            }
            
        }
        
        /// <summary>
        /// data in TasksFromDB.Items would be Sorted and add to TasksCollection
        /// </summary>
        public Project ProjectSelected { get; set; }

        public Tasks TasksFromDB = new Tasks();

        public List<Tasks> TasksCollection { get; set; }
        public int GridWidths { get; set; }

        //private void CPM_Window_ContentRendered(object sender, EventArgs e)
        //{
            
        //    ProjectSelected.StartPoint = new Point( StartBlock.TranslatePoint(new Point(0, 0), this.MainCanvas).X  + this.StartBlock.ActualWidth,
        //                                            StartBlock.TranslatePoint(new Point(0, 0), this.MainCanvas).Y + (this.StartBlock.ActualHeight / 2));
        //    ProjectSelected.EndPoint = new Point(EndBlock.TranslatePoint(new Point(0, 0), this.MainCanvas).X,
        //                                         EndBlock.TranslatePoint(new Point(0, 0), this.MainCanvas).Y + (this.EndBlock.ActualHeight / 2));
                
        //    ProjectSelected.GeneratePathLines();
        //    foreach (var line in ProjectSelected.PathLines)
        //    {
        //        this.MainCanvas.Children.Add(line);
        //    }
        //}
    }
}
