using ODataService.Http;
using ODataService.Models;
using ODataService.Services.Interfaces;
using Newtonsoft.Json;
using System.Web;
using System;

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
                result = JsonConvert.DeserializeObject<Result<People>>(response.Content.ReadAsStringAsync().Result);
            }

            return result;
        }

        public People getUser(string user)
        {
            var client = new ODataClient();

            var response = client.Get(getPath() + "/People" + "('" + user + "')");

            People result = new People();
            if (response.IsSuccessStatusCode)
            {
                result = JsonConvert.DeserializeObject<People>(response.Content.ReadAsStringAsync().Result);
            }

            return result;
        }


        public Result<People> searchUser(string field,string search)
        {
            var client = new ODataClient();
            search = " eq '" + search + "'";

            var response = client.Get(getPath() + "/People?" + "$filter=" + field +  search);

            Result<People> result = new Result<People>();
            if (response.IsSuccessStatusCode)
            {
                result = JsonConvert.DeserializeObject<Result<People>>(response.Content.ReadAsStringAsync().Result);
            }

            return result;
        }
    }
}
