using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Diploma.Models
{
    public class House
    {
        public int Id { get; set; }
        [Required]
        public int SellerId { get; set; }
        public Seller Seller { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string Address { get; set; }
        public List<Contract> Contracts { get; set; }
    }
}
