using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Diploma.Models
{
    public class Contract
    {
        public int Id { get; set; }
        public ContractType ContractType { get; set; }
        public int ContractTypeId { get; set; }
        [Column(TypeName = "money")]
        [Required]
        [Range(1, 99999999.99, ErrorMessage = "Please enter a value bigger than {1}")]
        public decimal Price { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Seller Seller { get; set; }
        [Required]
        public int SellerId { get; set; }
        public Buyer Buyer { get; set; }
        public int? BuyerId { get; set; }
        public House House { get; set; }
        [Required]
        public int HouseId { get; set; }
        public Employee Employee { get; set; }
        [Required]
        public int EmployeeId { get; set; }
    }
}
