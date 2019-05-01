using HonglornBL.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace HonglornBL
{
    public class EvaluationGroup : Entity
    {
        [Required]
        public string Name { get; set; }
    }
}