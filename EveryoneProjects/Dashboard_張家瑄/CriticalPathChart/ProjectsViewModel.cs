using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriticalPathChart
{
    public class ProjectsViewModel
    {
        public ProjectsViewModel()
        {
            ProjectItems = new List<Project>();
        }
        public List<Project> ProjectItems { get; set; }
    }
    
}
