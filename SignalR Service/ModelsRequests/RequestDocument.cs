namespace SignalR_Service.ModelsRequests
{
    public class RequestDocument : BaseRequest
    {
        public int DocumentId { get; private set; }
        public RequestDocument(string userName, int documentId) : base(userName)
        {
            DocumentId = documentId;
        }
    }
}
