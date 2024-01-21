namespace SignalR_Service.ModelsRequests
{
    public class RequestDocumentName : BaseRequest
    {
        public string DocumentName { get; private set; }
        public RequestDocumentName(string userName, string documentName) : base(userName)
        {
            DocumentName = documentName;
        }
    }
}
