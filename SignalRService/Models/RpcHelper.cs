namespace SignalR_Service.Models
{
    public class RpcHelper
    {
        public async Task<string> DoRPCRequestAsync(string message)
        {
            var rpcClient = new Client();
            var response = await rpcClient.CallAsync(message);
            return response;
        }
    }
}
