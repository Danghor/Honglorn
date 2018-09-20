namespace HonglornBL.Import
{
    public class FieldErrorInfo
    {
        public string FieldName { get; }
        public string FieldContent { get; }
        public string Message { get; }

        public FieldErrorInfo(string fieldName, string fieldContent, string message)
        {
            FieldName = fieldName;
            FieldContent = fieldContent;
            Message = message;
        }
    }
}
