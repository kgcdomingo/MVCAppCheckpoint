using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhysicianDirectory.Models
{
    public class Physician
    {
        public ulong Id { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Birth Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime BirthDate { get; set; }
    
        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Display(Name = "Weight")]
        public int Weight { get; set; }

        [Display(Name = "Height")]
        public int Height { get; set; }
        public ContactInfo ContactInfo { get; set; }
        public Specialization Specialization { get; set; }
    }
    

}