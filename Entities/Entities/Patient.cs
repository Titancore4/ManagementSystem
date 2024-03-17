using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class Patient
    {
        [Key]
        [Required]
        public int PatientId { get; set; }


        [Required]
        [ForeignKey("UserId")]
        public Users User { get; set; }

        [Required]
        [Display(Name = "Blood Group")]
        [DataType(DataType.Text)]
        public string BloodGroup { get; set; }

        [Required]
        [Display(Name = "Weight")]
        public double Weight { get; set; }


        [Required]
        [Display(Name = "Height")]
        public double Height { get; set; }

    }
}