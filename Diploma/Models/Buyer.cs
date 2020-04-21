using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Diploma.Models
{
    public class Buyer
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string Name { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string Surname { get; set; }
        [Required]
        [StringLength(15, MinimumLength = 5)]
        public string PassportId { get; set; }
        public List<Contract> Contracts { get; set; }
    }
}
