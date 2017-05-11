using System;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace TwitterNotificationPop3Reader
{
    class Program
    {
        static void Main(string[] args)
        {
            var server = "";
            var username = "";
            var password = "";

            var pop3Repository = new POP3Repository(server, username, password);
            var fromFilter = "notify@twitter.com";

            var results = new List<EmailMessage>();

            foreach (var message in pop3Repository.GetAll())
            {
                if (message.From.Contains(fromFilter))
                {
                    results.Add(message);
                }
            }

            Console.WriteLine(JsonConvert.SerializeObject(results));
        }
    }
}