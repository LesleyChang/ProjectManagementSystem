using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_ProjectCostManager.ViewModel
{
    class ClsTaskResource
    {
        public string TaskID { get; set; }
        public int ResourceID { get; set; }
        public string Unit { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
    }
}
