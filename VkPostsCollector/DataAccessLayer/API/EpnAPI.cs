using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using VkPostsCollector.BusinessLayer;

namespace VkPostsCollector.DataAccessLayer.API
{
    public static class EpnAPI
    {
        public static string GetCleanUrl(string ShortURL)
        {
            return string.Empty;
        }

        public static AuthEpnDTO Auth(string username, string password)
        {
            string SsidGetApiPage = "https://app.epn.bz/ssid?client_id=web-client";
            string AuthApiPage = "https://app.epn.bz/token";

            AuthEpnDTO authEpnDTO = new AuthEpnDTO();

            WebData https = new WebData();

            // Ssid token
            //NameValueCollection ssidGetParameters = new NameValueCollection()
            //{
            //    { "client_id", "web-client" }
            //};
            HttpResponse responseSSID = https.GET(SsidGetApiPage);
            if (responseSSID == null) return null;
            JObject JsonObjectSSID = JObject.Parse(responseSSID.Content);

            if (JsonObjectSSID.TryGetValue("data", out JToken JsonDataSSID))
            {
                JToken JsonSSIDAttributes = JsonDataSSID["attributes"];

                authEpnDTO.ssid_token = JsonSSIDAttributes["ssid_token"].ToString();
            }

            // Запрос на авторизацию
            https.AdditionalHeaders.Add("X-API-VERSION", "2");
            https.AdditionalHeaders.Add("X-SSID", authEpnDTO.ssid_token);
            NameValueCollection authParameters = new NameValueCollection()
            {
                { "grant_type", "password" },
                { "username", username },
                { "password", password },
                { "client_id", "web-client" }
            };
            HttpResponse ResponseAuth = https.POST(AuthApiPage, authParameters);
            JObject JsonObjectAuth = JObject.Parse(ResponseAuth.Content);

            if (JsonObjectAuth.TryGetValue("data", out JToken JsonDataAuth))
            {
                JToken JsonAuthAttributes = JsonDataAuth["attributes"];

                authEpnDTO.access_token = JsonAuthAttributes["access_token"].ToString();
                authEpnDTO.token_type = JsonAuthAttributes["token_type"].ToString();
                authEpnDTO.refresh_token = JsonAuthAttributes["refresh_token"].ToString();
            }

            return authEpnDTO;
        }

        public static string CreateUrl(string FullURL, string description, AuthEpnDTO AuthObject)
        {
            string ApiPage = "https://app.epn.bz/creative/create";

            WebData https = new WebData();

            https.AdditionalHeaders.Add("ACCEPT-LANGUAGE", "ru");
            https.AdditionalHeaders.Add("X-ACCESS-TOKEN", AuthObject.access_token);
            NameValueCollection creativeParameters = new NameValueCollection()
            {
                { "link", FullURL },
                { "offerId", "1" },
                { "description", description },
                { "type", "link" } //deeplink
            };
            HttpResponse responseCreative = https.POST(ApiPage, creativeParameters);
            JObject JsonObjectCreative = JObject.Parse(responseCreative.Content);

            if (JsonObjectCreative.TryGetValue("data", out JToken JsonCreativeAuth))
            {
                JToken JsonCreativeRequest = JsonCreativeAuth["request"];

                return JsonCreativeRequest["url"].ToString();
            }

            return string.Empty;
        }

        public static string CreateUrl(string DeepLinkHash, string FullURL)
        {
            string baseUrl = "http://alipromo.com/redirect/cpa/o/" + DeepLinkHash + "?to=" + WebUtility.UrlEncode(FullURL);

            return baseUrl;
        }

        public static string ShortURL(string URL, AuthEpnDTO AuthObject)
        {
            string ApiPage = "https://app.epn.bz/link-reduction";

            WebData https = new WebData();

            https.AdditionalHeaders.Add("X-ACCESS-TOKEN", AuthObject.access_token);
            dynamic epnParams = new JObject();
            epnParams.urlContainer = new JArray(URL);
            epnParams.domainCutter = "ali.pub";


            string test = JsonConvert.SerializeObject(epnParams);

            HttpResponse response = https.POST(ApiPage, test);
            JObject JsonObject = JObject.Parse(response.Content);

            return string.Empty;
        }
    }
}
