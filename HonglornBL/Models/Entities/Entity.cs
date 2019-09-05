using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace HonglornBL.Models.Entities
{
    public abstract class Entity : NotifyPropertyChangedInformer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid PKey { get; internal set; } = Guid.NewGuid();
    }
}
