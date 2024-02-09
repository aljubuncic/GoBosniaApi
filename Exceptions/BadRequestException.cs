using System.Net;

namespace GoTravnikApi.Exceptions
{
    public class BadRequestException : ApplicationException
    {
        public BadRequestException(string message) : base(HttpStatusCode.BadRequest, message)
        {
        }
    }
}
