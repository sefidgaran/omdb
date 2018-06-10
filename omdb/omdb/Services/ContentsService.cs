using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using omdb.Services;
namespace omdb.Services
{
    public class ContentsService
    {
        private readonly HttpClient _httpClient;

        public const string BaseUrl = "http://www.omdbapi.com?apikey={0}&s={1}&r=json&page=1";
        public const string FindUrlByID = "http://www.omdbapi.com?apikey={0}&i={1}&plot=full";
        public const string ApiKey = "88bb8dc6";

        public ContentsService()
        {
            _httpClient = new HttpClient();
        }
        public async Task<List<Content>> SearchContentsAsync(string query)
        {
            var response = await _httpClient.GetAsync(string.Format(BaseUrl, ApiKey, query));
            if (response.IsSuccessStatusCode)
            {
                    var resultContent = await response.Content.ReadAsStringAsync();
                    var resultData = JsonConvert.DeserializeObject<ContentResponse>(resultContent);
                if (resultData.Search == null)
                    return null;//Movie not found!
                else
                    return resultData.Search.ToList();                
            }
            return new List<Content>();
        }
        public async Task<ContentModel> GetContentAsync(string id)
        {
            var response = await _httpClient.GetAsync(string.Format(FindUrlByID, ApiKey, id));
            if (response.IsSuccessStatusCode)
            {
                var resultContent = await response.Content.ReadAsStringAsync();
                var resultData = JsonConvert.DeserializeObject<ContentModel>(resultContent);
                return resultData;
            }
            return new ContentModel();
        }
    }
}
