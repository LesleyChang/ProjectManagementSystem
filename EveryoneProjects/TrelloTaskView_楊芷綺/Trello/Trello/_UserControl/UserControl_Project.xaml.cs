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

namespace Trello._UserControl
{
    /// <summary>
    /// UserControl_Project.xaml 的互動邏輯
    /// </summary>
    public partial class UserControl_Project : System.Windows.Controls.UserControl
    {
        public UserControl_Project()
        {
            InitializeComponent();
        }

        public string projectID { get; internal set; }
    }
}
