using System.Diagnostics.CodeAnalysis;

namespace HonglornBL.Models {
  using System;
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations;
  using System.ComponentModel.DataAnnotations.Schema;
  using System.Data.Entity.Spatial;

  [Table("bjs.competitiondisciplinecollection")]
  public class competitiondisciplinecollection {
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

    public virtual competitiondiscipline competitiondiscipline { get; set; }

    public virtual competitiondiscipline competitiondiscipline1 { get; set; }

    public virtual competitiondiscipline competitiondiscipline2 { get; set; }

    public virtual competitiondiscipline competitiondiscipline3 { get; set; }

    public virtual competitiondiscipline competitiondiscipline4 { get; set; }

    public virtual competitiondiscipline competitiondiscipline5 { get; set; }

    public virtual competitiondiscipline competitiondiscipline6 { get; set; }

    public virtual competitiondiscipline competitiondiscipline7 { get; set; }

    [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public competitiondisciplinecollection() {
      classdisciplinerel = new HashSet<classdisciplinerel>();
    }
  }
}