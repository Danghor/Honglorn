using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HonglornBL.Models {
  public class Student {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid PKey { get; set; }

    [Required]
    [StringLength(45)]
    public string Surname { get; set; }

    [Required]
    [StringLength(45)]
    public string Forename { get; set; }

    [Required]
    public Prerequisites.Sex Sex { get; set; }

    [Required]
    public short YearOfBirth { get; set; }

    public virtual ICollection<Competition> Competition { get; set; }

    public Student() {
      Competition = new HashSet<Competition>();
    }
  }
}