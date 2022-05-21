using System;

namespace ChatApp2Docs.Models.APIResponseModels
{
    public class GlobalChatMessage
    {
        public string Text { get; set; }
        public string Time { get; set; }
        public string Sender { get; set; }
        public bool isSender { get; set; }
    }
}
