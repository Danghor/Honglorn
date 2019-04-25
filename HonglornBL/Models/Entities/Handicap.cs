using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HonglornBL.Models.Entities
{
    public class Handicap : Entity
    {
        [Required]
        [Index(IsUnique = true)]
        [StringLength(5)]
        public string Name { get; set; }
    }
}