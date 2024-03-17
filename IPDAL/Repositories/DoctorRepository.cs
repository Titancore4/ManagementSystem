using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Entities;
using Entities.Context;

namespace IPDAL.Repositories
{ 
    public class DoctorRepository
    { 
        PatientsAppointmentsContext patientsAppointmentsContext = new PatientsAppointmentsContext();

 
        public bool AddDoctor(Doctor doctorFormData)
        {
            try
            {
                patientsAppointmentsContext.Doctors.Add(doctorFormData);
                patientsAppointmentsContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

 
        public bool UpdateDoctor(Doctor doctorFormData)
        {
            try
            {
                Doctor doctor = patientsAppointmentsContext.Doctors.Where(d => d.DoctorId == doctorFormData.DoctorId).FirstOrDefault();
                doctor.Specialization = doctorFormData.Specialization;
                patientsAppointmentsContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        
        
        public bool DeleteDoctor(int doctorId)
        {
            try
            {
                Doctor doctor = patientsAppointmentsContext.Doctors.Where(d => d.DoctorId == doctorId).FirstOrDefault();
                patientsAppointmentsContext.Doctors.Remove(doctor);
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
