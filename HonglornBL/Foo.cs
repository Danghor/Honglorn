using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HonglornBL.Models.Entities;

namespace HonglornBL
{
    public class Foo
    {
        public Student Student
        {
            get => default;
            set
            {
            }
        }

        public ICollection<Bar> Bars
        {
            get => default;
            set
            {
            }
        }
    }
}