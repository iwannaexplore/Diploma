using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Diploma.Models
{
    public class PromotionHistory
    {
        public int Id { get; set; }
        [DisplayName("Работник")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        [DisplayName("Категория")]
        public int DegreeId { get; set; }
        public Degree Degree { get; set; }
        [DisplayName("Начало работы")]
        public DateTime StartDate { get; set; }
        [DisplayName("Конец работы")]
        public DateTime? EndDate { get; set; }
    }
}
