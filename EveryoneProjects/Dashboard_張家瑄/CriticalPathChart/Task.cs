using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriticalPathChart
{
    public class Task
    {
        public Task()
        {
            //this.Duration = End.Subtract(Start);
        }
        public string Name { get; set; }
        public string Index { get; set; }
        //private TimeSpan duration;
        //public TimeSpan Duration { get { return duration;  } set { duration = value; } }
        //public DateTime Start { get; set; }
        //public DateTime End { get; set; }
        public int Duration { get; set; }
        public int DurationSum { get; set; }
        public List<Task> Predecessors { get; set; }
        public int CanvasTop { get; set; }
        public int CanvasLeft { get; set; }


    }
}
