using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Calendar;
using System.Xml.Serialization;
using System.IO;
//using ProjectModel;
using System.Linq;
using ProjectManagementModel;

namespace CalendarDemo
{
    public partial class DemoForm : Form
    {
        List<CalendarItem> _items = new List<CalendarItem>();
        CalendarItem contextItem = null;
        ProjectManagementEntities dbContext = new ProjectManagementEntities();
        public int employeeID = 1;

        public DemoForm()
        {
            InitializeComponent();

            //Monthview colors
            monthView1.MonthTitleColor = monthView1.MonthTitleColorInactive = CalendarColorTable.FromHex("#979797");  //左邊日期上方條 的顏色
            monthView1.ArrowsColor = CalendarColorTable.FromHex("#ffffff");  //左邊 左右選單的顏色
            monthView1.DaySelectedBackgroundColor = CalendarColorTable.FromHex("#e1ff9e");  //左邊日歷選日期時候的顏色
            monthView1.DaySelectedTextColor = monthView1.ForeColor;

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
                        cal.ApplyColor(Color.FromArgb(item.A, item.R, item.G, item.B));
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

                foreach(var z in q.Where(n => n.EmployeeID == employeeID))
                {
                    q.Local.Remove(z);
                }

                foreach( var x in lst)
                {
                    Caleadar caleadar = new Caleadar()
                    {
                        EmployeeID = employeeID,
                        StartTime = x.StartTime,
                        EndTime = x.EndTime,
                        Text = x.Text,
                        A = x.A,
                        R = x.R,
                        G = x.G,
                        B = x.B,
                    };
                    q.Local.Add(caleadar);
                }
                dbContext.SaveChanges();

                //foreach (var z in q.Where(n => n.EmployeeID == employeeID))
                //{
                //    q.Local.Remove(z);
                //}


                //foreach (var x in lst)
                //{
                //   Caleadar caleadar = new Caleadar()
                //    {
                //        EmployeeID = employeeID,
                //        Text = x.Text,
                //        StartTime = x.StartTime,
                //        EndTime = x.EndTime,
                //        A = x.A,
                //        R = x.R,
                //        G = x.G,
                //        B = x.B,
                //    };
                //    q.Local.Add(caleadar);
                //}
                //dbContext.SaveChanges();
            }
        }



        private void calendar1_ItemDoubleClick(object sender, CalendarItemEventArgs e) //雙擊任務條,顯示任務內容
        {
            MessageBox.Show("任 務 : " + e.Item.Text);
        }

        private void calendar1_ItemDeleted(object sender, CalendarItemEventArgs e) //執行中將不要的任務條刪除,不會重複出現
        {
            _items.Remove(e.Item);
        }

        private void calendar1_DayHeaderClick(object sender, CalendarDayEventArgs e) //點擊進入 一天的細項
        {
            calendar1.SetViewRange(e.CalendarDay.Date, e.CalendarDay.Date);
        }

        private void calendar1_ItemCreated(object sender, CalendarItemCancelEventArgs e)  //??
        {
            _items.Add(e.Item);
        }

        private void calendar1_ItemMouseHover(object sender, CalendarItemEventArgs e)  //任務條的文字顯示在左上方的form Text
        {
            Text = e.Item.Text;
        }

        private void calendar1_ItemClick(object sender, CalendarItemEventArgs e)
        {
            //MessageBox.Show(e.Item.Text);
        }

        private void editItemToolStripMenuItem_Click(object sender, EventArgs e)  //輸入文字
        {
            calendar1.ActivateEditMode();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e) //右鍵選單
        {
            contextItem = calendar1.ItemAt(contextMenuStrip1.Bounds.Location);
        }

        private void monthView1_SelectionChanged(object sender, EventArgs e) //左邊的行事曆執行滑鼠日期拉選,在右邊顯示出來
        {
            calendar1.SetViewRange(monthView1.SelectionStart, monthView1.SelectionEnd);
        }




        private void hourToolStripMenuItem_Click(object sender, EventArgs e)  // 展示區間: 60分
        {
            calendar1.TimeScale = CalendarTimeScale.SixtyMinutes;
        }

        private void minutesToolStripMenuItem_Click(object sender, EventArgs e) // 展示區間: 30分
        {
            calendar1.TimeScale = CalendarTimeScale.ThirtyMinutes;
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e) // 展示區間: 15分
        {
            calendar1.TimeScale = CalendarTimeScale.FifteenMinutes;
        }

        private void minutesToolStripMenuItem2_Click(object sender, EventArgs e) // 展示區間: 6分
        {
            calendar1.TimeScale = CalendarTimeScale.SixMinutes;
        }

        private void minutesToolStripMenuItem1_Click(object sender, EventArgs e) // 展示區間: 10分
        {
            calendar1.TimeScale = CalendarTimeScale.TenMinutes;
        }

        private void minutesToolStripMenuItem3_Click(object sender, EventArgs e) // 展示區間: 5分
        {
            calendar1.TimeScale = CalendarTimeScale.FiveMinutes;
        }

