using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diploma.Models
{
    public class House
    {
        public int Id { get; set; }
        public int SellerId { get; set; }
        public string Address { get; set; }
        public List<Contract> Contracts { get; set; }
    }
}
