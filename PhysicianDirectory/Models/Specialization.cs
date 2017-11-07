using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhysicianDirectory.Models
{
    public class Specialization
    {
        public ulong Id { get; set; }

        [Required]
        [Display(Name = "Specialization")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }
    }
}