using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HonglornBL.Import
{
    class RecordErrorInfo
    {
        internal ICollection<FieldErrorInfo> FieldErrorInfos { get; }

        public RecordErrorInfo(ICollection<FieldErrorInfo> fieldErrorInfos)
        {
            FieldErrorInfos = fieldErrorInfos;
        }
    }
}

