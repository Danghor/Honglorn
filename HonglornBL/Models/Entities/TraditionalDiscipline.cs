using System.ComponentModel.DataAnnotations;

namespace HonglornBL.Models.Entities {
  public class TraditionalDiscipline : Discipline {
    [Required]
    public Prerequisites.Sex Sex { get; set; }

    public short? Distance { get; set; }

    public float? Overhead { get; set; }

    public float ConstantA { get; set; }

    public float ConstantC { get; set; }

    public Prerequisites.Measurement? Measurement { get; set; }
  }
}