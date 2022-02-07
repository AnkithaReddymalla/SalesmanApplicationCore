using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SalesmanApplicationCore.Models
{
    public class Salesman
    {
        [Key]
        public decimal salesman_id { get; set; }
        public string name { get; set; }
        public string city { get; set; }
        public decimal commission { get; set; }
    }
}
