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
using Trello._UserControl;
using Trello.UserControl;

namespace Trello.page
{
    /// <summary>
    /// Window_setup_details.xaml 的互動邏輯
    /// </summary>
    public partial class Window_setup_details : Window
    {
        public Window_setup_details()
        {
            InitializeComponent();
            this.Topmost = true;
        }
        global::projectManagemaentEntity.ProjectManagementEntities DBContext = new projectManagemaentEntity.ProjectManagementEntities();
        public UserControl_SelfBoard selfBoard { get; internal set; }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void setup_datails_btnInsert_Click(object sender, RoutedEventArgs e)
        {
            UserControl_Card1 card = new UserControl_Card1();

            var q = DBContext.Employee.Where(n=>n.EmployeeName ==setup_details_assignedName.Text);
            foreach (var x in q)
            {
                projectManagemaentEntity.Tasks tasks = new projectManagemaentEntity.Tasks
                {
                    TaskID = "100",
                    TaskName = setup_details_workName.Text,
                    Description = setup_details_desc.Text,
                    EmployeeID = x.EmployeeID,
                    EndDate = setup_details_datePicker.selectedDate
                };
                DBContext.Tasks.Local.Add(tasks);
            }
           

            card.card_assignedName.Content = setup_details_assignedName.Text;
            card.card_dueDate.Content = setup_details_datePicker.selectedDate;
            card.card_workName.Content = setup_details_workName.Text;

            
            DBContext.SaveChanges();
            selfBoard.C_spContent.Children.Insert(0, card);
            this.Close();
        }
    }
}
