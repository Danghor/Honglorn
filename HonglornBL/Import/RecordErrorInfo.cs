using System.Collections.Generic;

namespace HonglornBL.Import
{
    public class RecordErrorInfo
    {
        public ICollection<FieldErrorInfo> FieldErrorInfos { get; }

        internal RecordErrorInfo(ICollection<FieldErrorInfo> fieldErrorInfos)
        {
            FieldErrorInfos = fieldErrorInfos;
        }
    }
}

