using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Thribe.MyOrder
{
    public class Location
    {
        // public int Id { get; set; }
        [Key]
        public long LocationId { get; set; }
        public Job JobId { get; set; }
        public string Email{ get; set; }
        public string VendorLocation { get; set; }
        public DateTime DateTime { get; set; }
    }
}
