using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HonglornBL.Models.Entities;

namespace HonglornBL
{
    public class Game
    {
        public ICollection<Student> Students
        {
            get => default;
            set
            {
            }
        }

        public ICollection<Discipline> Disciplines
        {
            get => default;
            set
            {
            }
        }
    }
}