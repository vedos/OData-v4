using ODataService.Models;
using System.Collections.Generic;

namespace ODataService.Helper
{
    public static class CustomExtensions
    {

        public static string toString(this List<string> list)
        {
            if (list == null || list.Count == 0)
                return "";

            string result = list[0];
            list.Remove(list[0]);
            foreach (string s in list) 
            {
                result += " - " + s;
            }

            return result;
        }

        public static string toString<T>(this List<T> list) where T: IEntity
        {
            if (list == null || list.Count == 0)
                return "";

            string result = list[0].toString();
            list.Remove(list[0]);
            foreach (T i in list) 
            {
                result += "\n ---------------------------  \n" + i.toString();
            }

            return result;
        }
    }
}
