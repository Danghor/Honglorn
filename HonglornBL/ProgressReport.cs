namespace HonglornBL
{
    public class ProgressReport
    {
        public byte Percentage { get; set; }
        public string Message { get; set; }
        public bool IsIndeterminate { get; set; }

        internal ProgressReport(byte percentage, string message, bool isIndeterminate)
        {
            Percentage = percentage;
            Message = message;
            IsIndeterminate = isIndeterminate;
        }
    }
}
