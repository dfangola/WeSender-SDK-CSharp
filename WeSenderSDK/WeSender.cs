using System;

namespace WeSenderSDK
{
    public class WeSender
    {
        private string url = "http://apiwesender-dev.digitalfactory.co.ao";
        private string apiKey;

        public WeSender (string apiKey)
        {
            this.apiKey = apiKey;
        }

        public void sendMessage(MessageObject messageObject)
        {
            return;
        }

        protected class MessageObject
        {
            public Array destine;
            public string message;
            public bool hasSpecialCharacter = false;
        }
    }
}
