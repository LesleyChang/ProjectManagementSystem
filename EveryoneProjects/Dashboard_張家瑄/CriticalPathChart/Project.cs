using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace CriticalPathChart
{
    public class Project
    {
        public Project(Tasks tasksFromDB)
        {
            this.TasksFromDB = tasksFromDB;
            GenerateTasksCollection();
            SetTasksLocation();
            GeneratePathLines();
            GeneratePathCollection();//ToDo
            
        }

        public void GeneratePathLines()
        {
            Tasks _task0 = new Tasks();
            Tasks _task1 = new Tasks();
            PathLines = new List<Line>();

            //lines connected StartBlock
            var q1 = TasksFromDB.Items.Where(t => t.Predecessors == null);
            foreach (var task in q1)
            {
                Line line = new Line()
                {
                    StrokeThickness = 1,
                    Stroke = new SolidColorBrush(Colors.DarkGray),
                    X1 = StartPoint.X,
                    Y1 = StartPoint.Y,
                    X2 = task.CanvasLeft,
                    Y2 = task.CanvasTop + 25
                };

                PathLines.Add(line);
            }

            //lines connected EndBlock
            var q2 = TasksFromDB.Items.Where(t => t.Predecessors != null);
            foreach (var task in q2)
            {
                foreach (var p in task.Predecessors)
                {
                    _task0.Items.Add(p);
                }
            }
            var q3 = q2.Except(_task0.Items);
            foreach (var task in q3)
            {
                Line line = new Line()
                {
                    StrokeThickness = 1,
                    Stroke = new SolidColorBrush(Colors.DarkGray),
                    X1 = task.CanvasLeft + 80,
                    Y1 = task.CanvasTop +25,
                    X2 = EndPoint.X,
                    Y2 = EndPoint.Y
                };

                PathLines.Add(line);
            }
                        
            _task0 = new Tasks();
            _task1 = new Tasks();
            var q4 = TasksFromDB.Items.Where(t => t.Predecessors != null);
            foreach (var task in q4)
            {
                foreach (var predecessor in task.Predecessors)
                {
                    Line line = new Line()
                    {
                        StrokeThickness = 1,
                        Stroke = new SolidColorBrush(Colors.DarkGray),
                        X1 = predecessor.CanvasLeft + 80,
                        Y1 = predecessor.CanvasTop + 25,
                        X2 = task.CanvasLeft,
                        Y2 = task.CanvasTop +25
                    };

                    PathLines.Add(line);
                }
            } 

        }

        private void SetTasksLocation()
        {
            int _top;
            int _left = 150;    //offset
            for (int i = 0; i < TasksCollection.Count; i++)
            {
                _top = (i % 2 == 0) ? 80 : 100;

                for (int j = 0; j < TasksCollection[i].Items.Count; j++)
                {
                    TasksCollection[i].Items[j].CanvasTop = _top;
                    TasksCollection[i].Items[j].CanvasLeft = _left;
                    _top += 100;
                }
                _left += 150;
            }
        }

        private void GeneratePathCollection()
        {
            var _tasks0 = new Tasks();
            var _tasks1 = new List<Tasks>();
            var _predecessors = new Tasks();
            int count = 0;

            var q1 = TasksFromDB.Items.Where(t => t.Predecessors == null);
            foreach (var task in TasksFromDB.Items)
            {
                task.DurationSum = task.Duration;
            }
            count += q1.Count();

            while (count < TasksFromDB.Items.Count)
            {
                var q2 = TasksFromDB.Items.Where(t => t.Predecessors != null);
                foreach (var task in q2)
                {
                    foreach (var p in _predecessors.Items.OrderByDescending(p => p.Duration))
                    {
                        if (task.Predecessors.Contains(p))
                        {
                            task.DurationSum += p.DurationSum;
                            break;
                        }
                    }
                    _tasks0.Items.Add(task);
                }
                _predecessors = new Tasks();
                foreach (var item in _tasks0.Items)
                {
                    _predecessors.Items.Add(item);
                    count++;
                }
            }
            
            
        }

        private void GenerateTasksCollection()
        {
            TasksCollection = new List<Tasks>();
            var _predecessors = new Tasks();
            Tasks _task0 = new Tasks();
            Tasks _task1 = new Tasks();

            var q1 = TasksFromDB.Items.Where(w => w.Predecessors == null);
            foreach (var item in q1)
            {
                _task0.Items.Add(item);
                _predecessors.Items.Add(item);
            }
            TasksCollection.Add(_task0);
            //set Task without predecedors in TasksCollection[0], _predecessors


            while (_predecessors.Items.Count() < TasksFromDB.Items.Count)
            {
                var q2 = TasksFromDB.Items.Where(w => w.Predecessors != null).AsEnumerable();
                _task0 = new Tasks();
                foreach (var w in q2)
                {
                    if (w.Predecessors.Except(_predecessors.Items.AsEnumerable()).Count() == 0)
                    {
                        _task0.Items.Add(w);
                    }
                }
                var q3 = _task0.Items.Except(_predecessors.Items);
                _task1 = new Tasks();
                foreach (var item in q3)
                {
                    _task1.Items.Add(item);
                }

                TasksCollection.Add(_task1);

                foreach (var item in _task1.Items)
                {
                    _predecessors.Items.Add(item);
                }
            }
        }

        public List<Tasks> TasksCollection { get; set; }
        public List<Tasks> PathCollection { get; set; }
        public Tasks TasksFromDB { get; set; }
        public List<Line> PathLines { get; set; }
        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }
        public string Name { get; set; }
    }
}
