using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Entities.Entities
{
    public class Treatment
    {
        [Key]
        [Required]
        public int TreatmentId { get; set; }

        //Treatment name
        [Required]
        [Display(Name = "Treatment")]
        [DataType(DataType.Text)]
        public string TreatmentName { get; set; }

        [Required]
        [Display(Name = "Description")]
        [DataType(DataType.Text)]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Cost")]
        [DataType(DataType.Currency)]
        public decimal Cost { get; set; }

        [Required]
        [Display(Name = "Duration")]
        [DataType(DataType.Duration)]
        public TimeSpan Duration { get; set; }
    }
}
