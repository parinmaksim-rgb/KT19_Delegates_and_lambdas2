namespace KT19
{
    using System;
    using System.Collections.Generic;

    public class MessageProcessor
    {
        private const int MinLength = 3;
        private const string Prefix = "[LOG] ";

        public Func<string, bool> IsLongEnough { get; set; }
        public Func<string, string> Transform { get; set; }
        public Action<string> PrintToScreen { get; set; }
        public Action<string> SaveToHistory { get; set; }
        public Action<string> CombinedAction { get; set; }

        public MessageProcessor(List<string> historyList)
        {
            IsLongEnough = msg => msg.Length > MinLength;
            Transform = msg => Prefix + msg.ToUpper();
            PrintToScreen = msg => Console.WriteLine(msg);
            SaveToHistory = msg => historyList.Add(msg);

            CombinedAction = PrintToScreen;
            CombinedAction += SaveToHistory;
        }
    }
}