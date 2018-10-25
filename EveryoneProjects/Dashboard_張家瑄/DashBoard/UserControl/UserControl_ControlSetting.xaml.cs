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
    /// UserControl_ControlSetting.xaml 的互動邏輯
    /// </summary>
    public partial class UserControl_ControlSetting : UserControl
    {
        public UserControl_ControlSetting()
        {            
            InitializeComponent();
            InitializeSizeComboBox();
        }

        private void InitializeSizeComboBox()
        {
            this.SizeComboBox.Items.Clear();
            for (int i = 1; i <=6; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    SizeComboBox.Items.Add(new ContentControl() { Content = $"{i} X {j}" });
                }
            }
            X_block = (int)(_controlSize.Width + 10) / 110;
            Y_block = (int)(_controlSize.Height + 10) / 110;
            string size = $"{X_block} X {Y_block}";
            
            foreach (var item in SizeComboBox.Items)
            {
                ContentControl content = item as ContentControl;
                if (content.Content.ToString() == size)
                {
                    this.SizeComboBox.SelectedItem = item;
                    break;
                }
            }

        }
        public int X_block { get; set; }
        public int Y_block { get; set; }
        public Size ControlSize
        {
            get { return _controlSize; }
            set
            {
                _controlSize = value;
                InitializeSizeComboBox();
            }
        }
        private Size _controlSize;
    }
}
