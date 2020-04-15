using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diploma.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PassportNum { get; set; }
        public List<House> Houses { get; set; }
        public List<Contract> Contacts { get; set; }
    }
}
