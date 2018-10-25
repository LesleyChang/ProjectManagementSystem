using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriticalPathChart
{
    public class Tasks 
    {
        public Tasks()
        {
            Items = new List<Task>();
        }
        public List<Task> Items { get; set; }
                
    }
    
}
