using System.Diagnostics.CodeAnalysis;

namespace HonglornBL.Models {
  using System;
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations;
  using System.ComponentModel.DataAnnotations.Schema;
  using System.Data.Entity.Spatial;

  [Table("bjs.competitiondiscipline")]
  public class competitiondiscipline {
    [Key]
    public Guid PKey { get; set; }

    [Column(TypeName = "enum")]
    [Required]
    [StringLength(65532)]
    public string Type { get; set; }

    [Required]
    [StringLength(45)]
    public string Name { get; set; }

    [Required]
    [StringLength(25)]
    public string Unit { get; set; }

    public bool LowIsBetter { get; set; }

    [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<competitiondisciplinecollection> competitiondisciplinecollection { get; set; }

    [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<competitiondisciplinecollection> competitiondisciplinecollection1 { get; set; }

    [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<competitiondisciplinecollection> competitiondisciplinecollection2 { get; set; }

    [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<competitiondisciplinecollection> competitiondisciplinecollection3 { get; set; }

    [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<competitiondisciplinecollection> competitiondisciplinecollection4 { get; set; }

    [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<competitiondisciplinecollection> competitiondisciplinecollection5 { get; set; }

    [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<competitiondisciplinecollection> competitiondisciplinecollection6 { get; set; }

    [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<competitiondisciplinecollection> competitiondisciplinecollection7 { get; set; }

    [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public competitiondiscipline() {
      competitiondisciplinecollection = new HashSet<competitiondisciplinecollection>();
      competitiondisciplinecollection1 = new HashSet<competitiondisciplinecollection>();
      competitiondisciplinecollection2 = new HashSet<competitiondisciplinecollection>();
      competitiondisciplinecollection3 = new HashSet<competitiondisciplinecollection>();
      competitiondisciplinecollection4 = new HashSet<competitiondisciplinecollection>();
      competitiondisciplinecollection5 = new HashSet<competitiondisciplinecollection>();
      competitiondisciplinecollection6 = new HashSet<competitiondisciplinecollection>();
      competitiondisciplinecollection7 = new HashSet<competitiondisciplinecollection>();
    }
  }
}