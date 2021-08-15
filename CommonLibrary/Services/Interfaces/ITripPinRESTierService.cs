using ODataService.Models;

namespace ODataService.Services.Interfaces
{
    interface ITripPinRESTierService
    {
        public string getPath();

        public Result<People> getPeople();
    }
}
