namespace KT19
{
    using System.Collections.Generic;

    public class MessageData
    {
        public List<string> Messages { get; set; }
        public List<string> History { get; set; }

        public MessageData()
        {
            Messages = new List<string>();
            History = new List<string>();
        }
    }
}