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
                if (@event.CanHandle(null))
                    @event.Handle(null);
        }
    }
}
