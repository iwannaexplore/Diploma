﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Diploma.Models
{
    public class Degree
    {
        public int Id { get; set; }
        [DisplayName("Имя")]
        public string Name { get; set; }

        [Required]
        [Range(0, 999999.99)]
        [DisplayName("Зарплата")]
        public decimal Salary { get; set; }
        public List<PromotionHistory> PromotionHistories { get; set; }
    }
}
