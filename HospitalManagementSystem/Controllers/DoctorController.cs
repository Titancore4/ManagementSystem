using Entities.Entities;
using IPBLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.Controllers
{
    public class DoctorController : Controller
    {
        readonly DoctorService doctorService = new DoctorService();

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegisterDoctor([FromBody] Doctor doctor)
        {
            var result = doctorService.AddDoctor(doctor);
            return Json(result);
        }
    }
}
