using System.Collections.Generic;

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

