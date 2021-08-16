using Newtonsoft.Json;
using ODataService.Helper;
using System.Collections.Generic;

namespace ODataService.Models
{
    public class City: IEntity
    {
        public string Name { get; set; }
        public string CountryRegion { get; set; }
        public string Region { get; set; }

        public string toString() 
        {
            return " Name: " + Name + "\n Country region: " + CountryRegion + "\n Region:" + Region;
        }
    }

    public class AddressInfo: IEntity
    {
        public string Address { get; set; }
        public City City { get; set; }

        public string toString()
        {
            return " Address: " + Address + "\n City: { \n" + City?.toString() + "\n }";
        }
    }

    public class HomeAddress: IEntity
    {
        public object Address { get; set; }
        public City City { get; set; }

        public string toString()
        {
            return " Address: " + Address + "\n City: { \n" + City?.toString() + "\n }";
        }
    }

    public class People: IEntity
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Gender { get; set; }
        public string Age { get; set; }
        public List<string> Emails { get; set; }
        public string FavoriteFeature { get; set; }
        public List<string> Features { get; set; }
        public List<AddressInfo> AddressInfo { get; set; }
        public HomeAddress? HomeAddress { get; set; }

        [JsonProperty("@odata.type")]
        public string OdataType { get; set; }
        public int? Budget { get; set; }
        public string BossOffice { get; set; }
        public int? Cost { get; set; }

        public string toString()
        {
            return " UserName: " + UserName + "\n FirstName: " + FirstName + "\n LastName: " + LastName + "\n MiddleName: " + MiddleName + "\n Gender: " + Gender 
                + "\n Age: " + Age + "\n Emails: " + Emails?.toString() + "\n FavouriteFeature: " + FavoriteFeature + "\n Features: " + Features?.toString() 
                + "\n AddressInfo: { \n" + AddressInfo?.toString<AddressInfo>() + "\n }" + "\n HomeAddress: " + HomeAddress?.toString() + "\n Budget: " + Budget + "\n BossOffice: " + BossOffice 
                + "\n Cost: " +  Cost;
        }
    }


}
