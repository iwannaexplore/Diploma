using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Diploma.Models
{
    public class Employee: IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<Contract> Contracts { get; set; }
    }
}
