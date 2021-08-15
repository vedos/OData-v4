using ODataService.Http;
using ODataService.Models;
using ODataService.Services.Interfaces;
using Newtonsoft.Json;

namespace ODataService.Services
{
    public class TripPinRESTierService: ITripPinRESTierService
    {
        private readonly string path = "/TripPinRESTierService";

        public string getPath() { return path; }

        public Result<People> getPeople()
        {
            var client = new ODataClient();

            var response = client.Get(getPath() + "/People");

            Result<People> result = new Result<People>();
            if (response.IsSuccessStatusCode)
            {
                result = JsonConvert.DeserializeObject<Result<People>>(response.Content.ReadAsStringAsync().Result.Replace(@"\", ""));
            }

            return result;
        }
    }
}
