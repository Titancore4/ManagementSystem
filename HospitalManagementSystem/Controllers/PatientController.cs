using Entities.ViewModels;
using IPBLL.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
            // Log the weight of the patient as JSON to the console
            Console.WriteLine(JsonConvert.SerializeObject(patient.Weight));

            // Call the patientService to add the patient
            var result = patientService.AddPatient(patient);

            // Return the result as JSON
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
