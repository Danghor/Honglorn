using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HonglornBL.Models.Entities
{
    public class Discipline : IEntity<IDisciplineModel>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid PKey { get; set; } = Guid.NewGuid();

        public string Name { get; set; }

        public void AdoptValues(IDisciplineModel model)
        {
            Name = model.Name;
        }
    }
}