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
using Wpf_LoginSystem.View;

namespace Wpf_LoginSystem
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private string MemberID;
        private string Password;

        private void Login(object sender, RoutedEventArgs e)
        {
            MemberID = this.tb_ID.Text;
            Password = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(this.tb_PW.Text, "MD5");
            ClsAccountViewModel VM = new ClsAccountViewModel();
            if(VM.Login(MemberID, Password))
            {
                DialogResult = true;
            }
        }

        private void Register(object sender, RoutedEventArgs e)
        {
            Window window = new Window_Register();
            window.Show();
        }

        private void ResetPW(object sender, RoutedEventArgs e)
        {
            Window window = new Window_ResetPassword();
            window.Show();
        }
    }
}
