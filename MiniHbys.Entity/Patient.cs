using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniHbys.Entity
{
	public class Patient
	{
        public int PatientID { get; set; }
        public string PatientName { get; set; }
        public string PatientSurname { get; set; }
        public string PatientGender { get; set; }
        public string BloodGroup { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}
