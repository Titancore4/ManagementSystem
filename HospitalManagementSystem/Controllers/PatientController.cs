using Entities.Entities;
using Entities.ViewModels;
using IPBLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.Controllers
{
    public class PatientController : Controller
    {

       PatientService patientService = new PatientService();
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetPatients()
        {
            var patients = patientService.GetPatientsAppointmentsVMs();
            return Json(patients);
        }

        
        [HttpGet]
        public IActionResult GetPatientById(int id)
        {
            var patient = patientService.GetPatientsAppointmentsVMs().Where(p => p.PatientId == id).FirstOrDefault();

            return Json(patient);
        }
         
        [HttpPost]
        public async Task<IActionResult> RegisterPatient([FromBody] PatientsAppointmentsVM patient)
        {
            var result = patientService.AddPatient(patient);
            return Json(result);
        }

     
        [HttpPost]
        public IActionResult UpdatePatient([FromBody] PatientsAppointmentsVM patient)
        {
            var result = patientService.UpdatePatient(patient);
            return Json(result);
        }
 
        [HttpPost]
        public IActionResult DeletePatient(int id)
        {
            var result = patientService.DeletePatient(id);
            return Json(result);
        }


    }
}
