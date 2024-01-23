using System.Net.Sockets;
using Newtonsoft.Json;
using protocol.Requests;
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
            CreateDocumentRequest requestDocument = new CreateDocumentRequest();
            requestDocument.DocumentName = name;
            requestDocument.UserName = userName;
            var response = await RpcHelper.DoRPCRequestAsync(JsonConvert.SerializeObject(requestDocument));
            var baseResponse = BaseResponse.ReadResponse(response);
            var doc = baseResponse as Document;
            return doc;
        }

        public async Task<(Shape, StatusResponse)> CreateShape(int idDocument, Shape shapeInfo, string userName)
        {
            ShapeRequest requestShape = new ShapeRequest();
            requestShape.CreateAuthor = userName;
            requestShape.DocumentId = idDocument;
            requestShape.Coords = shapeInfo.Coords;
            requestShape.Color = shapeInfo.Color;
            requestShape.ShapeType = shapeInfo.ShapeType;
            var response = await RpcHelper.DoRPCRequestAsync(JsonConvert.SerializeObject(requestShape));
            var baseResponse = BaseResponse.ReadResponse(response);
            var shape = baseResponse as Shape;
            var status = baseResponse as StatusResponse;
            return (shape, status);
        }

        public async Task<StatusResponse> DeleteDocumentById(int idDocument, string userName)
        {
            DeleteDocumentByIdRequest requestDeleteDocument = new DeleteDocumentByIdRequest();
            requestDeleteDocument.DocumentId = idDocument;
            requestDeleteDocument.UserName = userName;
            var response = await RpcHelper.DoRPCRequestAsync(JsonConvert.SerializeObject(requestDeleteDocument));
            var baseResponse = BaseResponse.ReadResponse(response);
            var status = baseResponse as StatusResponse;
            return status;
        }

        public async Task<(Shape, StatusResponse)> DeleteShape(Shape shape, string userName)
        {
            DeleteShapeRequest requestDeleteShape = new DeleteShapeRequest();
            requestDeleteShape.UserName = userName;
            requestDeleteShape.Id = shape.Id;
            var response = await RpcHelper.DoRPCRequestAsync(JsonConvert.SerializeObject(requestDeleteShape));
            var baseResponse = BaseResponse.ReadResponse(response);
            var shapeRes = baseResponse as Shape;
            var status = baseResponse as StatusResponse;
            return (shapeRes, status);
        }

        public async Task<Document> GetDocumentById(int idDocument, string userName)
        {
            GetDocumentByIdRequest requestDocument = new GetDocumentByIdRequest();
            requestDocument.DocumentId = idDocument;
            requestDocument.UserName = userName;
            var response = await RpcHelper.DoRPCRequestAsync(JsonConvert.SerializeObject(requestDocument));
            var baseResponse = BaseResponse.ReadResponse(response);
            var doc = baseResponse as Document;
            return doc;
        }

        public async Task<DocumentList> GetListDocuments(string userName)
        {
            GetListDocumentsRequest requestListDocuments = new GetListDocumentsRequest();
            requestListDocuments.UserName = userName;
            var response = await RpcHelper.DoRPCRequestAsync(JsonConvert.SerializeObject(requestListDocuments));
            var baseResponse = BaseResponse.ReadResponse(response);
            var doc = baseResponse as DocumentList;
            return doc;
        }

        public async Task<(Shape, StatusResponse)> UpdateShape(int idDocument, Shape shapeInfo, string userName)
        {
            ShapeRequest requestUpdateShape = new ShapeRequest();
            requestUpdateShape.ShapeType = shapeInfo.ShapeType;
            requestUpdateShape.Coords = shapeInfo.Coords;
            requestUpdateShape.Color = shapeInfo.Color;
            requestUpdateShape.UpdateAuthor = userName;
            requestUpdateShape.CreateAuthor = shapeInfo.CreateAuthor;
            requestUpdateShape.CreateDate = shapeInfo.CreateDate;
            requestUpdateShape.DocumentId = idDocument;
            requestUpdateShape.Id = shapeInfo.Id;
            var response = await RpcHelper.DoRPCRequestAsync(JsonConvert.SerializeObject(requestUpdateShape));
            var baseResponse = BaseResponse.ReadResponse(response);
            var shape = baseResponse as Shape;
            var status = baseResponse as StatusResponse;
            return (shape, status);
        }
    }
}
