using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Entities;
using Entities.Context;
using Entities.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace IPDAL.Repositories
{
    public class PatientRepository
    {

        PatientsAppointmentsContext patientsAppointmentsContext = new PatientsAppointmentsContext();


        public List<Patient> GetPatients()
        {

            return patientsAppointmentsContext.Patients
                  .Include("User") // Specify the navigation property string directly
                  .ToList();
        }

           
        public bool AddPatient(Patient patientFormData)
        {
            try
            {
                patientsAppointmentsContext.Patients.Add(patientFormData);
                patientsAppointmentsContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
         
        public bool UpdatePatient(Patient patientFormData)
        {
            try
            {
                Patient patient = patientsAppointmentsContext.Patients.Where(p => p.PatientId == patientFormData.PatientId).First();
                patient.User = patientFormData.User;
                patient.User.UserId = patientFormData.User.UserId;
                patient.User.Name = patientFormData.User.Name;
                patient.User.Email = patientFormData.User.Email;
                patient.User.Phone = patientFormData.User.Phone;
                patient.User.DateOfBirth = patientFormData.User.DateOfBirth;
                patient.BloodGroup = patientFormData.BloodGroup;
                patient.Weight = patientFormData.Weight;
                patient.Height = patientFormData.Height;
                patientsAppointmentsContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

 
        public bool DeletePatient(int patientId)
        {
            try
            {
              Patient patient = patientsAppointmentsContext.Patients.Where(p => p.PatientId == patientId).First();
                patientsAppointmentsContext.Patients.Remove(patient);
                patientsAppointmentsContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
