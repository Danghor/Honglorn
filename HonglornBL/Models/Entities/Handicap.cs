using HonglornBL.MasterData.Handicap;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace HonglornBL.Models.Entities
{
    public class Handicap : IEntity<IHandicapModel>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid PKey { get; set; } = Guid.NewGuid();

        [Required]
        [Index(IsUnique = true)]
        [StringLength(5)]
        public string Name { get; set; }

        [XmlIgnore]
        public virtual ICollection<StudentHandicap> StudentHandicaps { get; set; }

        public void AdoptValues(IHandicapModel model)
        {
            Name = model.Name;
        }
    }
}