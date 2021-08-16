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

            if (response.IsSuccessStatusCode)
            {
                Result<People> result = JsonConvert.DeserializeObject<Result<People>>(response.Content.ReadAsStringAsync().Result);
                return result;
            }
            
            return null;
        }

        public People getUser(string user)
        {
            var client = new ODataClient();

            var response = client.Get(getPath() + "/People" + "('" + user + "')");

            if (response.IsSuccessStatusCode)
            {
                People result = JsonConvert.DeserializeObject<People>(response.Content.ReadAsStringAsync().Result);
                return result;
            }

            return null;
        }


        public Result<People> searchUser(string field,string search)
        {
            var client = new ODataClient();
            search = " eq '" + search + "'";

            var response = client.Get(getPath() + "/People?" + "$filter=" + field +  search);

            if (response.IsSuccessStatusCode)
            {
                Result<People> result = JsonConvert.DeserializeObject<Result<People>>(response.Content.ReadAsStringAsync().Result);
                return result;
            }

            return null;
        }
    }
}
