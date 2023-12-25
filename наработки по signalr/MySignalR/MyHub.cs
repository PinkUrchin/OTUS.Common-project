using Microsoft.AspNetCore.SignalR;
using System.Drawing;

namespace MySignalR
{


    public sealed class MyHub: Hub
    {

        public async Task Send(string username, string message)
        {
            await this.Clients.All.SendAsync("Receive", username, message);
        }

        public async Task SendCoords(string username, int[] coords)
        {
            await this.Clients.Others.SendAsync("ReceiveCoords", username, coords);
        }

        public async Task SendCircle(string username, string shape)
        {
            await this.Clients.Others.SendAsync("ReceiveCircle", username, shape);
        }

        public async Task SendRectangle(string username, string shape)
        {
            await this.Clients.Others.SendAsync("ReceiveRectangle", username, shape);
        }


        public async Task SendLine(string username, string shape)
        {
            await this.Clients.Others.SendAsync("ReceiveLine", username, shape);
        }

        public async Task SendFree(string username, string shape)
        {
            await this.Clients.Others.SendAsync("ReceiveFree", username, shape);
        }

    }
}
