using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soundboard.Hermes
{
    public interface IEventHandler
    {
        bool CanHandle(string @event);
        void Handle(string @event);
    }
}
