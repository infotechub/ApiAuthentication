using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Thribe.MyOrder
{
    public class Job
    {
        // public int Id { get; set; }
        [Key]
        public long JobId { get; set; }
        public string Email { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public string Status { get; set; }
        public DateTime RegistrationDate { get; set; }

    }
}
