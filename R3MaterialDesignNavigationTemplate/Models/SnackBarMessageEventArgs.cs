namespace R3MaterialDesignNavigationTemplate.Models
{
    public class SnackBarMessageEventArgs(string message) : EventArgs
    {
        public string Message => message;
    }
}
