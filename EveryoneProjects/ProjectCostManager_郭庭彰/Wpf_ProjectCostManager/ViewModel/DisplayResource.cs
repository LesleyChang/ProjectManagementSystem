using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_ProjectCostManager.ViewModel
{
    class DisplayResource
    {
        public int ResourceID { get; set; }
        public string CategoryName { get; set; }
        public string ResourceName { get; set; }
        public string Unit { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public decimal SubTotal { get; set; }
    }
}
