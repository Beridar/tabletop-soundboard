using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Soundboard.Hermes
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var @event = new HandleSomethingDying())
            {
                ListenForAnyHermesActionsAndHandleWithTheseEvents(new[] { @event });
            }
        }

        private static void ListenForAnyHermesActionsAndHandleWithTheseEvents(IEventHandler[] events)
        {
            string hermesAction = null;

            while(true)
            {
                System.Threading.Thread.Sleep(100);

                hermesAction = AskHermesForAnAction();
                if (string.IsNullOrWhiteSpace(hermesAction))
                    continue;

                foreach (var e in events)
                    if (e.CanHandle(hermesAction))
                        e.Handle(hermesAction);
            }
        }

        private static HttpClient httpClient = new HttpClient();

        private static string AskHermesForAnAction()
        {
            string hermesMessage = null;

            Task.Run(async () =>
            {
                var httpRequest = new HttpRequestMessage(HttpMethod.Get, @"https://localhost:44392/api/values/1");

                var response = await httpClient.SendAsync(httpRequest);

                hermesMessage = await response.Content.ReadAsStringAsync();
            }).Wait();
            
            return hermesMessage;
        }
    }
}
