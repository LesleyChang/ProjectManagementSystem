using Aga.Controls.Tree;
using ProjectManagementModel;
//using ProjectModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace AddWork.Model
{
    public class ProjectTreeModel : ITreeModel
    {
        ProjectManagementEntities ProjectDBContext = new ProjectManagementEntities();
        private string projectIDTextBox;
        private string projectNameTextBox;

        public ProjectTreeModel()
        {

        }

        public ProjectTreeModel(string projectIDTextBox, string projectNameTextBox)
        {
            this.projectIDTextBox = projectIDTextBox;
            this.projectNameTextBox = projectNameTextBox;
        }

        public bool HasChildren(object parent)//當return true表示還有子項目，會在往下增加階層
        {
            return (parent as ProjectModel).ChildCount > 0;
        }

        IEnumerable ITreeModel.GetChildren(object parent)
        {

            if (parent == null)
            {

                var q = ProjectDBContext.Works.Where(n => n.ProjectID == projectIDTextBox && n.ParentWorkID == null);
                int stepNumber = 1;
                foreach (var x in q)
                {
                    ProjectModel projectModel = new ProjectModel
                    {
                        ChildCount = ProjectDBContext.Works.Where(n => n.ParentWorkID == x.WorkID).Count(),
                        TaskCount = ProjectDBContext.Tasks.Where(n => n.WorkID == x.WorkID).Count(),
                        Step = stepNumber.ToString(),
                        EmployeeID = x.Employee.EmployeeName,
                        WorkID = x.WorkID,
                        Name = x.WorkName,                       
                        WorkEstStartDate = x.WorkEstStartDate.Value.ToShortDateString(),
                        WorkEstEndDate = x.WorkEstEndDate.Value.ToShortDateString(),
                        WorkStartDate = x.WorkStartDate.Value.ToShortDateString(),
                        WorkEndDate = x.WorkEndDate.Value.ToShortDateString(),
                        WorkStatusID = x.Status.StatusName
                    };
                    stepNumber++;
                    yield return projectModel;
                }

            }
            else 
            {
                ProjectModel subprojectModel = parent as ProjectModel;
                var q = ProjectDBContext.Works.Where(n => n.ParentWorkID == subprojectModel.WorkID);

                int stepNumber = 1;
                foreach (var x in q)
                {
                    ProjectModel projectModel = new ProjectModel
                    {
                        ChildCount = ProjectDBContext.Works.Where(n => n.ParentWorkID == x.WorkID).Count(),
                        TaskCount = ProjectDBContext.Tasks.Where(n => n.WorkID == x.WorkID).Count(),
                        Step = subprojectModel.Step + "." + stepNumber.ToString(),
                        EmployeeID = x.Employee.EmployeeName,
                        WorkID = x.WorkID,
                        Name = x.WorkName,
                        ParentWorkID = (int)x.ParentWorkID,
                        WorkEstStartDate = x.WorkEstStartDate.Value.ToShortDateString(),
                        WorkEstEndDate = x.WorkEstEndDate.Value.ToShortDateString(),
                        WorkStartDate = x.WorkStartDate.Value.ToShortDateString(),
                        WorkEndDate = x.WorkEndDate.Value.ToShortDateString(),
                        WorkStatusID = x.Status.StatusName

                    };
                    stepNumber++;
                    yield return projectModel;
                }

            }
            
        }
    }
    public class ProjectModel
    {
        public int ChildCount { get; set; }
        public int TaskCount { get; set; }
        public string Step { get; set; }
        public string ProjectID { get; set; }
        public string EmployeeID { get; set; }
        public int ParentWorkID { get; set; }
        public int WorkID { get; set; }
        public string Name { get; set; }
        public string WorkEstStartDate { get; set; }
        public string WorkEstEndDate { get; set; }
        public string WorkStartDate { get; set; }
        public string WorkEndDate { get; set; }
        public string Description { get; set; }
        public string WorkStatusID { get; set; }
    }
   
}
