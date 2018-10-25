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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Trello.page;

namespace Trello.UserControl
{
    /// <summary>
    /// UserControl_Board.xaml 的互動邏輯
    /// </summary>
    public partial class UserControl_Board : System.Windows.Controls.UserControl
    {
        public UserControl_Board()
        {
            InitializeComponent();
           
        }
        ProjectManagementEntities DBContext = new ProjectManagementEntities();
        public static Page_board selectBoard { get; internal set; }
        public UserControl_Card1 card { get; internal set; }
       
        private void panel_DragOver(object sender, System.Windows.DragEventArgs e)
        {
            if (e.Data.GetDataPresent("Object"))
            {
                e.Effects = DragDropEffects.Move;

            }
        }
        private void panel_Drop(object sender, DragEventArgs e)
        {

            if (e.Handled == false)
            {
                StackPanel _panel = (StackPanel)sender;
                UIElement _element = (UIElement)e.Data.GetData("Object");

                if (_panel != null && _element != null)
                {
                    Panel _parent = (Panel)VisualTreeHelper.GetParent(_element);
                    if (_parent != null)
                    {
                        e.AllowedEffects.HasFlag(DragDropEffects.Move);
                        UserControl_Card1 _card = (UserControl_Card1)_element;
                        var q = DBContext.Tasks.Where(x => _card.TaskID == x.TaskID);
                        ((UserControl_Board)selectBoard.B_spContent.Children[0]).C_spContent.Children.Remove(_element);
                        ((UserControl_Board)selectBoard.B_spContent.Children[1]).C_spContent.Children.Remove(_element);
                        ((UserControl_Board)selectBoard.B_spContent.Children[2]).C_spContent.Children.Remove(_element);
                        _panel.Children.Insert(0, _element);
                        e.Effects = DragDropEffects.Move;
                        q.First().TaskStatusID = int.Parse(_panel.Tag.ToString());
                        DBContext.SaveChanges();
                        TaskCount();
                    }
                }
            }
        }
        public void TaskCount()
        {
            ((UserControl_Board)selectBoard.B_spContent.Children[0]).board_TaskCount.Content = ((UserControl_Board)selectBoard.B_spContent.Children[0]).C_spContent.Children.Count;
            ((UserControl_Board)selectBoard.B_spContent.Children[1]).board_TaskCount.Content = ((UserControl_Board)selectBoard.B_spContent.Children[1]).C_spContent.Children.Count;
            ((UserControl_Board)selectBoard.B_spContent.Children[2]).board_TaskCount.Content = ((UserControl_Board)selectBoard.B_spContent.Children[2]).C_spContent.Children.Count;
        }


    }
}
