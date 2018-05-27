using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Thribe.AppSupport.Infrastructure
{
    public class Support
    {

        public long SupportId { get; set; }
        //Email or Username of the user sending the message
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public string Status { get; set; }
        public DateTime? Date { get; set; }

    }
}
