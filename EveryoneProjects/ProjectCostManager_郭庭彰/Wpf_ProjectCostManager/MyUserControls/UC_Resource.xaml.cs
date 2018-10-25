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

namespace Wpf_ProjectCostManager.MyUserControls
{
    /// <summary>
    /// UC_Resource.xaml 的互動邏輯
    /// </summary>
    public partial class UC_Resource : System.Windows.Controls.UserControl
    {
        public UC_Resource()
        {
            InitializeComponent();
            this.btn_Add.Click += Btn_Add_Click; ;
            this.btn_Remove.Click += Btn_Remove_Click;
            this.tb_Quantity.TextChanged += Tb_Quantity_TextChanged;
            this.tb_UnitPrice.TextChanged += Tb_UnitPrice_TextChanged;
            this.tb_SubTotal.TextChanged += Tb_SubTotal_TextChanged;
        }

        private void Tb_SubTotal_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (this.SubTotalChanged != null)
            {
                this.SubTotalChanged.Invoke(this, e);
            }
        }

        private void Tb_UnitPrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (this.UnitPriceChanged != null)
            {
                this.UnitPriceChanged.Invoke(this, e);
            }
        }

        private void Tb_Quantity_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(this.QuantityChanged != null)
            {
                this.QuantityChanged.Invoke(this, e);
            }
        }

        public event RoutedEventHandler Add;
        public event RoutedEventHandler Remove;
        public event TextChangedEventHandler QuantityChanged;
        public event TextChangedEventHandler UnitPriceChanged;
        public event TextChangedEventHandler SubTotalChanged;


        private void Btn_Add_Click(object sender, RoutedEventArgs e)
        {
            if (this.Add != null)
            {
                this.Add.Invoke(this, e);
            }
        }

        private void Btn_Remove_Click(object sender, RoutedEventArgs e)
        {
            if (this.Remove != null)
            {
                this.Remove.Invoke(this, e);
            }
        }

        public DateTime Date
        {
            get
            {
                return (DateTime)this.dp_ExpenseDate.SelectedDate;
            }
            set
            {
                this.dp_ExpenseDate.SelectedDate = value;
            }
        }
        public ItemCollection TaskNames
        {
            get
            {
                return this.cb_TaskName.Items;
            }
            set
            {
                this.cb_TaskName.Items.Add(value);
            }
        }
        public string ResourceName
        {
            get
            {
                return this.tb_ResourceName.Text;
            }
            set
            {
                this.tb_ResourceName.Text = value;
            }
        }
        public ItemCollection Categories
        {
            get
            {
                return this.cb_Category.Items;
            }
            set
            {
                this.cb_Category.Items.Add(value);
            }
        }
        public int Quantity
        {
            get
            {
                int.TryParse(this.tb_Quantity.Text,out int quantity);
                return quantity;
            }
            set
            {
                this.tb_Quantity.Text = value.ToString();
                if(this.UnitPrice != 0)
                {
                    this.SubTotal = this.Quantity * this.UnitPrice;
                }
            }
        }
        public string Unit
        {
            get
            {
                return this.tb_Unit.Text;
            }
            set
            {
                this.tb_Unit.Text = value;
            }
        }
        public decimal UnitPrice
        {
            get
            {
                decimal.TryParse(this.tb_UnitPrice.Text, out decimal price);
                return price;
            }
            set
            {
                this.tb_UnitPrice.Text = value.ToString();
            }
        }
        public decimal SubTotal
        {
            get
            {
                decimal.TryParse(this.tb_SubTotal.Text, out decimal amount);
                return amount;
            }
            set
            {
                this.tb_SubTotal.Text = value.ToString();
            }
        }
        public string SelectedCategory
        {
            get
            {
                return this.cb_Category.SelectedItem.ToString();
            }
            set
            {
                this.cb_Category.SelectedItem = value;
            }
        }
        public string SelectedTask
        {
            get
            {
                return this.cb_TaskName.SelectedItem.ToString();
            }
            set
            {
                this.cb_TaskName.SelectedItem = value;
            }
        }
    }
}
