using System.Net.Http;

namespace ODataService.Http
{
    interface IClient
    {
        public HttpResponseMessage Get(string path);
    }
}
