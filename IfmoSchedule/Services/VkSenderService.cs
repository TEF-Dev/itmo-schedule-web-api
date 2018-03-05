using System;
using System.Net.Http;

namespace IfmoSchedule.Services
{
    public static class VkSenderService
    {
        private static string Access = "place_here";
        private static string Ver = "5.8";
        private static string Chat = "8";
        private static string BaseAddr = "https://api.vk.com/method/messages.send?";

        public static void Send (string message) {
            string address = $"{BaseAddr}access_token={Access}&chat_id={Chat}&v={Ver}&message={message}";
            var client = new HttpClient();
            client.GetAsync(address);
        }
    }
}
