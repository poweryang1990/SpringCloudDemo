using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace EurekaClient.Net.Transport
{
    public class EurekaHttpResponse
    {
        public HttpStatusCode StatusCode { get; private set; }

        public HttpResponseHeaders Headers { get; set; }

        public Uri Location { get; set; }

        public EurekaHttpResponse(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
        }
    }

    public class EurekaHttpResponse<T> : EurekaHttpResponse
    {
        public T Response { get; private set; }

        public EurekaHttpResponse(HttpStatusCode statusCode, T response)
            : base(statusCode)
        {
            Response = response;
        }
    }
}