        private void redTagToolStripMenuItem_Click(object sender, EventArgs e) //將任務條改為 紅色
        {
            foreach (CalendarItem item in calendar1.GetSelectedItems())
            {
                item.ApplyColor(Color.Red);
                calendar1.Invalidate(item);
            }
        }

        private void yellowTagToolStripMenuItem_Click(object sender, EventArgs e) //將任務條改為 金色
        {
            foreach (CalendarItem item in calendar1.GetSelectedItems())
            {
                item.ApplyColor(Color.Gold);
                calendar1.Invalidate(item);
            }
        }

        private void greenTagToolStripMenuItem_Click(object sender, EventArgs e) //該任務條改為 綠色
        {
            foreach (CalendarItem item in calendar1.GetSelectedItems())
            {
                item.ApplyColor(Color.Green);
                calendar1.Invalidate(item);
            }
        }

        private void blueTagToolStripMenuItem_Click(object sender, EventArgs e) //將任務條改為 紫色
        {
            foreach (CalendarItem item in calendar1.GetSelectedItems())
            {
                item.ApplyColor(Color.DarkBlue);
                calendar1.Invalidate(item);
            }
        }

        private void otherColorTagToolStripMenuItem_Click(object sender, EventArgs e)  //使用調色盤 改變任務條顏色
        {
            using (ColorDialog dlg = new ColorDialog())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    foreach (CalendarItem item in calendar1.GetSelectedItems())
                    {
                        item.ApplyColor(dlg.Color);
                        calendar1.Invalidate(item);
                    }
                }
            }
        }

        private void diagonalToolStripMenuItem_Click(object sender, EventArgs e)  //在任務條加入 對角線
        {
            foreach (CalendarItem item in calendar1.GetSelectedItems())
            {
                item.Pattern = System.Drawing.Drawing2D.HatchStyle.ForwardDiagonal;
                item.PatternColor = Color.Red;
                calendar1.Invalidate(item);
            }
        }

        private void verticalToolStripMenuItem_Click(object sender, EventArgs e) //在任務條加入 垂直線
        {
            foreach (CalendarItem item in calendar1.GetSelectedItems())
            {
                item.Pattern = System.Drawing.Drawing2D.HatchStyle.Vertical;
                item.PatternColor = Color.Red;
                calendar1.Invalidate(item);
            }
        }

        private void horizontalToolStripMenuItem_Click(object sender, EventArgs e) //在任務條加入 橫線
        {
            foreach (CalendarItem item in calendar1.GetSelectedItems())
            {
                item.Pattern = System.Drawing.Drawing2D.HatchStyle.Horizontal;
                item.PatternColor = Color.Red;
                calendar1.Invalidate(item);
            }
        }

        private void hatchToolStripMenuItem_Click(object sender, EventArgs e) //在任務條加入 交叉線
        {
            foreach (CalendarItem item in calendar1.GetSelectedItems())
            {
                item.Pattern = System.Drawing.Drawing2D.HatchStyle.DiagonalCross;
                item.PatternColor = Color.Red;
                calendar1.Invalidate(item);
            }
        }

        private void noneToolStripMenuItem_Click(object sender, EventArgs e) //將任務條的線 清空
        {
            foreach (CalendarItem item in calendar1.GetSelectedItems())
            {
                item.Pattern = System.Drawing.Drawing2D.HatchStyle.DiagonalCross;
                item.PatternColor = Color.Empty;
                calendar1.Invalidate(item);
            }
        }

        private void northToolStripMenuItem_Click(object sender, EventArgs e)  //將圖片放置北方(North)
        {
            foreach (CalendarItem item in calendar1.GetSelectedItems())
            {
                item.ImageAlign = CalendarItemImageAlign.North;
                calendar1.Invalidate(item);
            }
        }

        private void eastToolStripMenuItem_Click(object sender, EventArgs e) //將圖片放置東方(East)
        {
            foreach (CalendarItem item in calendar1.GetSelectedItems())
            {
                item.ImageAlign = CalendarItemImageAlign.East;
                calendar1.Invalidate(item);
            }
        }

        private void southToolStripMenuItem_Click(object sender, EventArgs e) //將圖片放置南方(South)
        {
            foreach (CalendarItem item in calendar1.GetSelectedItems())
            {
                item.ImageAlign = CalendarItemImageAlign.South;
                calendar1.Invalidate(item);
            }
        }

        private void westToolStripMenuItem_Click(object sender, EventArgs e) //將圖片放置西方(West)
        {
            foreach (CalendarItem item in calendar1.GetSelectedItems())
            {
                item.ImageAlign = CalendarItemImageAlign.West;
                calendar1.Invalidate(item);
            }
        }

        private void selectImageToolStripMenuItem_Click(object sender, EventArgs e) //將圖片匯入
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Filter = "*.gif|*.gif|*.png|*.png|*.jpg|*.jpg";

                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    Image img = Image.FromFile(dlg.FileName);

                    foreach (CalendarItem item in calendar1.GetSelectedItems())
                    {
                        item.Image = img;
                        calendar1.Invalidate(item);
                    }
                }
            }


        }
    }
}