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
        private readonly PatientRepository patientRepository;

        public PatientService()
        {
            patientRepository = new PatientRepository();
        }

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
                //Console.WriteLine(patientsAppointmentsVM);
            }

            return patientsAppointmentsVMs;
        }

        public bool AddPatient(PatientsAppointmentsVM patientFormData)
        {
            if (patientFormData == null)
            {
                throw new ArgumentNullException(nameof(patientFormData), "Patient data cannot be null");
            }

            var patient = new Patient
            {
                User = new Users
                {
                    UserId = patientFormData.UserId,
                    Name = patientFormData.Name,
                    Email = patientFormData.Email,
                    Phone = patientFormData.Phone,
                    DateOfBirth = patientFormData.DateOfBirth
                },
                BloodGroup = patientFormData.BloodGroup,
                Weight = patientFormData.Weight,
                Height = patientFormData.Height
            };
            return patientRepository.AddPatient(patient);
        }

        public bool UpdatePatient(PatientsAppointmentsVM patientFormData)
        {
            if (patientFormData == null)
            {
                throw new ArgumentNullException(nameof(patientFormData), "Patient data cannot be null");
            }

            var patient = new Patient
            {
                PatientId = patientFormData.PatientId,
                User = new Users
                {
                    UserId = patientFormData.UserId,
                    Name = patientFormData.Name,
                    Email = patientFormData.Email,
                    Phone = patientFormData.Phone,
                    DateOfBirth = patientFormData.DateOfBirth
                },
                BloodGroup = patientFormData.BloodGroup,
                Weight = patientFormData.Weight,
                Height = patientFormData.Height
            };
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
