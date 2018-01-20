using System;
using System.Collections.Generic;
using System.Linq;
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

            foreach (var e in events)
                if (e.CanHandle(hermesAction))
                    e.Handle(hermesAction);
        }
    }
}
