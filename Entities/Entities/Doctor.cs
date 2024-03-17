using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class Doctor
    {
        [Key]
        [Required]
        public int DoctorId { get; set; }

        [Required]
        [ForeignKey("UserId")]
        public Users User { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Specialization")]
        [DataType(DataType.Text)]
        public string Specialization { get; set; }
    }
}
