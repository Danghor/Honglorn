namespace HonglornBL.Models {
  using System;
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations;
  using System.ComponentModel.DataAnnotations.Schema;
  using System.Data.Entity.Spatial;

  [Table("bjs.classdisciplinerel")]
  public class classdisciplinerel {
    [Key]
    [Column(Order = 0, TypeName = "char")]
    [StringLength(1)]
    public string ClassName { get; set; }

    [Key]
    [Column(Order = 1, TypeName = "year")]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public short Year { get; set; }

    public Guid? CompetitionDisciplineCollectionPKey { get; set; }

    public Guid? TraditionalDisciplineCollectionPKey { get; set; }

    public virtual _class _class { get; set; }

    public virtual competitiondisciplinecollection competitiondisciplinecollection { get; set; }

    public virtual traditionaldisciplinecollection traditionaldisciplinecollection { get; set; }
  }
}