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
            monthView1.MonthTitleColor = monthView1.MonthTitleColorInactive = CalendarColorTable.FromHex("#979797");  //�������W��� ���C��
            monthView1.ArrowsColor = CalendarColorTable.FromHex("#ffffff");  //���� ���k��檺�C��
            monthView1.DaySelectedBackgroundColor = CalendarColorTable.FromHex("#e1ff9e");  //�����������ɭԪ��C��
            monthView1.DaySelectedTextColor = monthView1.ForeColor;

        }

        public FileInfo ItemsFile  //xml��Ʈw
        {
            get
            {
                return new FileInfo(Path.Combine(Application.StartupPath, "items.xml"));
            }
        }       

        private void Form1_Load(object sender, EventArgs e)  //Ū��DB���
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

        private void calendar1_LoadItems(object sender, CalendarLoadEventArgs e)  //Ū��BD���
        {
            PlaceItems();
        }

        private void PlaceItems()  //Ū��BD���
        {
            foreach (CalendarItem item in _items)
            {
                if (calendar1.ViewIntersects(item))
                {
                    calendar1.Items.Add(item);
                }
            }
        }


        private void DemoForm_FormClosing(object sender, FormClosingEventArgs e)   //�s�W��s�ɦ�DB 
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



        private void calendar1_ItemDoubleClick(object sender, CalendarItemEventArgs e) //�������ȱ�,��ܥ��Ȥ��e
        {
            MessageBox.Show("�� �� : " + e.Item.Text);
        }

        private void calendar1_ItemDeleted(object sender, CalendarItemEventArgs e) //���椤�N���n�����ȱ��R��,���|���ƥX�{
        {
            _items.Remove(e.Item);
        }

        private void calendar1_DayHeaderClick(object sender, CalendarDayEventArgs e) //�I���i�J �@�Ѫ��Ӷ�
        {
            calendar1.SetViewRange(e.CalendarDay.Date, e.CalendarDay.Date);
        }

        private void calendar1_ItemCreated(object sender, CalendarItemCancelEventArgs e)  //??
        {
            _items.Add(e.Item);
        }

        private void calendar1_ItemMouseHover(object sender, CalendarItemEventArgs e)  //���ȱ�����r��ܦb���W�誺form Text
        {
            Text = e.Item.Text;
        }

        private void calendar1_ItemClick(object sender, CalendarItemEventArgs e)
        {
            //MessageBox.Show(e.Item.Text);
        }

        private void editItemToolStripMenuItem_Click(object sender, EventArgs e)  //��J��r
        {
            calendar1.ActivateEditMode();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e) //�k����
        {
            contextItem = calendar1.ItemAt(contextMenuStrip1.Bounds.Location);
        }

        private void monthView1_SelectionChanged(object sender, EventArgs e) //���䪺��ƾ����ƹ�����Կ�,�b�k����ܥX��
        {
            calendar1.SetViewRange(monthView1.SelectionStart, monthView1.SelectionEnd);
        }




        private void hourToolStripMenuItem_Click(object sender, EventArgs e)  // �i�ܰ϶�: 60��
        {
            calendar1.TimeScale = CalendarTimeScale.SixtyMinutes;
        }

        private void minutesToolStripMenuItem_Click(object sender, EventArgs e) // �i�ܰ϶�: 30��
        {
            calendar1.TimeScale = CalendarTimeScale.ThirtyMinutes;
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e) // �i�ܰ϶�: 15��
        {
            calendar1.TimeScale = CalendarTimeScale.FifteenMinutes;
        }

        private void minutesToolStripMenuItem2_Click(object sender, EventArgs e) // �i�ܰ϶�: 6��
        {
            calendar1.TimeScale = CalendarTimeScale.SixMinutes;
        }

        private void minutesToolStripMenuItem1_Click(object sender, EventArgs e) // �i�ܰ϶�: 10��
        {
            calendar1.TimeScale = CalendarTimeScale.TenMinutes;
        }

        private void minutesToolStripMenuItem3_Click(object sender, EventArgs e) // �i�ܰ϶�: 5��
        {
            calendar1.TimeScale = CalendarTimeScale.FiveMinutes;
        }

        private void redTagToolStripMenuItem_Click(object sender, EventArgs e) //�N���ȱ��אּ ����
        {
            foreach (CalendarItem item in calendar1.GetSelectedItems())
            {
                item.ApplyColor(Color.Red);
                calendar1.Invalidate(item);
            }
        }

        private void yellowTagToolStripMenuItem_Click(object sender, EventArgs e) //�N���ȱ��אּ ����
        {
            foreach (CalendarItem item in calendar1.GetSelectedItems())
            {
                item.ApplyColor(Color.Gold);
                calendar1.Invalidate(item);
            }
        }

        private void greenTagToolStripMenuItem_Click(object sender, EventArgs e) //�ӥ��ȱ��אּ ���
        {
            foreach (CalendarItem item in calendar1.GetSelectedItems())
            {
                item.ApplyColor(Color.Green);
                calendar1.Invalidate(item);
            }
        }

        private void blueTagToolStripMenuItem_Click(object sender, EventArgs e) //�N���ȱ��אּ ����
        {
            foreach (CalendarItem item in calendar1.GetSelectedItems())
            {
                item.ApplyColor(Color.DarkBlue);
                calendar1.Invalidate(item);
            }
        }

        private void otherColorTagToolStripMenuItem_Click(object sender, EventArgs e)  //�ϥνզ�L ���ܥ��ȱ��C��
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

        private void diagonalToolStripMenuItem_Click(object sender, EventArgs e)  //�b���ȱ��[�J �﨤�u
        {
            foreach (CalendarItem item in calendar1.GetSelectedItems())
            {
                item.Pattern = System.Drawing.Drawing2D.HatchStyle.ForwardDiagonal;
                item.PatternColor = Color.Red;
                calendar1.Invalidate(item);
            }
        }

        private void verticalToolStripMenuItem_Click(object sender, EventArgs e) //�b���ȱ��[�J �����u
        {
            foreach (CalendarItem item in calendar1.GetSelectedItems())
            {
                item.Pattern = System.Drawing.Drawing2D.HatchStyle.Vertical;
                item.PatternColor = Color.Red;
                calendar1.Invalidate(item);
            }
        }

        private void horizontalToolStripMenuItem_Click(object sender, EventArgs e) //�b���ȱ��[�J ��u
        {
            foreach (CalendarItem item in calendar1.GetSelectedItems())
            {
                item.Pattern = System.Drawing.Drawing2D.HatchStyle.Horizontal;
                item.PatternColor = Color.Red;
                calendar1.Invalidate(item);
            }
        }

        private void hatchToolStripMenuItem_Click(object sender, EventArgs e) //�b���ȱ��[�J ��e�u
        {
            foreach (CalendarItem item in calendar1.GetSelectedItems())
            {
                item.Pattern = System.Drawing.Drawing2D.HatchStyle.DiagonalCross;
                item.PatternColor = Color.Red;
                calendar1.Invalidate(item);
            }
        }

        private void noneToolStripMenuItem_Click(object sender, EventArgs e) //�N���ȱ����u �M��
        {
            foreach (CalendarItem item in calendar1.GetSelectedItems())
            {
                item.Pattern = System.Drawing.Drawing2D.HatchStyle.DiagonalCross;
                item.PatternColor = Color.Empty;
                calendar1.Invalidate(item);
            }
        }

        private void northToolStripMenuItem_Click(object sender, EventArgs e)  //�N�Ϥ���m�_��(North)
        {
            foreach (CalendarItem item in calendar1.GetSelectedItems())
            {
                item.ImageAlign = CalendarItemImageAlign.North;
                calendar1.Invalidate(item);
            }
        }

        private void eastToolStripMenuItem_Click(object sender, EventArgs e) //�N�Ϥ���m�F��(East)
        {
            foreach (CalendarItem item in calendar1.GetSelectedItems())
            {
                item.ImageAlign = CalendarItemImageAlign.East;
                calendar1.Invalidate(item);
            }
        }

        private void southToolStripMenuItem_Click(object sender, EventArgs e) //�N�Ϥ���m�n��(South)
        {
            foreach (CalendarItem item in calendar1.GetSelectedItems())
            {
                item.ImageAlign = CalendarItemImageAlign.South;
                calendar1.Invalidate(item);
            }
        }

        private void westToolStripMenuItem_Click(object sender, EventArgs e) //�N�Ϥ���m���(West)
        {
            foreach (CalendarItem item in calendar1.GetSelectedItems())
            {
                item.ImageAlign = CalendarItemImageAlign.West;
                calendar1.Invalidate(item);
            }
        }

        private void selectImageToolStripMenuItem_Click(object sender, EventArgs e) //�N�Ϥ��פJ
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