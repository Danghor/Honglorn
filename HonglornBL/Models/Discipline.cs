using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HonglornBL.Models {
  public class Discipline {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid PKey { get; set; }

    [Required]
    public Prerequisites.DisciplineType Type { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Unit { get; set; }
  }
}