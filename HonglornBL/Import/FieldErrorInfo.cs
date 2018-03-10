namespace HonglornBL.Import
{
    class FieldErrorInfo
    {
        string FieldName { get; }
        string FieldContent { get; }
        string Message { get; }

        public FieldErrorInfo(string fieldName, string fieldContent, string message)
        {
            FieldName = fieldName;
            FieldContent = fieldContent;
            Message = message;
        }
    }
}
