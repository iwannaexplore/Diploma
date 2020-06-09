using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Diploma.Models
{
    public class ContractType
    {
        public int Id { get; set; }
        [DisplayName("Тип контракта")]
        public string Type { get; set; }
        public IList<Contract> Contracts { get; set; }
    }
}
