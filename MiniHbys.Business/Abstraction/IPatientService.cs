using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniHbys.Entity;

namespace MiniHbys.Business.Abstraction
{
	public interface IPatientService
	{
		void CreatePatient(Patient patient);
		List<Patient> GetAllPatients();
		bool UpdatePatient(Patient patient);
		List<Patient> DetailPatientByID(int id);
		bool DeletePatient(int id);
    }
}
