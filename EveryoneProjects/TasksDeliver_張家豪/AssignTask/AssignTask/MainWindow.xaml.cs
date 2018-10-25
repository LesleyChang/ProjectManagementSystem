using AssignTask._1.AlterWPF;
using AssignTask.MyUserControl;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AssignTask
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class TaskAssignPage : Window
    {
        public TaskAssignPage()
        {
            InitializeComponent();
            FillPMProject();
            FillTeamMember(); //加入此專案的TeamMember                    
            this.taskListBox1.SelectedIndex = 1;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        ProjectManagementModel.ProjectManagementEntities DbContext = new ProjectManagementModel.ProjectManagementEntities();
        private void FillPMProject()　
        {
            var q = from p in this.DbContext.Project
                    select p.ProjectName;
            foreach (var item in q.ToList())
            {
                this.ownerprojectlist.Items.Add(item);
            }           
            this.ownerprojectlist.SelectionChanged+=(sender,args)=> FillTask(sender);
            this.ownerprojectlist.SelectedIndex = 0;
        }
       
        private void FillTask(object sender)　//加入每個Package的工作項目
        {
            Storyboard sb = (Storyboard)this.Resources["sb1"];
            sb.Begin();
            menuFlag = true;
            this.projectTextBlock.Text = ((ListBox)sender).SelectedItem.ToString();
            this.taskListBox1.Items.Clear();//ToDo
            var q = from p in this.DbContext.Tasks
                    where p.Works.Project.ProjectName == ((ListBox)sender).SelectedItem.ToString()
                    select p;

            foreach (var taskitem in q.ToList())
            {
                ImageBrush myBrush = new ImageBrush();
                myBrush.ImageSource = new BitmapImage(new Uri("http://www.zaarapp.com/assets/images/Task.PNG", UriKind.Absolute));
                //myBrush.ImageSource = new BitmapImage(new Uri(@"\2.Image\Task.PNG", UriKind.Relative));
                DockPanel dp = new DockPanel();
                Image task = new Image { Width = 30, Height = 30, Margin = new Thickness(2), Source = myBrush.ImageSource };
                Label taskTitle = new Label { Width = 100, Height = 30, Content = taskitem.TaskName };
                dp.Tag = taskTitle.Content; //tag for taskListBox1_SelectionChanged
                dp.Children.Add(task);
                dp.Children.Add(taskTitle);
                this.taskListBox1.Items.Add(dp);
            }
        }

        private void FillTeamMember()
        {
            var q = from p in this.DbContext.Employee
                    select p;

            foreach (var empitems in q.ToList())
            {
                //image之後放員工照片
                Label teamMember = new Label { Width = 60, Height = 70, AllowDrop = true, Content = empitems.EmployeeName, Foreground = new SolidColorBrush(Colors.HotPink) };
                ImageBrush ib = new ImageBrush(); //ToDo 之後加入員工
                ib.ImageSource = new BitmapImage(new Uri(@"https://upload.wikimedia.org/wikipedia/commons/thumb/7/7e/Circle-icons-profile.svg/1024px-Circle-icons-profile.svg.png", UriKind.Absolute));
                //ib.ImageSource = new BitmapImage(new Uri(@"\Image\Task.PNG", UriKind.Relative));
                teamMember.Background = ib;
                teamMember.HorizontalAlignment = HorizontalAlignment.Left;
                teamMember.VerticalAlignment = VerticalAlignment.Bottom;
                teamMember.Margin = new Thickness(5);
                teamMember.Drop += TeamMember_Drop;
                teamMember.MouseDown += TeamMember_MouseDown1;
                teamMember.Tag = empitems.EmployeeName; //Todo 有資料庫之後可能要改(取得員工姓名)
                this.teamMemberWrapPanel.Children.Add(teamMember);
            }
        }


        private void TeamMember_MouseDown1(object sender, MouseButtonEventArgs e)
        {
            var q = from p in this.DbContext.Employee
                    where p.EmployeeName == ((Label)sender).Tag.ToString()
                    select p;

            foreach (var item in q.ToList())
            {
                this.Opacity = 0.5;
                EmployeeDetail employeeDetail = new EmployeeDetail { Height = this.Height - 50,Owner = this.Owner, usEmployeeName = ((Label)sender).Tag + "" };
                employeeDetail.employeePic.Background = ((Label)sender).Background;
                employeeDetail.employeeName.Content = ((Label)sender).Tag;//ToDo var q 從employeeName找出員工基本資料(部門、工號)                                        
                employeeDetail.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                employeeDetail.employeeID.Content = item.EmployeeID;
                employeeDetail.employeeSkill.Content = "A"; //ToDo
                employeeDetail.Title = ((Label)sender).Tag + " 的基本資料";
                employeeDetail.Closed += delegate (object sender_eD, EventArgs e_eD)
                {
                    this.Opacity = 1;
                };
                employeeDetail.ShowDialog();
            }
        }

        private void TeamMember_Drop(object sender, DragEventArgs e)
        {
            DragSender.IsEnabled = false;
            DragSender.Foreground = new SolidColorBrush(Colors.Red);
            DragSender.FontSize = 13;

            try
            {
                var q = DbContext;
                foreach (var taskitem in q.Tasks.Where(n => n.TaskName == DragSender.Content.ToString()))
                {
                    foreach (var employeeitem in q.Employee.Where(n => n.EmployeeName == ((Label)sender).Tag.ToString()))
                {
                    //Label lbl = new Label { Content = DragSender.Content};
                    this.dataGrid1.Items.Add(new MyItem
                    {
                        EmployeeName = ((Label)sender).Tag + "",
                        Task = DragSender.Content + "",
                        Desc = taskitem.Description,                       
                        EmployeeID = employeeitem.EmployeeID,
                        Dep = employeeitem.Department.DepartmentName,
                    });
                }
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            this.gridLabel1.Visibility = Visibility.Hidden;
        }

        private void taskListBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (((ListBox)sender).Items[0].ToString() != "工作項目") //Todo Delete
            //{
                try
                {
                    //ToDo Desc Change 作業描述選取後變更

                    this.taskRunInTitle.Content = ((DockPanel)this.taskListBox1.SelectedItems[0]).Tag;
                    var q = from p in this.DbContext.Tasks
                            where p.TaskName == this.taskRunInTitle.Content.ToString()
                            select p;
                    foreach (var descitem in q.ToList())
                    {
                        this.taskDesc.Text = descitem.Description;
                    }
                }
                catch { }
            //}
        }
        bool menuFlag;
        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (menuFlag != true)
            {
                Storyboard sb = (Storyboard)this.Resources["sb1"];
                sb.Begin();
                menuFlag = true;
            }
            else
            {
                Storyboard sb = (Storyboard)this.Resources["sb2"];
                sb.Begin();
                menuFlag = false;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var q = from p in this.DbContext.Employee
                    select p;

            if (mainWindow2.Children.Count <= 5)
            {
                Label remarkLabel = new Label { Height = 30, Width = 463, Content = "備註" };
                ComboBox cb = new ComboBox { Height = 30, Width = 300, Margin = new Thickness(5), SelectedIndex = 0 };
                TextBox remarkTextBox = new TextBox { Height = 100, Width = 400, Background = new SolidColorBrush(Colors.White), Margin = new Thickness(5) };
                foreach (var item in q.ToList())
                {
                    cb.Items.Add(item.EmployeeName);
                }

                cb.SelectionChanged += delegate (object sender_cb, SelectionChangedEventArgs e__cb)
                {
                    try
                    {
                        var q2 = from p in this.DbContext.Tasks
                                 where p.Employee.EmployeeName == ((ComboBox)sender_cb).Text
                                 select p;

                        foreach (var item2 in q2.ToList())
                        {
                            item2.Tag = remarkTextBox.Text;
                        }
                        this.DbContext.SaveChanges();
                        remarkTextBox.Text = null;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                };
                this.mainWindow2.Children.Add(remarkLabel);
                this.mainWindow2.Children.Add(cb);
                this.mainWindow2.Children.Add(remarkTextBox);
            }
        }

        Label DragSender;
        private void DragActivityName(object sender, MouseButtonEventArgs e)
        {
            DragSender = (Label)sender;
            try
            {
                Label lbl = (Label)sender;
                DragDrop.DoDragDrop(lbl, lbl.Content, DragDropEffects.Copy);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            #region A.dataGrid To Excel Method
            if (this.gridLabel1.Visibility == Visibility.Visible) return;
            try
            {
                this.dataGrid1.SelectAllCells();
                this.dataGrid1.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
                ApplicationCommands.Copy.Execute(null, this.dataGrid1);
                String resultat = (string)Clipboard.GetData(DataFormats.CommaSeparatedValue);
                String result = (string)Clipboard.GetData(DataFormats.Text);
                this.dataGrid1.UnselectAllCells();
                StreamWriter file1 = new StreamWriter(@"D:\工作分配.xls", false, Encoding.Default);
                file1.WriteLine(result.Replace(',', ' '));
                file1.Close();
                MessageBox.Show("輸出Excel成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            #endregion
        }

        #region MouseMoveEnterClickEvent
        private void menuImg1_MouseEnter(object sender, MouseEventArgs e)
        {
            this.menuImg1.Opacity = 0.5;
        }

        private void menuImg1_MouseLeave(object sender, MouseEventArgs e)
        {
            this.menuImg1.Opacity = 1;
        }

        private void homeImg1_MouseEnter(object sender, MouseEventArgs e)
        {
            this.homeImg1.Opacity = 0.5;
        }

        private void homeImg1_MouseLeave(object sender, MouseEventArgs e)
        {
            this.homeImg1.Opacity = 1;
        }

        private void workLoadingImg1_MouseEnter(object sender, MouseEventArgs e)
        {
            this.workLoadingImg1.Opacity = 0.5;
        }

        private void workLoadingImg1_MouseLeave(object sender, MouseEventArgs e)
        {
            this.workLoadingImg1.Opacity = 1;
        }
        #endregion

        private void dataGrid1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (this.dataGrid1.SelectedItem != null)
                {
                    for (var i = 0; i < this.taskListBox1.Items.Count; i++)
                    {
                        var taskListBox = this.taskListBox1.Items[i] as DockPanel;
                        string delLabel = ((Label)taskListBox.Children[1]).Content.ToString();
                        if (delLabel == ((MyItem)this.dataGrid1.SelectedItem).Task)
                        {
                            ((DockPanel)this.taskListBox1.Items[i]).Children[1].IsEnabled = true;
                            ((Label)((DockPanel)this.taskListBox1.Items[i]).Children[1]).Foreground = new SolidColorBrush(Colors.Black);
                        }
                    }
                    this.dataGrid1.Items.Remove((MyItem)this.dataGrid1.SelectedItem);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void Button_Click_2(object sender, RoutedEventArgs e) //Finish
        {
            if (this.gridLabel1.Visibility == Visibility.Visible) return;
            try
            {
                for (int i = 0; i < this.dataGrid1.Items.Count; i++)
                {
                    string taskword = ((MyItem)this.dataGrid1.Items[i]).Task;
                    var q = (from task in this.DbContext.Tasks
                             where task.TaskName == taskword
                             select task).FirstOrDefault();

                    int EmpID = ((MyItem)this.dataGrid1.Items[i]).EmployeeID;
                    q.EmployeeID = EmpID;
                    this.DbContext.SaveChanges();
                }
                MessageBox.Show("分配完成");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void Button_Click_3(object sender, RoutedEventArgs e) // Reassign
        {
            for (int i = 0; i < this.taskListBox1.Items.Count; i++)
            {
                var taskListBox = this.taskListBox1.Items[i] as DockPanel;
                ((Label)taskListBox.Children[1]).IsEnabled = true;
                ((Label)taskListBox.Children[1]).Foreground = new SolidColorBrush(Colors.Black);
            }
            this.dataGrid1.Items.Clear();
            this.gridLabel1.Visibility = Visibility.Visible; //MyrefForIf          
        }
        private void workLoadingImg1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            WorkLoadDetail wld = new WorkLoadDetail {Owner = this.Owner};
            wld.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            wld.Title = "員工工作狀態";
            wld.ShowDialog();
        }
    }
}






