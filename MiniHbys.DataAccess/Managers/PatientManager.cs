using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using MiniHbys.DataAccess.Abstraction;
using MiniHbys.Entity;
using MiniHbys.Utilities;

namespace MiniHbys.DataAccess.Managers
{
    public class PatientManager : IPatientManager
    {
        public void CreatePatient(Patient patient)
        {
            using (var connection = new SqlConnection(GlobalSettings.ConnectionString))
            {
                connection.Open();
                var commandText = @"INSERT INTO Patient(PatientName,PatientSurname,PatientGender,BloodGroup,BirthDate) VALUES
			(@PatientName,@PatientSurname,@PatientGender,@BloodGroup,@BirthDate)";
                using (var command = new SqlCommand(commandText, connection))
                {
                    command.Parameters.AddWithValue("@PatientName", patient.PatientName);
                    command.Parameters.AddWithValue("@PatientSurname", patient.PatientSurname);
                    command.Parameters.AddWithValue("@PatientGender", patient.PatientGender);
                    command.Parameters.AddWithValue("@BloodGroup", patient.BloodGroup);
                    command.Parameters.AddWithValue("@BirthDate", patient.BirthDate);

                    command.ExecuteNonQuery();
                }
            }
        }
        public List<Patient> ListPatient()
        {
            using (var connection = new SqlConnection(GlobalSettings.ConnectionString))
            {
                connection.Open();
                List<Patient> values = new List<Patient>();
                var commandText = @"Select * from Patient";
                using (var command = new SqlCommand(commandText, connection))
                {
                    SqlDataReader read = command.ExecuteReader();
                    while (read.Read())
                    {
                        Patient p = new Patient();
                        p.PatientID = Convert.ToInt32(read["PatientID"].ToString());
                        p.PatientName = read["PatientName"].ToString();
                        p.PatientSurname = read["PatientSurname"].ToString();
                        p.PatientGender = read["PatientGender"].ToString();
                        p.BloodGroup = read["BloodGroup"].ToString();
                        p.BirthDate = (DateTime)read["BirthDate"];
                        values.Add(p);
                    }
                    read.Close();
                    command.ExecuteNonQuery();
                    return values;
                }
            }
        }
        public bool UpdatePatient(Patient patient)
        {
            using (var connection = new SqlConnection(GlobalSettings.ConnectionString))
            {
                connection.Open();
                var commandText = @"Update Patient set PatientName=@PatientName,PatientSurname=@PatientSurname,
                                    PatientGender=@PatientGender,BloodGroup=@BloodGroup,BirthDate=@BirthDate
                                    where PatientID=@PatientID";
                using (var command = new SqlCommand(commandText, connection))
                {
                    command.Parameters.AddWithValue("@PatientName", patient.PatientName);
                    command.Parameters.AddWithValue("@PatientSurname", patient.PatientSurname);
                    command.Parameters.AddWithValue("@PatientGender", patient.PatientGender);
                    command.Parameters.AddWithValue("@BloodGroup", patient.BloodGroup);
                    command.Parameters.AddWithValue("@BirthDate", patient.BirthDate);
                    command.Parameters.AddWithValue("@PatientID", patient.PatientID);
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }
        public List<Patient> DetailPatient(int id)
        {
            using (var connection = new SqlConnection(GlobalSettings.ConnectionString))
            {
                connection.Open();
                List<Patient> values = new List<Patient>();
                var commandText = @"Select * from Patient where PatientID=@PatientID";
                using (var command = new SqlCommand(commandText, connection))
                {
                    command.Parameters.AddWithValue("@PatientID", id);
                    SqlDataReader read = command.ExecuteReader();
                    while (read.Read())
                    {
                        Patient p = new Patient();
                        p.PatientID = Convert.ToInt32(read["PatientID"].ToString());
                        p.PatientName = read["PatientName"].ToString();
                        p.PatientSurname = read["PatientSurname"].ToString();
                        p.PatientGender = read["PatientGender"].ToString();
                        p.BloodGroup = read["BloodGroup"].ToString();
                        p.BirthDate = (DateTime)read["BirthDate"];
                        values.Add(p);
                    }
                    return values;
                }
            }
        }
        public bool DeletePatient(int id)
        {
            using (var connection = new SqlConnection(GlobalSettings.ConnectionString))
            {
                connection.Open();
                var commandText = @"Delete from Patient where PatientID=@PatientID";
                using (var command = new SqlCommand(commandText, connection))
                {
                    command.Parameters.AddWithValue("@PatientID",id);
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}
