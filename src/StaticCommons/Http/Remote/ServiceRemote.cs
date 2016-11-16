using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace StaticCommons.Http.Remote
{
    public static class ServiceRemote
    {
        static ServiceRemote() { }

        public static async Task<T> Connect<T>(HttpMethod method, string url)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(method, url);
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var responseRaw = await client.SendAsync(request);
                var responseJson = responseRaw.Content.ReadAsStringAsync().Result;
                var responseConverted = JsonConvert.DeserializeObject<T>(responseJson);

                return responseConverted;
            }
            catch (TypeInitializationException)
            {
                throw ;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.ToString());
            }
        }



        public static async Task<T> Connect<T>(HttpMethod method, string url, string uniqueName, string code)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(method, url);
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                request.Headers.Add("unique_name", uniqueName);
                request.Headers.Add("code", code);

                var responseRaw = await client.SendAsync(request);
                var responseJson = responseRaw.Content.ReadAsStringAsync().Result;
                var responseConverted = JsonConvert.DeserializeObject<T>(responseJson);

                return responseConverted;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<HttpResponseMessage> Connect(HttpMethod method, string url, string uniqueName, string code)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(method, url);
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                request.Headers.Add("unique_name", uniqueName);
                request.Headers.Add("code", code);

                var responseSend = await client.SendAsync(request);
                var responseStr = await responseSend.Content.ReadAsStringAsync();
                var responseObj = JsonConvert.DeserializeObject<HttpResponseMessage>(responseStr);

                if (responseSend.IsSuccessStatusCode && responseObj.IsSuccessStatusCode)
                {
                    return new HttpResponseMessage(HttpStatusCode.OK);
                }

                return new HttpResponseMessage(HttpStatusCode.BadRequest);

            }
            catch (Exception)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }

        public static async Task<HttpResponseMessage> Connect<T>(HttpMethod method, string url, string uniqueName, string code, T body)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(method, url);
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                request.Headers.Add("unique_name", uniqueName);
                request.Headers.Add("code", code);

                var serialized = JsonConvert.SerializeObject(body);
                request.Content = new ByteArrayContent(GetBytes(serialized));

                var responseSend = await client.SendAsync(request);
                var responseStr = await responseSend.Content.ReadAsStringAsync();
                var responseObj = JsonConvert.DeserializeObject<HttpResponseMessage>(responseStr);

                if (responseSend.IsSuccessStatusCode && responseObj.IsSuccessStatusCode)
                {
                    return new HttpResponseMessage(HttpStatusCode.OK);
                }

                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            catch (Exception)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }

        public static async Task<HttpResponseMessage> Connect<T>(HttpMethod method, string url, T body)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(method, url);
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                if (body != null)
                {
                    var serialized = JsonConvert.SerializeObject(body);
                    request.Content = new ByteArrayContent(GetBytes(serialized));
                }

                var responseSend = await client.SendAsync(request);
                var responseStr = await responseSend.Content.ReadAsStringAsync();
                var responseObj = JsonConvert.DeserializeObject<HttpResponseMessage>(responseStr);

                if (responseSend.IsSuccessStatusCode && responseObj.IsSuccessStatusCode)
                {
                    return new HttpResponseMessage(HttpStatusCode.OK);
                }

                return new HttpResponseMessage(HttpStatusCode.BadRequest);

            }
            catch (Exception)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }

        public static async Task<HttpResponseMessage> Connect<T>(HttpMethod method, string url, string uniqueName, string code, Guid id)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(method, url);
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                request.Headers.Add("unique_name", uniqueName);
                request.Headers.Add("code", code);

                var responseSend = await client.SendAsync(request);
                var responseStr = await responseSend.Content.ReadAsStringAsync();
                var responseObj = JsonConvert.DeserializeObject<HttpResponseMessage>(responseStr);

                if (responseSend.IsSuccessStatusCode && responseObj.IsSuccessStatusCode)
                {
                    return new HttpResponseMessage(HttpStatusCode.OK);
                }

                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            catch (Exception)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }

        public static Guid GenerateNewGuid()
        {
            return Guid.NewGuid();
        }

        public static string GetUserAlias(string uniqueName)
        {
            string result = uniqueName.Split('@')[0];
            return result;
        }
        public static byte[] GetBytes(string obj)
        {
            return Encoding.UTF8.GetBytes(obj);
        }

        public static string GetString(byte[] obj)
        {
            return Encoding.UTF8.GetString(obj);
        }
    }
}
