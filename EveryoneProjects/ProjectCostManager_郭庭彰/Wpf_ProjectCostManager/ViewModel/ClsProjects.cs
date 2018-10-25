using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Wpf_ProjectCostManager.ViewModel
{
    class ClsProjects
    {
        public string ProjectID {get;set;}
        public string ProjectName { get; set; }
        public string ImagePath { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double Budget { get; set; }
        public double InputHours { get; set; }
        public double RequiredHours { get; set; }
        public string RequiredDepartment { get; set; }
    }
}
