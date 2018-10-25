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

using System.Collections.ObjectModel;
using Aga.Controls.Tree;
using System.Collections;
using Microsoft.Win32;
//using ProjectModel;
using System.Globalization;
using AddWork.Model;
using ProjectManagementModel;

namespace AddWork
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class AddWorkPage : Window
    {
        ProjectManagementEntities ProjectDBContext = new ProjectManagementEntities();
        public AddWorkPage()
        {
            InitializeComponent();
            LoadDeptTreeView();
            LoadComboBox();
            
        }



        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ColumnClear();
        }
        private void LoadDeptTreeView()
        {
            DeptTreeView.Items.Clear();
            var q = ProjectDBContext.Project.GroupBy(n => n.Department.DepartmentName);
            foreach (var dept in q)
            {
                TreeViewItem x = new TreeViewItem();
                x.Header = dept.Key;
                DeptTreeView.Items.Add(x);
                foreach (var projects in dept)
                {
                    TreeViewItem y = new TreeViewItem();
                    y.Header = projects.ProjectName;
                    y.Selected += Y_Selected;
                    x.Items.Add(y);
                }
            }

        }
        private void LoadComboBox()
        {
            var q = ProjectDBContext;
            foreach (var x in q.ProjectCategory)
            {
                ComboBoxItem item = new ComboBoxItem() { Content = x.ProjectCategoryName, Tag = x.ProjectCategoryID };
                projectCategoryIDComboBox.Items.Add(item);
            }

            foreach (var x in q.Status.Where(n => n.StatusCategoryID == "Project"))
            {
                ComboBoxItem item = new ComboBoxItem() { Content = x.StatusName, Tag = x.StatusID };
                projectStatusIDComboBox.Items.Add(item);
            }
            foreach (var x in q.Department)
            {
                ComboBoxItem item = new ComboBoxItem() { Content = x.DepartmentName, Tag = x.DepartmentID };
                inChargeDeptIDComboBox.Items.Add(item);
            }
            foreach (var x in q.Department)
            {
                ComboBoxItem item = new ComboBoxItem() { Content = x.DepartmentName, Tag = x.DepartmentID };
                requiredDeptIDComboBox.Items.Add(item);
            }
            foreach (var x in q.Employee)
            {
                ComboBoxItem item = new ComboBoxItem() { Content = x.EmployeeName, Tag = x.EmployeeID };
                requiredDeptPMIDComboBox.Items.Add(item);
            }
            foreach (var x in q.Employee)
            {
                ComboBoxItem item = new ComboBoxItem() { Content = x.EmployeeName, Tag = x.EmployeeID };
                inChargeDeptPMIDComboBox.Items.Add(item);
            }
            foreach (var x in q.Employee)
            {
                ComboBoxItem item = new ComboBoxItem() { Content = x.EmployeeName, Tag = x.EmployeeID };
                projectSupervisorIDComboBox.Items.Add(item);
            }
            //==============================================================================================
            foreach (var x in q.Employee)
            {
                ComboBoxItem item = new ComboBoxItem() { Content = x.EmployeeName, Tag = x.EmployeeID };
                InputEmployeeID.Items.Add(item);
            }

            foreach (var x in q.Status.Where(n => n.StatusCategoryID == "Works"))
            {
                ComboBoxItem item = new ComboBoxItem() { Content = x.StatusName, Tag = x.StatusID };
                InputWorkStatusID.Items.Add(item);
            }

            InputWorkStartDate.Text = DateTime.Now.ToShortDateString();
            InputWorkEndDate.Text = DateTime.Now.ToShortDateString();
            InputWorkEstStartDate.Text = DateTime.Now.ToShortDateString();
            InputWorkEstEndDate.Text = DateTime.Now.ToShortDateString();

        }
        private void Y_Selected(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.TreeViewItem selectprojectname = sender as System.Windows.Controls.TreeViewItem;
            var q = ProjectDBContext.Project.Where(n => n.ProjectName == selectprojectname.Header.ToString());
            foreach (var project in q)
            {
                projectIDTextBox.Text = project.ProjectID;
                projectNameTextBox.Text = project.ProjectName;
                projectCategoryIDComboBox.Text = project.ProjectCategory.ProjectCategoryName;
                projectSupervisorIDComboBox.Text = project.Employee.EmployeeName;
                projectStatusIDComboBox.Text = project.Status.StatusName;
                requiredDeptIDComboBox.Text = project.Department.DepartmentName;
                requiredDeptPMIDComboBox.Text = project.Employee.EmployeeName;
                startDateTextBox.Text = project.StartDate.ToString();
                endDateTextBox.Text = project.EndDate.ToString();
                estStartDateTextBox.Text = project.EstStartDate.ToString();
                estEndDateTextBox.Text = project.EstEndDate.ToString();
                inChargeDeptIDComboBox.Text = project.Department.DepartmentName;
                inChargeDeptPMIDComboBox.Text = project.Employee.EmployeeName;
                isGeneralManagerConcernedCheckBox.IsChecked = project.IsGeneralManagerConcerned;
            }

            treelist1.Model = new ProjectTreeModel(projectIDTextBox.Text, projectNameTextBox.Text);
        }
        private void AddProject()
        {

            ProjectManagementModel.Project project = new ProjectManagementModel.Project()

            {
                ProjectID = projectIDTextBox.Text,
                ProjectName = projectNameTextBox.Text,
                ProjectCategoryID = (int)((ComboBoxItem)projectCategoryIDComboBox.SelectedItem).Tag,
                ProjectSupervisorID = (int)((ComboBoxItem)projectSupervisorIDComboBox.SelectedItem).Tag,
                ProjectStatusID = (int)((ComboBoxItem)projectStatusIDComboBox.SelectedItem).Tag,
                RequiredDeptID = (int)((ComboBoxItem)requiredDeptIDComboBox.SelectedItem).Tag,
                RequiredDeptPMID = (int)((ComboBoxItem)requiredDeptPMIDComboBox.SelectedItem).Tag,
                StartDate = DateTime.Parse(startDateTextBox.Text),
                EndDate = DateTime.Parse(endDateTextBox.Text),
                EstStartDate = DateTime.Parse(estStartDateTextBox.Text),
                EstEndDate = DateTime.Parse(estEndDateTextBox.Text),
                InChargeDeptID = (int)((ComboBoxItem)inChargeDeptIDComboBox.SelectedItem).Tag,
                InChargeDeptPMID = (int)((ComboBoxItem)inChargeDeptPMIDComboBox.SelectedItem).Tag,
                IsGeneralManagerConcerned = isGeneralManagerConcernedCheckBox.IsChecked,

            };
            ProjectDBContext.Project.Local.Add(project);
        }
        private void UpdateProject()
        {
            var q = ProjectDBContext.Project.Find(projectIDTextBox.Text);
            q.ProjectID = projectIDTextBox.Text;
            q.ProjectName = projectNameTextBox.Text;
            q.ProjectCategoryID = (int)((ComboBoxItem)projectCategoryIDComboBox.SelectedItem).Tag;
            q.ProjectSupervisorID = (int)((ComboBoxItem)projectSupervisorIDComboBox.SelectedItem).Tag;
            q.ProjectStatusID = (int)((ComboBoxItem)projectStatusIDComboBox.SelectedItem).Tag;
            q.RequiredDeptID = (int)((ComboBoxItem)requiredDeptIDComboBox.SelectedItem).Tag;
            q.RequiredDeptPMID = (int)((ComboBoxItem)requiredDeptPMIDComboBox.SelectedItem).Tag;
            q.StartDate = DateTime.Parse(startDateTextBox.Text);
            q.EndDate = DateTime.Parse(endDateTextBox.Text);
            q.EstStartDate = DateTime.Parse(estStartDateTextBox.Text);
            q.EstEndDate = DateTime.Parse(estEndDateTextBox.Text);
            q.InChargeDeptID = (int)((ComboBoxItem)inChargeDeptIDComboBox.SelectedItem).Tag;
            q.InChargeDeptPMID = (int)((ComboBoxItem)inChargeDeptPMIDComboBox.SelectedItem).Tag;
            q.IsGeneralManagerConcerned = isGeneralManagerConcernedCheckBox.IsChecked;
        }
        private void DeleteProject()
        {
            var q = ProjectDBContext.Project.Where(n => n.ProjectID == projectIDTextBox.Text);
            if (q.Count() > 0)
            {
                if (q != null)
                {
                    var works = ProjectDBContext.Works.Where(n => n.ProjectID == projectIDTextBox.Text);
                    foreach (var x in works)
                    {
                        ProjectDBContext.Works.Remove(x);
                    }

                    ProjectDBContext.Project.Remove(q.First());
                    ProjectDBContext.SaveChanges();

                }

            }
        }
        private void ColumnClear()
        {
            projectIDTextBox.Text = "";

            projectNameTextBox.Text = "請輸入";
            projectCategoryIDComboBox.SelectedIndex = 0;
            projectSupervisorIDComboBox.SelectedIndex = 0;
            projectStatusIDComboBox.SelectedIndex = 0;
            requiredDeptIDComboBox.SelectedIndex = 0;
            requiredDeptPMIDComboBox.SelectedIndex = 0;
            startDateTextBox.Text = DateTime.Now.ToShortDateString();
            endDateTextBox.Text = DateTime.Now.ToShortDateString();
            estStartDateTextBox.Text = DateTime.Now.ToShortDateString();
            estEndDateTextBox.Text = DateTime.Now.ToShortDateString();
            inChargeDeptIDComboBox.SelectedIndex = 0;
            inChargeDeptPMIDComboBox.SelectedIndex = 0;
            isGeneralManagerConcernedCheckBox.IsChecked = false;
        }
        private void SaveMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (projectIDTextBox.Text != "")
            {
                var q = ProjectDBContext.Project.Find(projectIDTextBox.Text);
                if (q == null)
                {
                    AddProject();
                }
                else
                {
                    UpdateProject();
                }
                ProjectDBContext.SaveChanges();
                LoadDeptTreeView();
            }

        }
        private void DeleteMenuItem_Click(object sender, RoutedEventArgs e)
        {
            DeleteProject();
            LoadDeptTreeView();
            ColumnClear();
            treelist1.Model = new ProjectTreeModel(projectIDTextBox.Text, projectNameTextBox.Text);
        }
        private void AddProjectButton_Click(object sender, RoutedEventArgs e)
        {
            LoadDeptTreeView();
            ColumnClear();
            var q = ProjectDBContext.Project.Select(n => n.ProjectID);
            List<int> ID = new List<int>();
            foreach (var x in q)
            {
                ID.Add(int.Parse(x.Substring(1, 5)));
            }
            projectIDTextBox.Text = "P" + DateTime.Now.Year.ToString().Substring(2, 2) + (ID.Max() + 1).ToString().Substring(2, 3);
            treelist1.Model = null;
        }
       
        private void AddWorksMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (projectIDTextBox.Text == "" || projectIDTextBox.Text == null)
            {
            }
            else
            {
                if (treelist1.SelectedNode != null)
                {
                    int nextWorkID = ProjectDBContext.Works.Select(n => n.WorkID).Max();
                    ProjectManagementModel.Works p = new ProjectManagementModel.Works()
                    {
                        WorkName = InputWorkName.Text,
                        WorkID = ++nextWorkID,
                        ParentWorkID = (treelist1.SelectedNode.Tag as AddWork.Model.ProjectModel).WorkID,
                        ProjectID = projectIDTextBox.Text,
                        EmployeeID = (int)((ComboBoxItem)InputEmployeeID.SelectedItem).Tag,
                        WorkEstStartDate = DateTime.Parse(InputWorkEstStartDate.Text),
                        WorkEstEndDate = DateTime.Parse(InputWorkEstEndDate.Text),
                        WorkStartDate = DateTime.Parse(InputWorkStartDate.Text),
                        WorkEndDate = DateTime.Parse(InputWorkEndDate.Text),
                        WorkStatusID = (int)((ComboBoxItem)InputWorkStatusID.SelectedItem).Tag
                    };
                    ProjectDBContext.Works.Local.Add(p);
                    ProjectDBContext.SaveChanges();
                    treelist1.Model = new ProjectTreeModel(projectIDTextBox.Text, projectNameTextBox.Text);
                }
                else
                {
                    int nextWorkID = ProjectDBContext.Works.Select(n => n.WorkID).Max();
                    ProjectManagementModel.Works p = new ProjectManagementModel.Works()
                    {
                        WorkName = InputWorkName.Text,
                        WorkID = ++nextWorkID,
                        ProjectID = projectIDTextBox.Text,
                        EmployeeID = (int)((ComboBoxItem)InputEmployeeID.SelectedItem).Tag,
                        WorkEstStartDate = DateTime.Parse(InputWorkEstStartDate.Text),
                        WorkEstEndDate = DateTime.Parse(InputWorkEstEndDate.Text),
                        WorkStartDate = DateTime.Parse(InputWorkStartDate.Text),
                        WorkEndDate = DateTime.Parse(InputWorkEndDate.Text),
                        WorkStatusID = (int)((ComboBoxItem)InputWorkStatusID.SelectedItem).Tag
                    };
                    ProjectDBContext.Works.Local.Add(p);
                    ProjectDBContext.SaveChanges();
                    treelist1.Model = new ProjectTreeModel(projectIDTextBox.Text, projectNameTextBox.Text);
                }
            }            
        }
        private void RemoveWorkMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (treelist1.SelectedNode != null)
            {
                int workID = (treelist1.SelectedNode.Tag as AddWork.Model.ProjectModel).WorkID;
                var childCount = ProjectDBContext.Works.Where(n => n.ParentWorkID == workID);
                if (childCount.Count() > 0)
                {
                    if (MessageBox.Show("確定刪除含有子項的工作?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                    {
                        return;
                    }
                    else
                    {
                        foreach (var x in childCount)
                        {
                            ProjectDBContext.Works.Remove(x);
                        }
                        var q = ProjectDBContext.Works.Where(n => n.WorkID == workID).First();
                        ProjectDBContext.Works.Remove(q);
                        ProjectDBContext.SaveChanges();
                        treelist1.Model = new ProjectTreeModel(projectIDTextBox.Text, projectNameTextBox.Text);

                    }

                }
                else
                {
                    var q = ProjectDBContext.Works.Where(n => n.WorkID == workID).First();
                    ProjectDBContext.Works.Remove(q);
                    ProjectDBContext.SaveChanges();
                    treelist1.Model = new ProjectTreeModel(projectIDTextBox.Text, projectNameTextBox.Text);

                }
            }
        }
    }
}

public class Project
{
    public string Step { get; set; }
    public string Name { get; set; }
    public string Kind { get; set; }
    public string Data { get; set; }
}

