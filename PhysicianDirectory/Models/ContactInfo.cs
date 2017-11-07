using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhysicianDirectory.Models
{
    public class ContactInfo
    {
        public ulong Id { get; set; }
        [Required]
        [Display(Name = "Home Address")]
        public string HomeAddress { get; set; }
        [Required]
        [Display(Name = "Home Phone")]
        public ulong HomePhone { get; set; }
        [Required]
        [Display(Name = "Office Address")]
        public string OfficeAddress { get; set; }
        [Required]
        [Display(Name = "Office Phone")]
        public ulong OfficePhone { get; set; }
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        [Required]
        public string EmailAdd { get; set; }
        [Required]
        [Display(Name = "Cellphone Number")]
        public ulong CellphoneNumber { get; set; }
    }
}