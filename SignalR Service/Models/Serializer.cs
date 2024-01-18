using System.Net.Sockets;
using Newtonsoft.Json;
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
        public async Task<string> CreateDocument(string name, string userName)
        {
            RequestDocumentName requestDocument = new RequestDocumentName(userName, name);
            var response = await RpcHelper.DoRPCRequestAsync(JsonConvert.SerializeObject(requestDocument));
            return response;
        }

        public async Task<string> CreateShape(int idDocument, string shapeInfo, string userName)
        {
            RequestShape requestShape = new RequestShape(userName, idDocument, shapeInfo);
            var response = await RpcHelper.DoRPCRequestAsync(JsonConvert.SerializeObject(requestShape));
            return response;
        }

        public async Task<string> DeleteDocumentById(int idDocument, string userName)
        {
            RequestDocument requestDocument = new RequestDocument(userName, idDocument);
            var response = await RpcHelper.DoRPCRequestAsync(JsonConvert.SerializeObject(requestDocument));
            return response;
        }

        public async Task<string> DeleteShape(int idDocument, string shapeInfo, string userName)
        {
            RequestShape requestShape = new RequestShape(userName, idDocument, shapeInfo);
            var response = await RpcHelper.DoRPCRequestAsync(JsonConvert.SerializeObject(requestShape));
            return response;
        }

        public async Task<string> GetDocumentById(int idDocument, string userName)
        {
            RequestDocument requestDocument = new RequestDocument(userName, idDocument);
            var response = await RpcHelper.DoRPCRequestAsync(JsonConvert.SerializeObject(requestDocument));
            return response;
        }

        public async Task<string> GetListDocuments(string userName)
        {
            RequestUser requestUser = new RequestUser(userName);
            var response = await RpcHelper.DoRPCRequestAsync(JsonConvert.SerializeObject(requestUser));
            return response;
        }

        public async Task<string> UpdateShape(int idDocument, string shapeInfo, string userName)
        {
            RequestShape requestShape = new RequestShape(userName, idDocument, shapeInfo);
            var response = await RpcHelper.DoRPCRequestAsync(JsonConvert.SerializeObject(requestShape));
            return response;
        }
    }
}
