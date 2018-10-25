using ProjectManagementModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using PMEntityModel;

namespace Wpf_ProjectCostManager.ViewModel
{
    class ClsPageViewModel : INotifyPropertyChanged
    {
        //public List<SeriesData> Series { get; set; }
        public List<ClsCost> Costs { get; set; }
        public double TotalInput;

        ProjectManagementEntities dbContext = new ProjectManagementEntities();

        public ClsPageViewModel(string ProjectID)
        {
            var q = from p in dbContext.Project
                     join w in dbContext.Works on p.ProjectID equals w.ProjectID
                     join t in dbContext.Tasks on w.WorkID equals t.WorkID
                     join tr in dbContext.TaskResource on t.TaskID equals tr.TaskID
                     join c in dbContext.ResourceCategory on tr.CategoryID equals c.CategoryID
                     where p.ProjectID == ProjectID
                     group tr by c.CategoryName into g
                     select new { Category = g.Key, Group = g };

            Costs = new List<ClsCost>();

            foreach (var cat in q.ToList())
            {
                decimal subtotal = 0;
                foreach(var data in cat.Group)
                {
                    subtotal += data.Quantity * data.UnitPrice;
                }
                Costs.Add(new ClsCost { Category = cat.Category, Number = subtotal });
            }

            foreach(var data in Costs)
            {
                TotalInput += (double)data.Number;
            }

            //Series = new List<SeriesData>();

            //Series.Add(new SeriesData { DisplayName = "Costs", Items = Costs});

            //foreach (var data in Series)
            //{
            //    foreach (var c in data.Items)
            //    {
            //        TotalInput += (double)c.Number;
            //    }
            //}
        }

        private object selectedItem = null;
        public object SelectedItem
        {
            get
            {
                return selectedItem;
            }
            set
            {
                selectedItem = value;
                NotifyPropertyChanged("SelectedItem");
            }
        }

        private void NotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(property));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

    }
}
