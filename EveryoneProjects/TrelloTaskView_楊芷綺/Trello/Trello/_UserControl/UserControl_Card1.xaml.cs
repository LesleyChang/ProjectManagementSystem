//using projectManagemaentEntity;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Trello.page;
using System.Windows.Threading;
using System.Threading;
using System.Diagnostics;
using ProjectManagementModel;

namespace Trello.UserControl
{
    /// <summary>
    /// UserControl_Card1.xaml 的互動邏輯
    /// </summary>
    public partial class UserControl_Card1 : System.Windows.Controls.UserControl
    {
        public UserControl_Card1()
        {
            InitializeComponent();
        }
        public UserControl_Card1(UserControl_Card1 c)
        {
            InitializeComponent();
            this.unsercontrol_cardName.Height = c.unsercontrol_cardName.Height;
            this.unsercontrol_cardName.Width = c.unsercontrol_cardName.Width;
        }
        public int TaskID { get; internal set; }
        public static UserControl_Board Board { get; internal set; }
        public static Page_board selectBoard { get; internal set; }
        public int TaskStatusID { get; internal set; }
        public string TaskStatusIDChanged { get; internal set; }
        public static TrelloPage MainWindow { get; internal set; }
        ProjectManagementEntities DBContext = new ProjectManagementEntities();
        Page_Project a = new Page_Project();
       
        private void card_checkBox_Checked_1(object sender, System.Windows.RoutedEventArgs e)
        {
            var q = DBContext.Tasks.Where(x => x.TaskID == card.TaskID).FirstOrDefault();
            q.TaskStatusID = 9;

            if (card.TaskStatusID==7)
            {

                ((UserControl_Board)selectBoard.B_spContent.Children[0]).C_spContent.Children.Remove(card);
                ((UserControl_Board)selectBoard.B_spContent.Children[1]).C_spContent.Children.Remove(card);
                ((UserControl_Board)selectBoard.B_spContent.Children[2]).C_spContent.Children.Remove(card);
                q.TaskStatusIDChanged = 7;
                DBContext.SaveChanges();

            }
            else if (card.TaskStatusID== 8)
            {
                ((UserControl_Board)selectBoard.B_spContent.Children[0]).C_spContent.Children.Remove(card);
                ((UserControl_Board)selectBoard.B_spContent.Children[1]).C_spContent.Children.Remove(card);
                ((UserControl_Board)selectBoard.B_spContent.Children[2]).C_spContent.Children.Remove(card);
                q.TaskStatusIDChanged = 8;
                DBContext.SaveChanges();
            }
            else
            {
                ((UserControl_Board)selectBoard.B_spContent.Children[0]).C_spContent.Children.Remove(card);
                ((UserControl_Board)selectBoard.B_spContent.Children[1]).C_spContent.Children.Remove(card);
                ((UserControl_Board)selectBoard.B_spContent.Children[2]).C_spContent.Children.Remove(card);
                ((UserControl_Board)selectBoard.B_spContent.Children[2]).C_spContent.Children.Remove(card);
            }
            ((UserControl_Board)selectBoard.B_spContent.Children[2]).C_spContent.Children.Insert(0, card);
            ((CheckBox)sender).IsChecked = true;
            TaskCount();
        }
        
        private void card_checkBox_Unchecked_1(object sender, System.Windows.RoutedEventArgs e)
        {
            var q = DBContext.Tasks.Where(x => x.TaskID == card.TaskID).FirstOrDefault();
            q.TaskStatusID = q.TaskStatusIDChanged;
            DBContext.SaveChanges();
            if (card.TaskStatusID==7)
            {
                ((UserControl_Board)selectBoard.B_spContent.Children[0]).C_spContent.Children.Remove(card);
                ((UserControl_Board)selectBoard.B_spContent.Children[1]).C_spContent.Children.Remove(card);
                ((UserControl_Board)selectBoard.B_spContent.Children[2]).C_spContent.Children.Remove(card);
                ((UserControl_Board)selectBoard.B_spContent.Children[0]).C_spContent.Children.Insert(0, card);
            }
            else if (card.TaskStatusID==8)
            {
                ((UserControl_Board)selectBoard.B_spContent.Children[0]).C_spContent.Children.Remove(card);
                ((UserControl_Board)selectBoard.B_spContent.Children[1]).C_spContent.Children.Remove(card);
                ((UserControl_Board)selectBoard.B_spContent.Children[2]).C_spContent.Children.Remove(card);
                ((UserControl_Board)selectBoard.B_spContent.Children[1]).C_spContent.Children.Insert(0, card);
            }
            else
            {
                ((UserControl_Board)selectBoard.B_spContent.Children[0]).C_spContent.Children.Remove(card);
                ((UserControl_Board)selectBoard.B_spContent.Children[1]).C_spContent.Children.Remove(card);
                ((UserControl_Board)selectBoard.B_spContent.Children[2]).C_spContent.Children.Remove(card);
                ((UserControl_Board)selectBoard.B_spContent.Children[2]).C_spContent.Children.Insert(0, card);
            }
            TaskCount();
        }
        public void TaskCount()
        {
            ((UserControl_Board)selectBoard.B_spContent.Children[0]).board_TaskCount.Content = ((UserControl_Board)selectBoard.B_spContent.Children[0]).C_spContent.Children.Count;
            ((UserControl_Board)selectBoard.B_spContent.Children[1]).board_TaskCount.Content = ((UserControl_Board)selectBoard.B_spContent.Children[1]).C_spContent.Children.Count;
            ((UserControl_Board)selectBoard.B_spContent.Children[2]).board_TaskCount.Content = ((UserControl_Board)selectBoard.B_spContent.Children[2]).C_spContent.Children.Count;
        }
        Window_details page_details = null;
        private void three_dots_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            LoadDetailsContent();
            page_details.ShowDialog();
            page_details.Closing += Page_details_Closing;
        }

        private void Page_details_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DBContext.SaveChanges();
        }

        private void LoadDetailsContent()
        {
            DBContext = new ProjectManagementEntities();
            List<string> comboBoxContent = new List<string>();
            var q1 = DBContext.Status.Where(x => x.StatusCategoryID == "Tasks");
            foreach (var a in q1)
            {
                comboBoxContent.Add(a.StatusName);
            }

            var q = DBContext.Tasks.Where(x => x.TaskID ==TaskID).Select(x => x);
            page_details = new Window_details();
            Window_details.card = card;
            foreach (var x in q)
            {
                page_details.details_taskName.Content = x.TaskName;
                page_details.details_endDate.Content = x.TaskName;
                page_details.details_assigned.Content = x.Employee.EmployeeName;
                page_details.details_desc.Text = x.Description;
                page_details.derails_comboBox.ItemsSource = comboBoxContent;
                foreach (var y in q.First().TaskDetail.Where(s => s.TaskID == s.Tasks.TaskID))
                {
                    CheckBox taskDetailsItem = new CheckBox();
                    taskDetailsItem.Content = y.TaskDetailName;
                    page_details.details_insertContent.Children.Add(taskDetailsItem);

                }
            }
            if (card.TaskStatusID==9)
            {
                page_details.details_insertBtn.Content = "不要按我";

            }
        }
        
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DataObject data = new DataObject();
                data.SetData("Double", unsercontrol_cardName.Height);
                data.SetData("Object", this);
                DragDrop.DoDragDrop(this, data, DragDropEffects.Copy | DragDropEffects.Move);
            }
        }
        UserControl_Card1 card;
        private void UserControl_MouseEnter(object sender, MouseEventArgs e)
        {
            card = sender as UserControl_Card1;
        }
    }
}
