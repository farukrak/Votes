using Microsoft.AspNetCore.Identity;
using Votes.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Votes.Models
{
    public class Employee : IdentityUser
    {
        [StringLength(50, MinimumLength = 1)]
        [Display(Name = " First Name ")]
        public string FirstName { get; set; }

        [StringLength(50, MinimumLength = 1)]
        [Display(Name = " Last Name ")]
        public string LastName { get; set; }

        [Display(Name = "Email")]
        [StringLength(100, MinimumLength = 2)]
        [EmailAddress]
        [Key] 
        public override string Email { get; set; }
        [Display(Name = " Average Score")]
        public virtual List<Score> Scores { get; set; }
    }
}
//PassW1!
