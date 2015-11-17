using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientLibrary
{
    public interface IClient
    {
        event Action<string> NewMessageReceive;

        void SendMessage(string message);

        void Connect();
        void Disconnect();
    }
}
