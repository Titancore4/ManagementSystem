using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class Appointment
    {

        [Key]
        [Column(Order = 1)]
        [Required]
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public DateTime AppointmentDate { get; set; }

        //Navigation properties
        [Key]
        [ForeignKey("DoctorId")]
        [Column(Order = 2)]
        public Doctor Doctor { get; set; } //Shadow property 

        [Key]
        [ForeignKey("PatientId")]
        [Column(Order = 3)]
        [DeleteBehavior(DeleteBehavior.NoAction)]
        public Patient Patient { get; set; }
    }
}
