using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModels
{
    /// <summary>
    /// This class will be used to create a view model for the patients appointments, will use Appointments.cs, Patients.cs, Treatments.cs, Prescriptions.cs, Users.cs, and Doctors.cs
    /// </summary>
    public class PatientsAppointmentsVM
    {
        public int PatientId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string BloodGroup { get; set; }

        public double Weight { get; set; }

        public double Height { get; set; }
    }         
}
