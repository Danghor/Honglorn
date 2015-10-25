using System.Diagnostics.CodeAnalysis;

namespace HonglornBL.Models {
  using System;
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations;
  using System.ComponentModel.DataAnnotations.Schema;
  using System.Data.Entity.Spatial;

  [Table("bjs.class")]
  public class _class {
    [Key]
    [Column(TypeName = "char")]
    [StringLength(1)]
    public string Name { get; set; }

    [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<classdisciplinerel> classdisciplinerel { get; set; }

    [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<courseclassrel> courseclassrel { get; set; }

    [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public _class() {
      classdisciplinerel = new HashSet<classdisciplinerel>();
      courseclassrel = new HashSet<courseclassrel>();
    }
  }
}