using System.Net.Http;
using System.Net.Http.Headers;

namespace WooliesXTechChallenge.ResourceApiClient.Helper
{
    internal class HttpHelper
    {
        public HttpHelper()
        {
            Client = new HttpClient();
            Client.DefaultRequestHeaders.Add("Accept", "application/json");                       
        }

        public HttpClient Client { get; }
    }
}
