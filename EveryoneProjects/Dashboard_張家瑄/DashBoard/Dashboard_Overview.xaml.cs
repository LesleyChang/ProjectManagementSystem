using CriticalPathChart;
using ProjectManagementModel;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace DashBoard
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class OverviewDashboardPage : Window
    {
        public OverviewDashboardPage(int employeeID)
        {
            this.EmployeeID = employeeID;
            InitializeComponent();
            InitializeSettingMenu();
            InitializeAnchorRectangles();
            AddUserControlWidgets();
            InitializeExtraSettingPage();

        }
        private void Window_ContentRendered(object sender, EventArgs e)
        {           
            //AddUserControlWidgets();
            //InitializeExtraSettingPage();
        }

        //ProjectManagementEntities dbContext = new ProjectManagementEntities();
        public DashboardWidgets WidgetsViewModel;
        UserControl_ToolBox _ToolBox;
        UserControl_ControlSetting _ControlSetting;
        List<Point> AnchorPoints;
        double FirstXPos, FirstYPos;
        object MovingObject;
        object ResizingObject;
        ContextMenu SettingMenu;
        public enum SettingMenuItem { 刪除, 設計 }
        public enum WidgetType { UserControl_DateBlock, UserControl_BurnDownChart }
        public int EmployeeID { get; set; }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
           // UpdateToDatabase();
        }

        public void UpdateToDatabase()
        {
            if (WidgetsViewModel != null)
            {
                WidgetsViewModel.Items.Clear();
                foreach (var item in MainCanvas.Children)
                {
                    if (item is Rectangle)
                        continue;
                    if (item is UserControl)
                    {
                        UserControl control = item as UserControl;
                        WidgetsViewModel.Items.Add(
                            new Widget()
                            {
                                WidgetID = transFormControlToWidget(control.ToString()),
                                WidgetHeight = (int)control.RenderSize.Height,
                                WidgetWidth = (int)control.RenderSize.Width,
                                CanvasLeft = (int)Canvas.GetLeft(control),
                                CanvasTop = (int)Canvas.GetTop(control)
                            });
                    }
                }                
            }

            WidgetsViewModel.LoadBackToDB(WidgetsViewModel.Items);

        }
        private int transFormControlToWidget(string controlName)
        {
            if (controlName.ToString().Contains("DateBlock")) return 1;
            else if (controlName.ToString().Contains("BurnDownChart")) return 2;
            else if (controlName.ToString().Contains("Gantt")) return 3;
            else return 4;
        }
        private void SettingMenu_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MenuItem SelectedItem = e.Source as MenuItem;
            if (SelectedItem == null) return;
            switch ((SettingMenuItem)Enum.Parse(typeof(SettingMenuItem),SelectedItem.Header.ToString()))
            {
                case SettingMenuItem.刪除:
                    var p = ((ContextMenu)sender).PlacementTarget as UserControl;
                    this.MainCanvas.Children.Remove(p);
                    break;
                case SettingMenuItem.設計:
                    ResizingObject = ((ContextMenu)sender).PlacementTarget;
                    _ControlSetting.ControlSize = ((UserControl)((ContextMenu)sender).PlacementTarget).RenderSize;
                    _ControlSetting.InvalidateVisual();
                    _ControlSetting.Visibility = Visibility.Visible;                    
                    break;
                default:
                    break;
            }

        }
        private void AddUserControlWidgets()
        {            
            WidgetsViewModel = new DashboardWidgets(EmployeeID);            
            foreach (var item in WidgetsViewModel.Items)
            {
                var newControl = new UserControl();

                if (item.WidgetName.Contains("DateBlock"))
                {
                    newControl = new UserControl_DateBlock();
                }
                else if (item.WidgetName.Contains("BurnDownChart"))
                {
                    newControl = new UserControl_BurnDownChart();                    
                }
                else if (item.WidgetName.Contains("CriticalPathChart"))
                {
                    newControl = new UserControl_CriticalPathChart();
                }
                else if (item.WidgetName.Contains("GanttChart"))
                {
                    newControl = new UserControl_MyGanttChart();                    
                }

                newControl.Width = item.WidgetWidth;
                newControl.Height = item.WidgetHeight;
                this.MainCanvas.Children.Add(newControl);
                
                Canvas.SetLeft(newControl, item.CanvasLeft);
                Canvas.SetTop(newControl, item.CanvasTop);
                newControl.ContextMenu = SettingMenu;

            }
            foreach (var item in MainCanvas.Children)
            {
                Control control = item as Control;
                if (control == null) continue;
                control.ContextMenu = SettingMenu;
            }
            
        }

        #region Drag_Drop methods
        private void AllowDragDropControls()
        {
            foreach (var item in MainCanvas.Children)
            {
                Rectangle anchorRect = item as Rectangle;
                if (anchorRect == null) continue;
                anchorRect.Visibility = Visibility.Visible;
            }
            foreach (var item in MainCanvas.Children)
            {
                Control control = item as Control;
                if (control == null) continue;
                control.PreviewMouseLeftButtonDown += this.MouseLeftButtonDown;
                control.PreviewMouseLeftButtonUp += this.PreviewMouseLeftButtonUp;
                control.Cursor = Cursors.Hand;
            }
            MainCanvas.PreviewMouseMove += this.MouseMove;
        }
        private void NotAllowGragDropControls()
        {
            foreach (var item in MainCanvas.Children)
            {
                Rectangle anchorRect = item as Rectangle;
                if (anchorRect == null) continue;
                anchorRect.Visibility = Visibility.Hidden;
            }
            foreach (var item in MainCanvas.Children)
            {
                Control control = item as Control;
                if (control == null) continue;
                control.PreviewMouseLeftButtonDown -= this.MouseLeftButtonDown;
                control.PreviewMouseLeftButtonUp -= this.PreviewMouseLeftButtonUp;                
                control.Cursor = Cursors.Arrow;
            }
            MainCanvas.PreviewMouseMove -= this.MouseMove;
        }
        private void MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MovingObject = sender;
            Control movingControl = sender as Control;
            if (movingControl == null  ) return;
            if (!movingControl.ToString().Contains("Gantt"))
            {
                movingControl.RenderTransformOrigin = new Point(0, 0);
                movingControl.LayoutTransform = new RotateTransform(8);
            }

            FirstXPos = e.GetPosition(sender as Control).X;
            FirstYPos = e.GetPosition(sender as Control).Y;

        }
        private void PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Control movingControl = MovingObject as Control;
            if (movingControl == null) return;
            movingControl.RenderTransformOrigin = new Point(0, 0);
            movingControl.LayoutTransform = new RotateTransform(0);

            int column = (int)(((Mouse.GetPosition(this.MainCanvas)).X - 20) / 110);
            int row = (int)(((Mouse.GetPosition(this.MainCanvas)).Y - 20) / 110);
            Canvas.SetLeft(movingControl, column * 110 + 20);
            Canvas.SetTop(movingControl, row * 110 + 20);
            MovingObject = null;
        }
        private void MouseMove(object sender, MouseEventArgs e)
        {
            
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (MovingObject == null) return;
                (MovingObject as FrameworkElement).SetValue(Canvas.LeftProperty,
                    e.GetPosition((MovingObject as FrameworkElement).Parent as FrameworkElement).X - FirstXPos);

                (MovingObject as FrameworkElement).SetValue(Canvas.TopProperty,
                    e.GetPosition((MovingObject as FrameworkElement).Parent as FrameworkElement).Y - FirstYPos);

            }
        }
        private void MainCanvas_Drop(object sender, DragEventArgs e)
        {
            Mouse.Capture(this.MainCanvas);
            Widget widget = e.Data.GetData("myWidget") as Widget;
            if (widget != null)
            {
                var newControl = new UserControl();

                if (widget.WidgetName.Contains("DateBlock"))
                {
                    newControl = new UserControl_DateBlock();
                }
                else if (widget.WidgetName.Contains("BurnDownChart"))
                {
                    newControl = new UserControl_BurnDownChart();
                }
                else if (widget.WidgetName.Contains("CriticalPathChart"))
                {
                    newControl = new UserControl_CriticalPathChart();
                }
                else if (widget.WidgetName.Contains("GanttChart"))
                {
                    newControl = new UserControl_MyGanttChart();
                }
                this.MainCanvas.Children.Add(newControl);
                int column = (int)(((Mouse.GetPosition(this.MainCanvas)).X - 20) / 110);
                int row = (int)(((Mouse.GetPosition(this.MainCanvas)).Y - 20) / 110);
                Canvas.SetLeft(newControl, column * 110 + 20);
                Canvas.SetTop(newControl, row * 110 + 20);
                newControl.PreviewMouseLeftButtonDown += this.MouseLeftButtonDown;
                newControl.PreviewMouseLeftButtonUp += this.PreviewMouseLeftButtonUp;
                newControl.Cursor = Cursors.Hand;
                newControl.ContextMenu = SettingMenu;
            }
            Mouse.Capture(null);

        }
        private void InitializeDragDropPosition()
        {
            //List<Double> Dots = new List<double>();
            //Dots.Add(1);
            //Dots.Add(2);
            //FirstPosition = new Rectangle();
            //FirstPosition.Stroke = new SolidColorBrush(Colors.Transparent);
            //FirstPosition.Fill = new SolidColorBrush(Colors.DarkGray);
            ////FirstPosition.StrokeDashArray = new DoubleCollection(Dots);

            //CurrentPosition = new Rectangle();
            //CurrentPosition.Stroke = Brushes.DarkGray;
            //CurrentPosition.StrokeDashArray = new DoubleCollection(Dots);

            //MainCanvas.Children.Add(FirstPosition);
            //Canvas.SetZIndex(FirstPosition, 1);
            //MainCanvas.Children.Add(CurrentPosition);

        }
        private void InitializeAnchorRectangles()
        {
             
            AnchorPoints = new List<Point>();
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Rectangle anchorRectangle = new Rectangle() { Width = 100, Height = 100, Stroke = new SolidColorBrush(Colors.Transparent) };
                    anchorRectangle.Fill = new SolidColorBrush(new Color() { R = 230, G = 230, B = 230, A = 255 });
                    anchorRectangle.Visibility = Visibility.Hidden;
                    this.MainCanvas.Children.Add(anchorRectangle);
                    Canvas.SetTop(anchorRectangle, 110 * j + 20);
                    Canvas.SetLeft(anchorRectangle, 110 * i + 20);
                    AnchorPoints.Add(new Point(110 * i + 20, 110 * j + 20));
                }
            }
        }
        #endregion

        private void Modified_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (Modified_Btn.ContentTemplate == this.Resources["ContentTemplate_Pencil"])
            {
                AllowDragDropControls();
                this.AddControl_Btn.Margin = new Thickness(10, 10, 10, 100);
                Modified_Btn.ContentTemplate = (DataTemplate)this.Resources["ContentTemplate_Check"];
                this.Modified_Btn.ToolTip = "結束編輯";
            }
            else
            {
                NotAllowGragDropControls();
                this.AddControl_Btn.Margin = new Thickness(10, 10, 10, 10);
                Modified_Btn.ContentTemplate = (DataTemplate)this.Resources["ContentTemplate_Pencil"];
                this.Modified_Btn.ToolTip = "編輯儀錶板";

            }

        }
        private void AddControl_Btn_Click(object sender, RoutedEventArgs e)
        {
            _ToolBox.Visibility = Visibility.Visible;
        }

        private void ToolBoxCloseBtn_Click(object sender, RoutedEventArgs e)
        {
            this._ToolBox.Visibility = Visibility.Collapsed;
            RoutedEventArgs e1 = new RoutedEventArgs();
            Modified_Btn_Click(sender, e1);
        }
        private void ControlSettingCloseBtn_Click(object sender, RoutedEventArgs e)
        {
            this._ControlSetting.Visibility = Visibility.Collapsed;
        }

        private void InitializeSettingMenu()
        {            
            SettingMenu = new ContextMenu() { };
            SettingMenu.Items.Add(new MenuItem() { Name = "Delete", Header = "刪除" });
            SettingMenu.Items.Add(new MenuItem() { Name = "Design", Header = "設計" });
            SettingMenu.PreviewMouseLeftButtonDown += SettingMenu_PreviewMouseLeftButtonDown;
        }
        private void InitializeExtraSettingPage()
        {
            _ToolBox = new UserControl_ToolBox()
            {
                Height = 690,
                Width = 330,
                HorizontalAlignment = HorizontalAlignment.Right,
            };

            _ToolBox.CloseBtn.Click += ToolBoxCloseBtn_Click;
            _ToolBox.Visibility = Visibility.Collapsed;
            this.WholePageGrid.Children.Add(_ToolBox);
            Grid.SetZIndex(_ToolBox, 3);

            _ControlSetting = new UserControl_ControlSetting()
            {
                Height =690,
                Width = 330,
                HorizontalAlignment = HorizontalAlignment.Right,

            };
            this.WholePageGrid.Children.Add(_ControlSetting);
            _ControlSetting.Visibility = Visibility.Collapsed;
            this._ControlSetting.CloseBtn.Click += ControlSettingCloseBtn_Click;
            this._ControlSetting.SizeComboBox.SelectionChanged += SizeComboBox_SelectionChanged;
            Grid.SetZIndex(_ControlSetting, 3);
        }



        private void SizeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_ControlSetting.SizeComboBox.SelectedItem == null) return;
            UserControl _control = ResizingObject as UserControl;
            string[] _size = ((ContentControl)_ControlSetting.SizeComboBox.SelectedItem).Content
                                .ToString().Split('X', ' ');
            _control.Width = (int.Parse(_size[0])) * 110 - 10;
            _control.Height = (int.Parse(_size[3])) * 110 - 10;
        }
    }
}



    



