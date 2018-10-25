using CalendarDemo;
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
using System.Windows.Forms.Calendar;
//using ProjectModel;
using System.IO;
using Path = System.IO.Path;
using Application = System.Windows.Forms.Application;
using Calendar = System.Windows.Forms.Calendar.Calendar;
using ProjectManagementModel;

namespace ProjectSystemCalendar
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class CalendarPage : Window
    {
        List<CalendarItem> _items = new List<CalendarItem>();
        ProjectManagementEntities dbContext = new ProjectManagementEntities();
        public int employeeID = 1;
        private Form demoForm = new DemoForm();
        private Calendar calendar1;

        public CalendarPage()
        {
            InitializeComponent();

            demoForm.TopLevel = false;
            demoForm.FormBorderStyle = FormBorderStyle.None;
            DemoFormHost1.Child = demoForm;
            
        }


        public FileInfo ItemsFile  //xml資料庫
        {
            get
            {
                return new FileInfo(Path.Combine(Application.StartupPath, "items.xml"));
            }
        }

        private void Form1_Load(object sender, EventArgs e)  //讀取DB資料
        {
            if (ItemsFile.Exists)
            {
                var q = dbContext.Caleadar;

                List<ItemInfo> lst = new List<ItemInfo>();
                foreach (var x in q)
                {
                    ItemInfo info = new ItemInfo()
                    {
                        CaleadarID = x.CaleadarID,
                        EmployeeID = (int)x.EmployeeID,
                        StartTime = (DateTime)x.StartTime,
                        EndTime = (DateTime)x.EndTime,
                        Text = x.Text,
                        A = (int)x.A,
                        R = (int)x.R,
                        G = (int)x.G,
                        B = (int)x.B,
                    };
                    lst.Add(info);
                }

                foreach (ItemInfo item in lst)
                {
                    CalendarItem cal = new CalendarItem(calendar1, item.StartTime, item.EndTime, item.Text);

                    if (!(item.R == 0 && item.G == 0 && item.B == 0))
                    {
                        cal.ApplyColor(System.Drawing.Color.FromArgb(item.A, item.R, item.G, item.B));
                    }

                    _items.Add(cal);
                }

                PlaceItems();
            }
        }

        private void calendar1_LoadItems(object sender, CalendarLoadEventArgs e)  //讀取BD資料
        {
            PlaceItems();
        }

        private void PlaceItems()  //讀取BD資料
        {
            foreach (CalendarItem item in _items)
            {
                if (calendar1.ViewIntersects(item))
                {
                    calendar1.Items.Add(item);
                }
            }
        }


        private void DemoForm_FormClosing(object sender, FormClosingEventArgs e)   //新增後存檔至DB 
        {
            var q = dbContext.Caleadar;
            foreach (var z in q.Where(n => n.EmployeeID == employeeID))
            {
                q.Local.Remove(z);
            }
            dbContext.SaveChanges();

            if (_items.Count > 0)
            {
                List<ItemInfo> lst = new List<ItemInfo>();

                foreach (CalendarItem item in _items)
                {
                    lst.Add(new ItemInfo(item.EmployeeID, item.StartDate, item.EndDate, item.Text, item.BackgroundColor));
                }

                foreach (var z in q.Where(n => n.EmployeeID == employeeID))
                {
                    q.Local.Remove(z);
                }


                foreach (var x in lst)
                {
                    Caleadar caleadar = new Caleadar()
                    {
                        EmployeeID = employeeID,
                        Text = x.Text,
                        StartTime = x.StartTime,
                        EndTime = x.EndTime,
                        A = x.A,
                        R = x.R,
                        G = x.G,
                        B = x.B,
                    };
                    q.Local.Add(caleadar);
                }
                dbContext.SaveChanges();
            }
        }

    }
}
