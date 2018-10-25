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

namespace Wpf_ProjectCostManager
{
    /// <summary>
    /// ProjectItem.xaml 的互動邏輯
    /// </summary>
    public partial class UC_Project : System.Windows.Controls.UserControl
    {
        public UC_Project()
        {
            InitializeComponent();
        }

        public event MouseEventHandler Click;

        public string ProjectID
        {
            get
            {
                return this.tb_ID.Text;
            }
            set
            {
                this.tb_ID.Text = value;
            }
        }

        public string ProjectName
        {
            get
            {
                return this.tb_Name.Text;
            }
            set
            {
                this.tb_Name.Text = value;
            }
        }

        public string ImagePath
        {
            get
            {
                return this.image.Source.ToString();
            }
            set
            {
                BitmapImage bmp = new BitmapImage();
                bmp.BeginInit();
                bmp.UriSource = new Uri(value, UriKind.Absolute);
                bmp.EndInit();
                this.image.Source = bmp;
            }
        }

        //public byte[] ImageByte
        //{
        //    set
        //    {
        //        MemoryStream ms = new MemoryStream(value);
        //        BitmapImage bmp = new BitmapImage();
        //        bmp.BeginInit();
        //        bmp.StreamSource = ms;
        //        bmp.EndInit();
        //        this.image.Source = bmp;
        //    }
        //}

        private void LeftMouseClick(object sender, MouseButtonEventArgs e)
        {
            if(this.Click != null)
            {
                this.Click.Invoke(this, e);
            }
        }
    }
}
