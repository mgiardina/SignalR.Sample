using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;

namespace SignalRClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:5000/myhub")
                .Build();

            connection.On<string>("Receive", message =>
            {
                Console.WriteLine($"Mensaje recibido: {message}");
            });

            await connection.StartAsync();

            while (true)
            {
                Console.Write("Ingresar mensaje a enviar: ");
                var message = Console.ReadLine();

                if (string.IsNullOrEmpty(message))
                {
                    break;
                }

                await connection.InvokeAsync("Send", message);
            }

            await connection.DisposeAsync();
        }
    }
}