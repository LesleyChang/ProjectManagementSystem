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
using System.Windows.Shapes;

namespace Wpf_LoginSystem.View
{
    /// <summary>
    /// Window_ResetPassword.xaml 的互動邏輯
    /// </summary>
    public partial class Window_ResetPassword : Window
    {
        public Window_ResetPassword()
        {
            InitializeComponent();
        }

        private void Reset(object sender, RoutedEventArgs e)
        {
            int.TryParse(this.tb_EmployeeID.Text, out int EmployeeID);
            string MemberID = this.tb_ID.Text;
            string Password1 = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(this.tb_PW.Text, "MD5");
            string Password2 = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(this.tb_PW_Copy.Text, "MD5");

            ClsAccountViewModel VM = new ClsAccountViewModel();
            VM.ResetPassword(EmployeeID, MemberID, Password1, Password2);
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
