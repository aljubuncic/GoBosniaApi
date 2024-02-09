using System.Net;

namespace GoTravnikApi.Exceptions
{
    public class InternalServerErrorException : ApplicationException
    {
        public InternalServerErrorException(string message) : base(HttpStatusCode.InternalServerError, message)
        {
        }
    }
}
