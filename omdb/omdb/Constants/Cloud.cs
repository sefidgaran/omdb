using System;
using System.Collections.Generic;
using System.Text;

namespace omdb.Constants
{
    public static class Cloud
    {
        public static string ServerUrl = "http://www.omdbapi.com";
        public static string BaseUrl = "?apikey={0}&s={1}&r=json&page=1";
        public static string FindUrlByID = "?apikey={0}&i={1}&plot=full";
        public static string ApiKey = "88bb8dc6";
    }
}
