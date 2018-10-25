using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_ProjectCostManager.ViewModel
{
    public class SeriesData
    {
        public string DisplayName { get; set; }

        public string Description { get; set; }

        public List<ClsCost> Items { get; set; }
    }

    public class ClsCost
    {
        public string ProjectID { get; set; }

        public string Category { get; set; }

        private decimal _number = 0;
        public decimal Number
        {
            get
            {
                return _number;
            }
            set
            {
                _number = value;
                if (PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("Number"));
                }
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}