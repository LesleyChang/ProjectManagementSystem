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

namespace DashBoard
{
    /// <summary>
    /// UserControl_DateBlock.xaml 的互動邏輯
    /// </summary>
    public partial class UserControl_DateBlock : UserControl
    {
        public UserControl_DateBlock()
        {
            InitializeComponent();
            DateTime dateTime = DateTime.Now;
            this.Year = dateTime.Year;
            this.Month = dateTime.Month;
            this.Day = dateTime.Day;
            DayOfWeekParse(dateTime.DayOfWeek);
            
            DataContext = this;
        }

        private void DayOfWeekParse(DayOfWeek dayOfWeek)
        {
            switch (dayOfWeek)
            {
                case System.DayOfWeek.Sunday:
                    this.DayOfWeek = "星期天";
                    break;
                case System.DayOfWeek.Monday:
                    this.DayOfWeek = "星期一";
                    break;
                case System.DayOfWeek.Tuesday:
                    this.DayOfWeek = "星期二";
                    break;
                case System.DayOfWeek.Wednesday:
                    this.DayOfWeek = "星期三";
                    break;
                case System.DayOfWeek.Thursday:
                    this.DayOfWeek = "星期四";
                    break;
                case System.DayOfWeek.Friday:
                    this.DayOfWeek = "星期五";
                    break;
                case System.DayOfWeek.Saturday:
                    this.DayOfWeek = "星期六";
                    break;              
            }

        }

        public int Year { get; set; }
        public int Month  { get; set; }
        public int Day { get; set; }
        public string DayOfWeek { get; set; }    
        
    }
}
