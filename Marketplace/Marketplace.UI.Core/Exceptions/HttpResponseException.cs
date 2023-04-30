namespace Marketplace.UI.Core.Exceptions
{
    public class HttpResponseException : Exception
    {
        public HttpResponseException(string message)
            : base(message)
        {
        }
    }
}