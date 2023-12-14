using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniHbys.Business.Abstraction;
using MiniHbys.DataAccess.Abstraction;
using MiniHbys.DataAccess.Managers;
using MiniHbys.Entity;
using MiniHbys.Utilities;

namespace MiniHbys.Business.Services
{
	public class PatientService : IPatientService
	{
		private readonly IPatientManager _patientManager;
		public PatientService(IPatientManager patientmanager)
		{ 
			_patientManager = patientmanager;
		}
		
		public void CreatePatient(Patient patient)
		{
			_patientManager.CreatePatient(patient);
		}

        public List<Patient> GetAllPatients()
        {
            return _patientManager.ListPatient();
        }
		public bool UpdatePatient(Patient patient)
		{
			return _patientManager.UpdatePatient(patient);
		}
		public List<Patient> DetailPatientByID(int id)
		{
			return _patientManager.DetailPatient(id);
		}
        public bool DeletePatient(int id)
        {
            return _patientManager.DeletePatient(id);
        }
    }
}
