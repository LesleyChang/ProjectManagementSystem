using ProjectManagementModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DashBoard
{
    public class DashboardWidgets //: INotifyPropertyChanged
    {
        public DashboardWidgets(int employeeID)
        {
            this.EmployeeID = employeeID;
            dbContext = new ProjectManagementEntities();
            Items = new ObservableCollection<Widget>();
            var query = dbContext.Dashboard.Where(d => d.DashBoardID == employeeID);
            foreach (var item in query)
            {
                Items.Add(new Widget() {
                    WidgetID = (int)item.WidgetID,
                    WidgetName = item.WidgetDetail.WidgetName.ToString(),
                    Desc = item.WidgetDetail.WidgetDesc.ToString(),
                    CanvasLeft = (int)item.PositionLeft,
                    CanvasTop = (int)item.PositionTop,
                    ImagePath = new BitmapImage(new Uri(item.WidgetDetail.WidgetImagePath.ToString(), UriKind.Relative)),
                    WidgetWidth = (int)item.WidgetWidth,
                    WidgetHeight = (int)item.WidgetHeight
                });
            }
        }
        public int EmployeeID { get; set; }
        public ObservableCollection<Widget> Items;
        public ProjectManagementEntities dbContext;

        public void LoadBackToDB(ObservableCollection<Widget> overviewItems)
        {
            try
            {
                var query = dbContext.Dashboard.Where(d => d.DashBoardID == EmployeeID);
                foreach (var item in query)
                {
                    dbContext.Dashboard.Remove(item);
                }
                
                foreach (var item in overviewItems)
                {
                    Dashboard dashboardRow = new Dashboard()
                    {
                        DashBoardID = EmployeeID,
                        WidgetID = item.WidgetID,
                        WidgetHeight = item.WidgetHeight,
                        WidgetWidth = item.WidgetWidth,
                        PositionLeft = item.CanvasLeft,
                        PositionTop = item.CanvasTop
                    };
                    dbContext.Dashboard.Add(dashboardRow);
                }
                dbContext.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }
        
       
    }

    public class ToolBoxWidgets
    {
        public ToolBoxWidgets()
        {
            dbContext = new ProjectManagementEntities();
            Items = new ObservableCollection<Widget>();
            foreach (var item in dbContext.WidgetDetail)
            {
                Items.Add(new Widget()
                {
                    WidgetID = (int)item.WidgetID,
                    WidgetName = item.WidgetName.ToString(),
                    Desc = item.WidgetDesc.ToString(),
                    ImagePath = new BitmapImage(new Uri(item.WidgetImagePath.ToString(), UriKind.Relative))
                });
            }
           
        }
        
        public ObservableCollection<Widget> Items;
        ProjectManagementEntities dbContext;
    }
    public class Widget
    {
        public int WidgetID { get; set; }
        public string WidgetName { get; set; }
        public UserControl Control { get; set; }
        public string Desc { get; set; }
        public int CanvasTop { get; set; }
        public int CanvasLeft { get; set; }
        public int WidgetWidth { get; set; }
        public int WidgetHeight { get; set; }
        public ImageSource ImagePath { get; set; }
        
    }
}
