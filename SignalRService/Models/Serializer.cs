using System.Net.Sockets;
using Newtonsoft.Json;
using Protocol.Common;
using SignalR_Service.ModelsRequests;

namespace SignalR_Service.Models
{
    public class Serializer 
    {
        private RpcHelper RpcHelper;
        public Serializer() 
        { 
            RpcHelper = new RpcHelper();
        }
        public async Task<Document> CreateDocument(string name, string userName)
        {
            RequestDocumentName requestDocument = new RequestDocumentName(userName, name);
            var response = await RpcHelper.DoRPCRequestAsync(JsonConvert.SerializeObject(requestDocument));
            var baseResponse = BaseResponse.ReadResponse(response);
            var doc = baseResponse as Document;
            return doc;
        }

        public async Task<(Shape, StatusResponse)> CreateShape(int idDocument, Shape shapeInfo, string userName)
        {
            RequestShape requestShape = new RequestShape(userName, idDocument, shapeInfo);
            var response = await RpcHelper.DoRPCRequestAsync(JsonConvert.SerializeObject(requestShape));
            var baseResponse = BaseResponse.ReadResponse(response);
            var shape = baseResponse as Shape;
            var status = baseResponse as StatusResponse;
            return (shape, status);
        }

        public async Task<StatusResponse> DeleteDocumentById(int idDocument, string userName)
        {
            RequestDocument requestDocument = new RequestDocument(userName, idDocument);
            var response = await RpcHelper.DoRPCRequestAsync(JsonConvert.SerializeObject(requestDocument));
            var baseResponse = BaseResponse.ReadResponse(response);
            var status = baseResponse as StatusResponse;
            return status;
        }

        public async Task<(Shape, StatusResponse)> DeleteShape(Shape shape, string userName)
        {
            RequestShape requestShape = new RequestShape(userName, shape.DocumentId, shape);
            var response = await RpcHelper.DoRPCRequestAsync(JsonConvert.SerializeObject(requestShape));
            var baseResponse = BaseResponse.ReadResponse(response);
            var shapeRes = baseResponse as Shape;
            var status = baseResponse as StatusResponse;
            return (shapeRes, status);
        }

        public async Task<Document> GetDocumentById(int idDocument, string userName)
        {
            RequestDocument requestDocument = new RequestDocument(userName, idDocument);
            var response = await RpcHelper.DoRPCRequestAsync(JsonConvert.SerializeObject(requestDocument));
            var baseResponse = BaseResponse.ReadResponse(response);
            var doc = baseResponse as Document;
            return doc;
        }

        public async Task<DocumentList> GetListDocuments(string userName)
        {
            RequestUser requestUser = new RequestUser(userName);
            var response = await RpcHelper.DoRPCRequestAsync(JsonConvert.SerializeObject(requestUser));
            var baseResponse = BaseResponse.ReadResponse(response);
            var doc = baseResponse as DocumentList;
            return doc;
        }

        public async Task<(Shape, StatusResponse)> UpdateShape(int idDocument, Shape shapeInfo, string userName)
        {
            RequestShape requestShape = new RequestShape(userName, idDocument, shapeInfo);
            var response = await RpcHelper.DoRPCRequestAsync(JsonConvert.SerializeObject(requestShape));
            var baseResponse = BaseResponse.ReadResponse(response);
            var shape = baseResponse as Shape;
            var status = baseResponse as StatusResponse;
            return (shape, status);
        }
    }
}
