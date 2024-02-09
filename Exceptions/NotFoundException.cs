using System.Net;

namespace GoTravnikApi.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string message) : base(HttpStatusCode.NotFound, message)
        {
        }
    }
}
