//using projectManagemaentEntity;
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
using Trello.UserControl;

namespace Trello.page
{
    /// <summary>
    /// Window_details.xaml 的互動邏輯
    /// </summary>
    public partial class Window_details : Window
    {

        ProjectManagementEntities DBContext = new ProjectManagementEntities();

        public static string TaskID { get; internal set; }
        public static UserControl_Card1 card { get; internal set; }

        public Window_details()
        {
            InitializeComponent();
            this.Topmost = true;
           
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            DBContext.SaveChanges();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            details_insertArea.Visibility = Visibility.Visible;
            details_insertTextbox.Visibility = Visibility.Visible;
            details_insertTextbox.Text = "請輸入任務名稱";
            textRow.Height = new GridLength(40);  
        }
      
        private void details_insertTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            var q = DBContext.TaskDetail.Where(x => x.TaskID == x.Tasks.TaskID);
            details_insertTextbox.Visibility = Visibility.Collapsed;
            CheckBox checkBox = new CheckBox();
            TextBox textBox = sender as TextBox;
            checkBox.Content = textBox.Text;
            checkBox.Checked += CheckBox_Checked;
            checkBox.Unchecked += CheckBox_Unchecked;
            TaskDetail taskDetails = new TaskDetail { TaskDetailName= textBox.Text, TaskID = card.TaskID, TaskDetailStatusID = 7 };
            details_insertContent.Visibility = Visibility.Visible;
            details_insertContent.Children.Add(checkBox);
            DBContext.TaskDetail.Add(taskDetails);
          

        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            
            var q = DBContext.TaskDetail.Where(x => x.TaskID == x.Tasks.TaskID);
            q.First().TaskDetailStatusID = 7;
            DBContext.SaveChanges();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            var q = DBContext.TaskDetail.Where(x=>x.TaskID==x.Tasks.TaskID);
            q.First().TaskDetailStatusID = 9;
            DBContext.SaveChanges();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();

        }

      
    }
}
