using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Thribe.MyOrder
{
    public class PromoCode
    {
        // public int Id { get; set; }
        [Key]
        public long Code { get; set; }
        public string PromoNumber { get; set; }
        public decimal Percent { get; set; }
        public string Status { get; set; }
        public string StartDate { get; set; }
        public string ExpiryDate { get; set; }
        public DateTime EntryDate { get; set; }

    }
}
