namespace R3MaterialDesignNavigationTemplate.Models
{
    public class ErrorOccurredEventArgs : EventArgs
    {
        public ErrorOccurredEventArgs(string title, string message) : this(title, message, null)
        {
        }
        public ErrorOccurredEventArgs(string title, string message, Exception? ex)
        {
            this.Title = title;
            this.Message = message;
            this.Exception = ex;
        }
        public string Title { get; }
        public string Message { get; }
        public Exception? Exception { get; }
    }
}