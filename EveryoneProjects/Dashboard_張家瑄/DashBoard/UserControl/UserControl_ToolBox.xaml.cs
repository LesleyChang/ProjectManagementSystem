using CriticalPathChart;
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

namespace DashBoard
{
    /// <summary>
    /// UserControl_ToolBox.xaml 的互動邏輯
    /// </summary>
    public partial class UserControl_ToolBox : UserControl
    {
        public UserControl_ToolBox()
        {
            InitializeComponent();
            WidgetData = new ToolBoxWidgets();
            DataContext = this;
            WidgetList.ItemsSource = WidgetData.Items;
        }

        //private void InitializeWidgetList()
        //{
        //    //未連資料庫
        //    WidgetData = new ToolBoxWidgets()
        //    {
        //        Items = new ObservableCollection<DashBoard.Widget>()
        //        {
        //            new DashBoard.Widget(){ Control = new UserControl_DateBlock(), Desc = "日期顯示磚" + Environment.NewLine +"DateBlock"  },
        //            new DashBoard.Widget(){ Control = new UserControl_BurnDownChart(),Desc = "燃燼圖"+ Environment.NewLine +"Burndown Chart"},
        //            new DashBoard.Widget(){ Control = new UserControl_MyGanttChart(),Desc = "甘特圖"+ Environment.NewLine +"Gantt Chart"},
        //            new DashBoard.Widget(){ Control = new UserControl_CriticalPathChart(),Desc = "要徑圖"+ Environment.NewLine +"Critical Path Chart"}
        //        }
        //    };
        //}


        public Point startPoint { get; set; }
        public ToolBoxWidgets WidgetData;
        

        //private void DragListboxItem(object sender, MouseButtonEventArgs e)
        //{
        //    ListBoxItem listBoxItem = e.OriginalSource as ListBoxItem;
        //    if(listBoxItem != null)
        //    {
        //        Widget w = (Widget)WidgetList.ItemContainerGenerator.ItemFromContainer(listBoxItem);
        //        DragDrop.DoDragDrop(listBoxItem, w.Control, DragDropEffects.Copy);
        //    }
        //}


        private void WidgetList_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //startPoint = e.GetPosition(null);           
        }

        private void WidgetList_PreviewMouseMove(object sender, MouseEventArgs e)
        {

            // Get the current mouse position
            //Point mousePos = e.GetPosition(null);
            //Vector diff = startPoint - mousePos;

            if (e.LeftButton == MouseButtonState.Pressed /*&&
                Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance*/)
            {
                ListBox listBox = sender as ListBox;
                if (listBox == null) return;
                ListBoxItem listBoxItem = FindAnchestor<ListBoxItem>((DependencyObject)e.OriginalSource);
                if (listBoxItem == null) return;

                Widget w = (Widget)listBox.ItemContainerGenerator.ItemFromContainer(listBoxItem);
                DataObject dragData = new DataObject("myWidget", w);
                DragDrop.DoDragDrop(listBoxItem, dragData, DragDropEffects.Move);
            }


        }
        private static T FindAnchestor<T>(DependencyObject current) where T : DependencyObject
        {
            do
            {
                if (current is T)
                {
                    return (T)current;
                }
                current = VisualTreeHelper.GetParent(current);
            }
            while (current != null);
            return null;
        }
    }
}
