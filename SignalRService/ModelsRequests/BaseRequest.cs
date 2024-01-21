namespace SignalR_Service.ModelsRequests
{
    abstract public class BaseRequest
    {
        public string UserName { get; private set; }

        public BaseRequest(string userName)
        { UserName = userName; }
    }
}
