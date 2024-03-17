using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IPDAL;
using Entities.Entities;
using IPDAL.Repositories;

namespace  IPBLL.Services
{
    public class DoctorService
    {
        readonly DoctorRepository doctorRepository = new DoctorRepository();

        public bool AddDoctor(Doctor doctor)
        {
            try
            {
                doctorRepository.AddDoctor(doctor);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateDoctor(Doctor doctor)
        {
            try
            {
                doctorRepository.UpdateDoctor(doctor);
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
                doctorRepository.DeleteDoctor(doctorId);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
