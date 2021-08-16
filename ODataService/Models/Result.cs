using Newtonsoft.Json;
using System.Collections.Generic;

namespace ODataService.Models
{
    public class Result<T>
    {
        [JsonProperty("@odata.context")]
        public string OdataContext { get; set; }
        public List<T> value { get; set; }
    }
}