using De.TorstenMandelkow.MetroChart;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using Wpf_ProjectCostManager.ViewModel;
using System.Text.RegularExpressions;

namespace Wpf_ProjectCostManager
{
    /// <summary>
    /// Window_ProjectDetails.xaml 的互動邏輯
    /// </summary>
    public partial class Window_ProjectDetails : Window
    {
        public Window_ProjectDetails()
        {
            InitializeComponent();
        }

        public string ProjectID
        {
            get
            {
                return this.tb_ID.Text;
            }
            set
            {
                this.tb_ID.Text = value;
                this.DataContext = new ClsPageViewModel(ProjectID);
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
        public string RequiredDepartment
        {
            get
            {
                return this.tb_Department.Text;
            }
            set
            {
                this.tb_Department.Text = value;
            }
        }
        public double ProgressByTasks
        {
            get
            {
                return this.progressBar_Complete.Value;
            }
            set
            {
                this.progressBar_Complete.Value = value;
            }
        }
        public double ProgressByBudget
        {
            get
            {
                return this.progressBar_Budget.Value;
            }
        }
        public double InputCost
        {
            get
            {
                string cost = Regex.Replace(this.tb_InputCost.Text, "[^0-9]", "");
                return double.Parse(cost);
            }
            set
            {
                this.tb_InputCost.Text = value.ToString("C2");
            }
        }
        public double TotalCost
        {
            get
            {
                string cost = Regex.Replace(this.tb_TotalCost.Text, "[^0-9]", "");
                return double.Parse(cost);
            }
            set
            {
                this.tb_TotalCost.Text = value.ToString("C2");
            }
        }

        private void progressBar_Budget_Loaded(object sender, RoutedEventArgs e)
        {
            InputCost = ((ClsPageViewModel)DataContext).TotalInput;
            if(TotalCost != 0)
            {
                this.progressBar_Budget.Value = (InputCost / TotalCost) * 100;
                this.lb_BudgetUsed.Content = (InputCost / TotalCost).ToString("#0.00%");
            }
            else
            {
                this.progressBar_Budget.Value = 0;
                this.lb_BudgetUsed.Content ="0.00%";

            }
        }
        private void progressBar_Complete_Loaded(object sender, RoutedEventArgs e)
        {
            this.lb_Finished.Content = (this.progressBar_Complete.Value/100).ToString("#0.00%");
        }
    }
}

