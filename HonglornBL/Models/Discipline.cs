using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption;

namespace HonglornBL.Models {
  public class Discipline {
    [Key]
    [DatabaseGenerated(None)]
    public Guid PKey { get; set; } = Guid.NewGuid();

    [Required]
    public Prerequisites.DisciplineType Type { get; set; }

    [Required]
    [StringLength(45)]
    public string Name { get; set; }

    [Required]
    [StringLength(25)]
    public string Unit { get; set; }
  }
}