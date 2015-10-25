using System.Diagnostics.CodeAnalysis;

namespace HonglornBL.Models {
  using System;
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations;
  using System.ComponentModel.DataAnnotations.Schema;
  using System.Data.Entity.Spatial;

  [Table("bjs.student")]
  public class student {
    [Key]
    public Guid PKey { get; set; }

    [Required]
    [StringLength(45)]
    public string Surname { get; set; }

    [Required]
    [StringLength(45)]
    public string Forename { get; set; }

    [Column(TypeName = "enum")]
    [Required]
    [StringLength(65532)]
    public string Sex { get; set; }

    [Column(TypeName = "year")]
    public short YearOfBirth { get; set; }

    [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<competition> competition { get; set; }

    [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<studentcourserel> studentcourserel { get; set; }

    [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public student() {
      competition = new HashSet<competition>();
      studentcourserel = new HashSet<studentcourserel>();
    }
  }
}