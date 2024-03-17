using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Validations;
using Microsoft.EntityFrameworkCore;

namespace Entities.Entities
{
    public class Prescription
    {
        [Key]
        [Required]
        public int PrescriptionId { get; set; }

          
        [Required]
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [FutureDate]
        public DateTime PrescriptionDate { get; set; }

        [Required]
        [Display(Name = "PrescriptionDetails")]
        [DataType(DataType.Text)]
        [MinLength(1)]
        public string PrescriptionDetails { get; set; }

        [Required]
        [Display(Name = "Dosage")]
        [Range(0.1, 100.0)]
        public decimal Dosage { get; set; }

        [Required]
        [Display(Name = "Frequency")]
        [Range(1, 10)]
        public int Frequency { get; set; }

        [Required]
        [Display(Name = "Duration")]
        [Range(typeof(TimeSpan), "00:00:01", "23:59:59")] 
        public TimeSpan Duration { get; set; }

        //Navigation properties

        [ForeignKey("DoctorId")]
        public Doctor Doctor { get; set; }

        [ForeignKey("PatientId")]
        [DeleteBehavior(DeleteBehavior.NoAction)]
        public Patient Patient { get; set; }

        [ForeignKey("TreatmentId")]
        public Treatment Treatment { get; set; }
    }
}
