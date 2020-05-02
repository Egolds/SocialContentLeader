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

        public static List<VkPublicationDTO> GetWallPosts(GroupDTO Group, int quantity, string AccessToken, WebProxy proxy = null)
        {
            return GetWallPosts(Group, quantity, 0, AccessToken, proxy);
        }

        public static List<VkPublicationDTO> GetWallPosts(GroupDTO Group, int quantity, int offset, string AccessToken, WebProxy proxy = null)
        {
            List<VkPublicationDTO> posts = new List<VkPublicationDTO>();

            WebData https = new WebData(proxy);
            string method = "wall.get";

            int RequstedQuantity = quantity > 100 ? 100 : quantity;

            NameValueCollection vkParams = new NameValueCollection
            {
                { "access_token", AccessToken },
                { "v", "5.103"},
                { "domain", Group.ScreenName},
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
                VkPublicationDTO publication = new VkPublicationDTO();

                //string postLink = "https://vk.com/" + domain + "?w=wall" + item["from_id"] + "_" + item["id"] + "/all";
                string postLink = Group.URL + "?w=wall" + item["from_id"] + "_" + item["id"] + "/all";

                publication.Group = Group;

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

        public static GroupDTO GetGroup(string UrlOrId, string AccessToken, WebProxy proxy = null)
        {
            WebData https = new WebData(proxy);
            string method = "groups.getById";

            string Id = UrlOrId;
            if (Id.StartsWith("https://vk.com/")) Id = Id.Replace("https://vk.com/", "");

            NameValueCollection vkParams = new NameValueCollection
            {
                { "access_token", AccessToken },
                { "v", "5.103"},
                { "group_id", Id}
            };

            HttpResponse response = https.POST(ApiPage + method, vkParams);
            if (response == null)
                return null;

            JObject JsonObject = JObject.Parse(response.Content);

            if (JsonObject.TryGetValue("response", out JToken JsonResponse) == false)
            {
                if (JsonObject.TryGetValue("error", out JToken JsonError))
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

            GroupDTO group = new GroupDTO();

            foreach (JObject item in JsonResponse)
            {
                
                //group.Id = item["id"].ToString();
                group.Name = item["name"].ToString();
                group.ScreenName = item["screen_name"].ToString();

                //if (item.TryGetValue("screen_name", out JToken JsonScreenName))
                //{
                //    group.ScreenName = item["screen_name"].ToString();
                //}

                group.PhotoUrl = item["photo_200"].ToString();
            }
            
            return group;
        }
    }
}
