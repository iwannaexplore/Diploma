using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Diploma.Models
{
    public class Employee : IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        [Column(TypeName = "money")]
        public decimal Salary { get; set; }
        public DateTime StartDateOfWork { get; set; }
        public DateTime EndDateOfWork { get; set; }
        public List<Contract> Contracts { get; set; }

    }
}
