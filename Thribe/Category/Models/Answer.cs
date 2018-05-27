using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Thribe.Category.Models
{
    public class Answer
    {
        public long AnswerId { get; set; }
        public long QuestionId { get; set; }
        public string Option_A { get; set; }
        public string Option_B { get; set; }
        public string Option_C { get; set; }
        public string Option_D { get; set; }
        public string Option_E { get; set; }
    }
}
