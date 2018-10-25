//using projectManagemaentEntity;
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
using Trello._UserControl;
using Trello.UserControl;
using Button = System.Windows.Controls.Button;
using TextBox = System.Windows.Controls.TextBox;

namespace Trello.page
{
    /// <summary>
    /// Page_board.xaml 的互動邏輯
    /// </summary>
    public partial class Page_board : Page
    {
        public Page_board()
        {
            InitializeComponent();
            B_grid.Background = new SolidColorBrush(Colors.White);
        }

        public UserControl_Board board { get; internal set; }
        
    }
}
