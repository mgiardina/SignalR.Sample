using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace SignalRServer
{
    public class MyHub : Hub
    {
        public async Task Send(string message)
        {
            // aplicamos una logica de transformacion de ejemplo del mensaje recibido
            string processedMessage = message.ToLower();

            await Clients.All.SendAsync("Receive", processedMessage);

            //para enviar solo al cliente que solicito el mensaje
            //await Clients.Caller.SendAsync("Receive", processedMessage);
        }
    }
}
