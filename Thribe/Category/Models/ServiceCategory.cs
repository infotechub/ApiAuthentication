using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Thribe.Category.Models
{
    public class ServiceCategory
    {

        [Key]
        public long CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool MutipleItems { get; set; }
        public long ServiceId { get; set; }
        public string ServiceType { get; set; }
        public string Service { get; set; }
        public decimal Charge { get; set; }
        public string Items { get; set; }

        public DateTime Date { get; set; }



    }
}
