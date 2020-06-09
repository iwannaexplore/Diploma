using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("Имя")]
        public string Name { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 5)]
        [DisplayName("Фамилия")]
        public string Surname { get; set; }
        public List<Contract> Contracts { get; set; }
        public List<PromotionHistory> PromotionHistories { get; set; }
    }
}
