using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Diploma.Models
{
    public class Contract
    {
        public int Id { get; set; }
        public string Type { get; set; }
        [Column(TypeName = "money")]
        public decimal Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Seller Seller { get; set; }
        public int SellerId { get; set; }
        public Buyer Buyer { get; set; }
        public int? BuyerId { get; set; }
        public House House { get; set; }
        public int HouseId { get; set; }
        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }
    }
}
