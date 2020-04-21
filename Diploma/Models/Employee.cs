using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Diploma.Models
{
    public class Employee : IdentityUser<int>
    {
        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string Name { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string Surname { get; set; }
        [Required]
        [Range(0, 999999.99)]
        [Column(TypeName = "money")]
        public decimal Salary { get; set; }
        [Required]
        public DateTime StartDateOfWork { get; set; }
        [Required]
        public DateTime EndDateOfWork { get; set; }
        public List<Contract> Contracts { get; set; }

    }
}
