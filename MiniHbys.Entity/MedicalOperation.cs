using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniHbys.Entity
{
    public class MedicalOperation
    {
        public int MedicalOperationID { get; set; }
        public DateTime? MedicalOperationDate { get; set; }
        public string Notes { get; set; }
        //public ICollection<Inspection> Inspections { get; set; }
    }
}
