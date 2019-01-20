using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Newtonsoft.Json;
using omdb.Constants;
using omdb.Services;
using Plugin.Connectivity;

namespace omdb.Services
{
    public class ContentsService
    {
        private readonly HttpClient _httpClient;

        

        public ContentsService()
        {
            _httpClient = new HttpClient();
        }
        public async Task<List<Content>> SearchContentsAsync(string query)
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                var url = string.Format(Cloud.ServerUrl + Cloud.BaseUrl, Cloud.ApiKey, query);
                var response = await _httpClient.GetAsync(url); if (response.IsSuccessStatusCode)
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
            else
            {
                UserDialogs.Instance.Alert("Please make sure your device is connected to the Internet!", "Alert", "OK");
                return null;
            }
        }
        public async Task<ContentModel> GetContentAsync(string id)
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                var url = string.Format(Cloud.ServerUrl + Cloud.FindUrlByID, Cloud.ApiKey, id);
                var response = await _httpClient.GetAsync(url); if (response.IsSuccessStatusCode)
                {
                    var resultContent = await response.Content.ReadAsStringAsync();
                    var resultData = JsonConvert.DeserializeObject<ContentModel>(resultContent);
                    return resultData;
                }
                return new ContentModel();
            }
            else
            {
                UserDialogs.Instance.Alert("Please make sure your device is connected to the Internet!", "Alert", "OK");
                return null;
            }
        }
    }
}
