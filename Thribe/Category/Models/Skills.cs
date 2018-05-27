using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Thribe.Category.Models
{
    public class Skills
    {
        [Key]
        public long SkillId { get; set; }
        public string ServiceId { get; set; }
        public string CategoryId { get; set; }
        public string MySkill { get; set; }
        public DateTime Date { get; set; }
    }
}
