using System;
using System.Collections.Generic;

using Pop3;

namespace TwitterNotificationPop3Reader
{
    public class POP3Repository
    {
        private string server;
        private string userName;
        private string password;

        public POP3Repository(string server, string userName, string password)
        {
            this.server = server;
            this.userName = userName;
            this.password = password;
        }

        public IEnumerable<EmailMessage> GetAll()
        {
            var pop3Client = new Pop3Client();
            pop3Client.Connect(this.server, this.userName, this.password, false);

            foreach (var email in pop3Client.List())
            {
                pop3Client.Retrieve(email);

                yield return new EmailMessage {
                    MessageID = email.MessageId,
                    Date = Convert.ToDateTime(email.Date),
                    From = email.From,
                    Subject = email.Subject,
                };
            }

            pop3Client.Disconnect();
        }
    }
}