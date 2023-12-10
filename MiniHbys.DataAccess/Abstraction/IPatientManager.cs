using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniHbys.Entity;

namespace MiniHbys.DataAccess.Abstraction
{
	public interface IPatientManager
	{
		void CreatePatient(Patient patient);
        List<Patient> ListPatient();
		bool UpdatePatient(Patient patient);
		List<Patient> DetailPatient(int id);
		bool DeletePatient(int id);
	}
}
