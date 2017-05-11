using System;

namespace TwitterNotificationPop3Reader
{
    public class EmailMessage
    {
        public string MessageID { get; set; }
        public DateTime Date { get; set; }
        public string From { get; set; }
        public string Subject { get; set; }
    }
}