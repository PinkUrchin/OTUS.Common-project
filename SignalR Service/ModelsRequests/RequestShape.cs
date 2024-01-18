namespace SignalR_Service.ModelsRequests
{
    public class RequestShape:RequestDocument
    {
        public string ShapeInfo { get; private set; }
        public RequestShape(string userName, int documentId, string shapeInfo) : base(userName,documentId)
        {
            ShapeInfo = shapeInfo;
        }
    }
}
