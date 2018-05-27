using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Thribe.Category.Models
{
    public class GetQuestion
    {
        [Key]
        public long QuestionId { get; set; }
        public string Question { get; set; }
        public string QuestionIconUrl { get; set; }
        public long QuestionNaireId { get; set; }
        public long QuestionTypeId { get; set; }
        public long QuestionOptionTypeId { get; set; }
        public string QuestionOptionTypeName { get; set; }
        public string QuestionTypeName { get; set; }
        public long ServiceItemId { get; set; }
        public string Options { get; set; }
        public long QuestionOptionId { get; set; }
        public string QuestionOptionName { get; set; }
        public long QuestionOptionSortOrder { get; set; }
        public string QuestionOptionCode { get; set; }
        public string QuestionOptionUrl { get; set; }
        public string QuestionOptionIconUrl { get; set; }
        public long ServiceQuestionId { get; set; }
        public string AssociatedPrice { get; set; }
        public bool Active { get; set; }

    }
}
