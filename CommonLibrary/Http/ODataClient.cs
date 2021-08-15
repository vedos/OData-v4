using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ODataService.Http
{
    class ODataClient: IClient
    {
        private readonly HttpClient client;

        public ODataClient() 
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://services.odata.org");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public HttpResponseMessage Get(string path)
        {
            using (var httpClient = client)
            {
                var request = new HttpRequestMessage(HttpMethod.Get, path);
                var response = httpClient.GetAsync(request.RequestUri.ToString()).Result;
                return response;
            }
        }
    }
}
