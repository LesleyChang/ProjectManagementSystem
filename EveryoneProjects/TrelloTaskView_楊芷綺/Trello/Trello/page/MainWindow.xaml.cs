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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Trello.page;
using Trello.UserControl;

namespace Trello
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class TrelloPage : Window
    {
        ProjectManagementEntities DBContext = new ProjectManagementEntities();
        public TrelloPage()
        {
            InitializeComponent();
            UserControl_Card1.MainWindow = this;
            ShowTreeView();
        }
 
        public class propertyNodeItem
        {
            public string ProjectName { get; set; }
            public string DisplayName { get; set; }
            public string Name { get; set; }
            public List<propertyNodeItem> Children { get; set; }
            public propertyNodeItem()
            {
                Children = new List<propertyNodeItem>();
            }
        }
        private void ShowTreeView()
        {
            List<propertyNodeItem> listItem = new List<propertyNodeItem>();
            propertyNodeItem mainNode = new propertyNodeItem()
            {
                DisplayName = "DashBoard",
            };
            propertyNodeItem subNode_B = new propertyNodeItem()
            {
                DisplayName = "Board",
            };
            propertyNodeItem subNode_T = new propertyNodeItem()
            {
                DisplayName = "My Task",
            };
            mainNode.Children.Add(subNode_B);
            mainNode.Children.Add(subNode_T);
            listItem.Add(mainNode);
            this.menu.ItemsSource = listItem; 
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ShowTreeView();
           
        }
        //視窗換頁
        Page_Project selectProject;

        public static Window_details Page_details { get; internal set; }
        public static Page_board selectBoard { get; internal set; }
        public static Page_Project selectBoardLoad { get; internal set; }

        private void TextBlock_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            if (((TextBlock)sender).Text == "DashBoard")
            {
                selectProject = new Page_Project();
                selectProject.win_projectName = this.win_projectName;//為了在pageboard面取得mainwindow的label
                win_projectName.Content = "";

                Win_ContentControl.Content = new Frame()
                {
                    Content = selectProject
                };
            }
        }
        private void Window_Closed(object sender, EventArgs e)
        {
            if (Page_details != null)
            {
                Page_details.Close();
            }
        }
        private void Win_ContentControl_Unloaded(object sender, RoutedEventArgs e)
        {
            //if (sender == null) return;
           // selectBoardLoad.selectBoardLoad(sender, e);
        }
    }
}
