using System.Diagnostics.CodeAnalysis;

namespace HonglornBL.Models {
  using System;
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations;
  using System.ComponentModel.DataAnnotations.Schema;
  using System.Data.Entity.Spatial;

  [Table("bjs.courseclassrel")]
  public class courseclassrel {
    [Key]
    [Column(TypeName = "char")]
    [StringLength(3)]
    public string CourseName { get; set; }

    [Column(TypeName = "char")]
    [Required]
    [StringLength(1)]
    public string ClassName { get; set; }

    public virtual _class _class { get; set; }

    [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<studentcourserel> studentcourserel { get; set; }

    [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public courseclassrel() {
      studentcourserel = new HashSet<studentcourserel>();
    }
  }
}