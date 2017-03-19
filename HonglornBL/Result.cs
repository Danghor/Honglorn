using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static HonglornBL.Prerequisites;

namespace HonglornBL
{
    public class Result
    {
        public string Surname { get; set; }
        public string Forename { get; set; }
        public ushort Score { get; set; }
        public Certificate Certificate { get; set; }
    }
}
