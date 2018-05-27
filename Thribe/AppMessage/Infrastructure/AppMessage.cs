using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Thribe.AppMessage.Infrastructure
{
    public class AppMessages
    {
        [Key]
        public long MessageId { get; set; }
        //Email or Username of the user sending the message
        public string Sender { get; set; }
        //Email or UserName of the user receiving the message
        public string Receiver { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public string Status { get; set; }
        public DateTime? Date { get; set; }

    }
}
