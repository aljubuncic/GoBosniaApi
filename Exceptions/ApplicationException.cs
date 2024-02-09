using System.Net;

namespace GoTravnikApi.Exceptions
{
    public class ApplicationException : Exception
    {
        public HttpStatusCode HttpStatusCode { get; }
        public ApplicationException(HttpStatusCode httpStatusCode, string message) : base(message) 
        {
            HttpStatusCode = httpStatusCode;    
        }
    }
}
