using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IPDAL;
using Entities.Entities;
using IPDAL.Repositories;
using Entities.ViewModels;


namespace IPBLL.Services
{
    public class PatientService
    {
         readonly PatientRepository patientRepository = new PatientRepository();

        public List<PatientsAppointmentsVM> GetPatientsAppointmentsVMs()
        {
            List<PatientsAppointmentsVM> patientsAppointmentsVMs = new List<PatientsAppointmentsVM>();
            List<Patient> patients = patientRepository.GetPatients();
            foreach (var patient in patients)
            {
                PatientsAppointmentsVM patientsAppointmentsVM = new PatientsAppointmentsVM();
                patientsAppointmentsVM.PatientId = patient.PatientId;
                patientsAppointmentsVM.Name = patient.User.Name;
                patientsAppointmentsVM.Email = patient.User.Email;
                patientsAppointmentsVM.Phone = patient.User.Phone;
                patientsAppointmentsVM.DateOfBirth = patient.User.DateOfBirth;
                patientsAppointmentsVM.BloodGroup = patient.BloodGroup;
                patientsAppointmentsVM.Weight = patient.Weight;
                patientsAppointmentsVM.Height = patient.Height;
               patientsAppointmentsVMs.Add(patientsAppointmentsVM);
            }
            return patientsAppointmentsVMs;
        }

         
        public bool AddPatient(PatientsAppointmentsVM patientFormData)
        {
            var patient = new Patient();
           patient.User = new Users();
           patient.User.UserId = patientFormData.UserId;
           patient.User.Name = patientFormData.Name;
           patient.User.Email = patientFormData.Email;
           patient.User.Phone = patientFormData.Phone;
           patient.User.DateOfBirth = patientFormData.DateOfBirth;
           patient.BloodGroup = patientFormData.BloodGroup;
            return patientRepository.AddPatient(patient);
        }

         
        public bool UpdatePatient(PatientsAppointmentsVM patientFormData)
        {
            var patient = new Patient();
            patient.PatientId = patientFormData.PatientId;
            patient.User = new Users();
            patient.User.UserId = patientFormData.UserId;
            patient.User.Name = patientFormData.Name;
            patient.User.Email = patientFormData.Email;
            patient.User.Phone = patientFormData.Phone;
            patient.User.DateOfBirth = patientFormData.DateOfBirth;
            patient.BloodGroup = patientFormData.BloodGroup;
            return patientRepository.UpdatePatient(patient);
        }


        public bool DeletePatient(int patientId)
        {
            try
            {
                patientRepository.DeletePatient(patientId);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
