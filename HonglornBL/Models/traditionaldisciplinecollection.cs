using System.Diagnostics.CodeAnalysis;

namespace HonglornBL.Models {
  using System;
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations;
  using System.ComponentModel.DataAnnotations.Schema;
  using System.Data.Entity.Spatial;

  [Table("bjs.traditionaldisciplinecollection")]
  public class traditionaldisciplinecollection {
    [Key]
    public Guid PKey { get; set; }

    public Guid MaleSprintPKey { get; set; }

    public Guid MaleJumpPKey { get; set; }

    public Guid MaleThrowPKey { get; set; }

    public Guid MaleMiddleDistancePKey { get; set; }

    public Guid FemaleSprintPKey { get; set; }

    public Guid FemaleJumpPKey { get; set; }

    public Guid FemaleThrowPKey { get; set; }

    public Guid FemaleMiddleDistancePKey { get; set; }

    [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<classdisciplinerel> classdisciplinerel { get; set; }

    public virtual traditionaldiscipline traditionaldiscipline { get; set; }

    public virtual traditionaldiscipline traditionaldiscipline1 { get; set; }

    public virtual traditionaldiscipline traditionaldiscipline2 { get; set; }

    public virtual traditionaldiscipline traditionaldiscipline3 { get; set; }

    public virtual traditionaldiscipline traditionaldiscipline4 { get; set; }

    public virtual traditionaldiscipline traditionaldiscipline5 { get; set; }

    public virtual traditionaldiscipline traditionaldiscipline6 { get; set; }

    public virtual traditionaldiscipline traditionaldiscipline7 { get; set; }

    [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public traditionaldisciplinecollection() {
      classdisciplinerel = new HashSet<classdisciplinerel>();
    }
  }
}