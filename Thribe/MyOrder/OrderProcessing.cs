using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Thribe.MyOrder
{
    public class OrderProcessing
    {
        //public int Id { get; set; }
        [Key]
        public long ProcessingId { get; set; }
        public long OrderId { get; set; }
        public string Detail { get; set; }
        public string Process { get; set; }
        public DateTime Date { get; set; }

    }
}
