using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUDUsingMVCwithAdoNotNet.Models
{
    public class ComplaintModel
    {
        [Display(Name = "Complaint Type")]
        [Required]
        public string ComplaintType { get; set; }
        [Display(Name = "Complaint Description")]
        [Required]
        public string ComplaintDesc { get; set; }
    }
}