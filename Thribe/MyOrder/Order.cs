using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Thribe.MyOrder
{
    public class Order
    {
        //public int Id { get; set; }
        [Key]
        public long OrderId { get; set; }
        public long JobId { get; set; }
        public string Email { get; set; }
        public long ServiceId { get; set; }
        public double Amount { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public long PaymentId { get; set; }
        public string PaymentStatus { get; set; }
        public bool MultipleItems { get; set; }
        public string OrderStatus { get; set; }
        public DateTime OrderTime { get; set; }
    }
}
