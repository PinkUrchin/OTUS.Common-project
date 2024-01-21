using Protocol.Common;

namespace SignalR_Service.ModelsRequests
{
    public class RequestShape:RequestDocument
    {
        public Shape ShapeInfo { get; private set; }
        public RequestShape(string userName, int documentId, Shape shapeInfo) : base(userName,documentId)
        {
            ShapeInfo = shapeInfo;
        }
    }
}
