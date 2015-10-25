using System.Diagnostics.CodeAnalysis;

namespace HonglornBL.Models {
  using System;
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations;
  using System.ComponentModel.DataAnnotations.Schema;
  using System.Data.Entity.Spatial;

  [Table("bjs.traditionaldiscipline")]
  public class traditionaldiscipline {
    [Key]
    public Guid PKey { get; set; }

    [Column(TypeName = "enum")]
    [Required]
    [StringLength(65532)]
    public string Type { get; set; }

    [Column(TypeName = "enum")]
    [Required]
    [StringLength(65532)]
    public string Sex { get; set; }

    [Required]
    [StringLength(45)]
    public string Name { get; set; }

    [Column(TypeName = "char")]
    [Required]
    [StringLength(1)]
    public string UnitSymbol { get; set; }

    public int? Distance { get; set; }

    public float? Overhead { get; set; }

    public float ConstantA { get; set; }

    public float ConstantC { get; set; }

    [Column(TypeName = "enum")]
    [StringLength(65532)]
    public string Measurement { get; set; }

    [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<traditionaldisciplinecollection> traditionaldisciplinecollection { get; set; }

    [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<traditionaldisciplinecollection> traditionaldisciplinecollection1 { get; set; }

    [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<traditionaldisciplinecollection> traditionaldisciplinecollection2 { get; set; }

    [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<traditionaldisciplinecollection> traditionaldisciplinecollection3 { get; set; }

    [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<traditionaldisciplinecollection> traditionaldisciplinecollection4 { get; set; }

    [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<traditionaldisciplinecollection> traditionaldisciplinecollection5 { get; set; }

    [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<traditionaldisciplinecollection> traditionaldisciplinecollection6 { get; set; }

    [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<traditionaldisciplinecollection> traditionaldisciplinecollection7 { get; set; }

    [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public traditionaldiscipline() {
      traditionaldisciplinecollection = new HashSet<traditionaldisciplinecollection>();
      traditionaldisciplinecollection1 = new HashSet<traditionaldisciplinecollection>();
      traditionaldisciplinecollection2 = new HashSet<traditionaldisciplinecollection>();
      traditionaldisciplinecollection3 = new HashSet<traditionaldisciplinecollection>();
      traditionaldisciplinecollection4 = new HashSet<traditionaldisciplinecollection>();
      traditionaldisciplinecollection5 = new HashSet<traditionaldisciplinecollection>();
      traditionaldisciplinecollection6 = new HashSet<traditionaldisciplinecollection>();
      traditionaldisciplinecollection7 = new HashSet<traditionaldisciplinecollection>();
    }
  }
}