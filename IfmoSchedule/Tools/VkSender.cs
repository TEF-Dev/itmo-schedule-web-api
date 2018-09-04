using System.Net.Http;

namespace IfmoSchedule.Tools
{
    public class VkSender
    {
        private const string Ver = "5.8";
        private const string Chat = "8";
        private const string BaseAddress = "https://api.vk.com/method/messages.send?";

        private readonly string _token;

        public VkSender(string token)
        {
            _token = token;
        }
        public HttpContent Send(string message)
        {
            var address = $"{BaseAddress}access_token={_token}&chat_id={Chat}&v={Ver}&message={message}";
            var client = new HttpClient();
            return client.GetAsync(address).Result.Content;
        }
    }
}