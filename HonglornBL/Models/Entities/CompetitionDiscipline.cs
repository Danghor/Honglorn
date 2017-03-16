using System.ComponentModel.DataAnnotations;

namespace HonglornBL.Models.Entities
{
    public class CompetitionDiscipline : Discipline
    {
        /// <summary>
        ///     Indicates whether a lower value in this discipline indicates a better performance of the student.
        /// </summary>
        /// <remarks>
        ///     Primarily used for running disciplines, where less time is better.
        /// </remarks>
        [Required]
        public bool LowIsBetter { get; set; }
    }
}