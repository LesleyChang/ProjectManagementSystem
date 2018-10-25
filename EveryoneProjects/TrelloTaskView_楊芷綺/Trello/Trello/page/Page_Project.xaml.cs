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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Trello._UserControl;
using Trello.page;
using Trello.UserControl;
using Wpf_LoginSystem;

namespace Trello.page
{
    /// <summary>
    /// Page_Project.xaml 的互動邏輯
    /// </summary>
    public partial class Page_Project : Page
    {
        public Page_Project()
        {
            InitializeComponent();
        }
        public string ProjectID { get; internal set; }//為了在pageboard面取得mainwindow的label
        public Label win_projectName { get; internal set; }//為了在pageboard面取得mainwindow的label
        public static string TaskID { get; private set; }
        UserControl_Project project;
        ProjectManagementEntities DBContext = new ProjectManagementEntities();
        //撈專案
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            wpContent.Children.Clear();
           var q = DBContext.Project;
                    
            int Count = q.Count();
            foreach (var a in q)
            {
                project = new UserControl_Project();
                project.Width = 130;
                project.Height = 80;
                project.Margin = new Thickness(50, 10, 8, 10);
                project.projectName.Content = $"{a.ProjectName}";
                project.projectID = a.ProjectID;
                wpContent.Children.Add(project);
                project.MouseLeftButtonDown += Project_MouseLeftButtonDown;
            }
        }
        //選擇專案
        Page_board selectBoard;
        string selected_projectName;
        private void Project_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            selected_projectName = ((UserControl_Project)sender).projectName.Content.ToString();
            UserControl_Project project = sender as UserControl_Project;
            win_projectName.Content = $"{"專案名稱"} : {project.projectName.Content}";
            ProjectID = ((UserControl_Project)sender).projectID;
            var q = from x in DBContext.Project
                    select x;
            foreach (var a in q)
            {
                if (selectBoard == null && ((UserControl_Project)sender).projectName.Content.ToString() == a.ProjectName)
                {
                    selectBoard = new Page_board();
                    UserControl_Card1.selectBoard = selectBoard;
                    UserControl_Board.selectBoard = selectBoard;
                    TrelloPage.selectBoard = selectBoard;
                    selectBoard.Loaded += selectBoardLoad;
                }
                Project_ContentControl.Content = new Frame()
                {
                    Content = selectBoard
                };
            }
        }
        //撈 board.card 資料
        internal static int _originalCount;
        internal static int _originalCount1;
        internal static int _originalCount2;
        public void selectBoardLoad(object load, RoutedEventArgs e_load)
        {
            var q = DBContext.Status.Where(n => n.StatusCategoryID == "Tasks");
            foreach (var y in q)
            {
                UserControl_Board board = new UserControl_Board();
                board.C_spContent.Tag= y.StatusID;
              
                selectBoard.B_spContent.Children.Add(board);
                board.B_title.Content = y.StatusName;
                selectBoard.board = board;
                UserControl_Card1.Board = board;
                foreach (var b in y.Tasks.Where(n => n.Works.ProjectID == ProjectID))
                {
                    UserControl_Card1 card = new UserControl_Card1();
                    board.card = card;
                    card.TaskID = b.TaskID;
                    Window_details.TaskID = b.TaskID.ToString();
                    card.TaskStatusID = (int)b.TaskStatusID;
                    card.TaskStatusIDChanged = b.TaskStatusIDChanged.ToString();
                    Page_Project.TaskID = b.TaskID.ToString();
                    card.card_workName.Content = b.TaskName;
                    card.card_dueDate.Content = b.EndDate.ToString();
                    card.card_assignedName.Content = b.Employee.EmployeeName;
                    card.Margin = new Thickness(0,0,15,0);
                    selectBoard.board.C_spContent.Children.Add(card);
                    if (card.TaskStatusID==9)
                    {
                        card.card_checkBox.Visibility = Visibility.Collapsed;
                        TranslateTransform translateTransform1 = new TranslateTransform(-100, 0);
                        card.card_workName.RenderTransform = translateTransform1;
                    } 
                } 
            }
            _originalCount = ((UserControl_Board)selectBoard.B_spContent.Children[0]).C_spContent.Children.Count;
            _originalCount1 = ((UserControl_Board)selectBoard.B_spContent.Children[1]).C_spContent.Children.Count;
            _originalCount2 = ((UserControl_Board)selectBoard.B_spContent.Children[2]).C_spContent.Children.Count;
            ((UserControl_Board)selectBoard.B_spContent.Children[0]).board_TaskCount.Content = $"{_originalCount}";
            ((UserControl_Board)selectBoard.B_spContent.Children[1]).board_TaskCount.Content = $"{_originalCount1}";
            ((UserControl_Board)selectBoard.B_spContent.Children[2]).board_TaskCount.Content = $"{_originalCount2}";
            TrelloPage.selectBoardLoad = this;    
        }
        public int originalCount
        {
            get => _originalCount;
            set => _originalCount = value;
        }
        public int originalCount1
        {
            get => _originalCount1;
            set => _originalCount1 = value;
        }
        public int originalCount2
        {
            get => _originalCount2;
            set => _originalCount2 = value;
        }
    }
}
