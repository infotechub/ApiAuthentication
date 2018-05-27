using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Thribe.Category.Models
{
    public class UserSelection
    {
        public long UserSelectionId { get; set; }
        public string Email{ get; set; }
        // public string UserName { get; set; }
        public long QuestionId { get; set; }
        public string ServiceQuestion { get; set; }
        public string UserAnswer { get; set; }
        public DateTime Date { get; set; }
    }
}
