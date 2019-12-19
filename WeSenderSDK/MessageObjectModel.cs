using System;
using System.Collections.Generic;
using System.Text;

namespace WeSenderSDK
{
    public class MessageObjectModel
    {
        public List<string> destine { get; set; }
        public string message { get; set; }
        public bool hasSpecialCharacter = false;
    }
}
