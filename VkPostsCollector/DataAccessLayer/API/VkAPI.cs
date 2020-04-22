using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using VkPostsCollector.ApplicationLayer.Common;
using VkPostsCollector.BusinessLayer;

namespace VkPostsCollector.DataAccessLayer.API
{
    public static class VkAPI
    {
        private const string ApiPage = "https://api.vk.com/method/";

        public static List<PublicationDTO> GetWallPosts(string domain, int quantity, string AccessToken, WebProxy proxy = null)
        {
            return GetWallPosts(domain, quantity, 0, AccessToken, proxy);
        }

        public static List<PublicationDTO> GetWallPosts(string domain, int quantity, int offset, string AccessToken, WebProxy proxy = null)
        {
            List<PublicationDTO> posts = new List<PublicationDTO>();

            WebData https = new WebData(proxy);
            string method = "wall.get";

            int RequstedQuantity = quantity > 100 ? 100 : quantity;

            NameValueCollection vkParams = new NameValueCollection
            {
                { "access_token", AccessToken },
                { "v", "5.103"},
                { "domain", domain},
                { "count", RequstedQuantity.ToString()},
                { "filter", "owner" }
            };
            if(offset > 0) vkParams.Add("offset", offset.ToString());

            HttpResponse response = https.POST(ApiPage + method, vkParams);
            if (response == null)
                return null;

            JObject JsonObject = JObject.Parse(response.Content);


            if(JsonObject.TryGetValue("response", out JToken JsonResponse) == false)
            {
                if(JsonObject.TryGetValue("error", out JToken JsonError))
                {
                    string errorCode = JsonError["error_code"].ToString();
                    string errorMessage = JsonError["error_msg"].ToString();

                    MessageBox.Show($"Ошибка {errorCode}\r\n{errorMessage}");
                }
                else
                {
                    MessageBox.Show("Неизвестная ошибка!");
                }
                
                return null;
            }

            JToken JOItems = JsonResponse["items"];
            foreach (JObject item in JOItems)
            {
                PublicationDTO publication = new PublicationDTO();

                string postLink = "https://vk.com/" + domain + "?w=wall" + item["from_id"] + "_" + item["id"] + "/all";

                publication.GroupLink = "https://vk.com/" + domain;

                publication.Id = item["id"].ToString();

                publication.Created = Converters.UnixTimeToDateTime(long.Parse(item["date"].ToString()));
                publication.PostType = item["post_type"].ToString();
                publication.PostLink = postLink;
                publication.Text = item["text"].ToString();

                if (item.TryGetValue("copy_history", out JToken JsonCopyHistory))
                    publication.IsRepost = true;

                if (item.TryGetValue("is_pinned", out JToken JsonIsPinned))
                    publication.IsPinned = Converters.StringBitToBool(JsonIsPinned.Value<string>());

                if (item.TryGetValue("marked_as_ads", out JToken JsonMarkedAsAds))
                    publication.MarkedAsAds = Converters.StringBitToBool(JsonMarkedAsAds.Value<string>());

                if (item.TryGetValue("signer_id", out JToken JsonSignerId))
                {
                    publication.ExistsSigner = true;
                    publication.SignerLink = "https://vk.com/id" + JsonSignerId.Value<string>();
                }

                publication.Comments = decimal.Parse(item["comments"]["count"].ToString());
                publication.Likes = decimal.Parse(item["likes"]["count"].ToString());
                publication.Reposts = decimal.Parse(item["reposts"]["count"].ToString());
                publication.Views = decimal.Parse(item["views"]["count"].ToString());

                string[] paragraphs = Regex.Split(publication.Text, "\n");
                foreach (string paragraph in paragraphs)
                {
                    if (paragraph.Contains("http"))
                    {
                        string[] words = Regex.Split(paragraph, " ");
                        foreach (string word in words)
                        {
                            string link = Regex.Match(word, "http([^(]*)").Groups[0].Value;
                            if (string.IsNullOrEmpty(link) == false)
                                publication.Links.Add(link);
                        }
                    }
                }
                publication.ExistsLinks = publication.Links.Count > 0;

                publication.ExistsAttachments = item.TryGetValue("attachments", out JToken JsonAttachments);
                if (publication.ExistsAttachments)
                {
                    // JsonAttachments
                    foreach(JToken attachment in JsonAttachments)
                    {
                        if (attachment["type"].ToString().Equals("photo") == false) continue;

                        if (publication.ExistsImages == false)
                        {
                            publication.ExistsImages = true;
                        }

                        JToken photo = attachment["photo"]["sizes"].Last;
                        publication.ImageLinks.Add(photo["url"].ToString());
                    }
                }

                posts.Add(publication);
            }

            return posts;
        }

        //private List<Tuple<string, string>> GetWallPostsImagesLinks(string wallPageName, int quantity)
        //{
        //    var https = new Https();
        //    var links = new List<Tuple<string, string>>();

        //    const string method = "wall.get";
        //    var proceedCount = 0;
        //    while (proceedCount < quantity)
        //    {
        //        var curCount = quantity - proceedCount;
        //        if (curCount > 100) curCount = 100;
        //        //else curCount = quantity - proceedCount;
        //        var vkParams = new NameValueCollection
        //        {
        //            {"access_token", ServiceKey },
        //            {"v", "5.103"},
        //            {"domain", wallPageName},
        //            {"count", curCount.ToString()},
        //            {"offset", proceedCount.ToString()}
        //        };
        //        var response = https.POST(ApiPage + method, new CookieContainer(), vkParams);

        //        foreach (var jo in JObject.Parse(response.Content)["response"]["items"])
        //        {
        //            if (jo["attachments"] == null) continue;
        //            var imgName = "wallid" + jo["id"];
        //            var tImageName = imgName;
        //            var jj = jo["attachments"] ?? jo["copy_history"]["attachments"];
        //            var attCnt = 1;
        //            foreach (var jo1 in jj)
        //            {
        //                imgName += "_" + attCnt++;
        //                if (!jo1["type"].ToString().Equals("photo")) continue;
        //                if (jo1["photo"]["photo_2560"] != null)
        //                    links.Add(new Tuple<string, string>(imgName, jo1["photo"]["photo_2560"].ToString()));
        //                else if (jo1["photo"]["photo_1280"] != null)
        //                    links.Add(new Tuple<string, string>(imgName, jo1["photo"]["photo_1280"].ToString()));
        //                else if (jo1["photo"]["photo_807"] != null)
        //                    links.Add(new Tuple<string, string>(imgName, jo1["photo"]["photo_807"].ToString()));
        //                else if (jo1["photo"]["photo_604"] != null)
        //                    links.Add(new Tuple<string, string>(imgName, jo1["photo"]["photo_604"].ToString()));
        //                else links.Add(new Tuple<string, string>(imgName, jo1["photo"]["photo_130"].ToString()));
        //                imgName = tImageName;
        //            }
        //        }

        //        proceedCount += curCount;
        //        parsedCntLabel.Invoke(() => { parsedCntLabel.Text = "Спаршено: " + proceedCount + " из " + quantity; });
        //        parsedInfo.Invoke(() => { parsedInfo.Text = "(найдено " + links.Count + " изображений)"; });
        //    }
        //    return links;
        //}
    }
}
