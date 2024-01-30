using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Protocol.Common;
using SignalR_Service.Models;

namespace SignalR_Service.Controller
{
    public class ClientHub : Hub
    {
        private Serializer _serializer = new Serializer();
        /// <summary>
        /// Return document by ID
        /// </summary>
        /// <param name="idDocument">ID Document</param>
        /// <returns>Document</returns>
        [HttpGet]
        public async Task GetDocumentById(int idDocument, string userName, Guid guid)
        {
            var res = await _serializer.GetDocumentById(idDocument, userName);
            await Clients.Caller.SendAsync(SignalRMethod.GetDocumentById, res, userName, guid);
        }

        /// <summary>
        /// Return list documents
        /// </summary>
        /// <returns>List documents</returns>
        [HttpGet]
        public async Task GetListDocuments(string userName, Guid guid)
        {
            var res = await _serializer.GetListDocuments(userName);
            await Clients.Caller.SendAsync(SignalRMethod.GetListDocuments, res, userName, guid);
        }

        /// <summary>
        /// Create document
        /// </summary>
        /// <param name="name">Name document</param>
        /// <returns>Successful create document</returns>
        [HttpPost]
        public async Task CreateDocument(string name, string userName, Guid guid)
        {
            var res = await _serializer.CreateDocument(name, userName);
            await Clients.All.SendAsync(SignalRMethod.CreateDocument, res.Item1, res.Item2, guid);
        }

        /// <summary>
        /// Delete document by id
        /// </summary>
        /// <param name="idDocument">ID document</param>
        /// <param name="userName">Username</param>
        /// <returns>Successful delete document</returns>
        [HttpDelete]
        public async Task DeleteDocumentById(int idDocument, string userName, Guid guid)
        {
            var res = await _serializer.DeleteDocumentById(idDocument, userName);
            await Clients.All.SendAsync(SignalRMethod.DeleteDocumentById, res, userName, guid);
        }

        /// <summary>
        /// Create shape in document
        /// </summary>
        /// <param name="idDocument">ID document</param>
        /// <param name="shapeInfo">Information about shape (coords, type) in JSON format.</param>
        /// <param name="userName">Username</param>
        /// <returns>All info about operation</returns>
        [HttpPost]
        public async Task CreateShape(Shape shapeInfo, string userName, Guid guid)
        {
            var res = await _serializer.CreateShape(shapeInfo.DocumentId, shapeInfo, userName);
            await Clients.All.SendAsync( SignalRMethod.CreateShape, res.Item1, res.Item2, guid);
        }

        /// <summary>
        /// Update shape in document
        /// </summary>
        /// <param name="idDocument">ID document</param>
        /// <param name="shapeInfo">Information about shape (coords, type) in JSON format.</param>
        /// <param name="userName">Username</param>
        /// <returns>All info about operation</returns>
        [HttpPut]
        public async Task UpdateShape(Shape shape, string userName, Guid guid)
        {
            var res = await _serializer.UpdateShape(shape.DocumentId, shape, userName);
            await Clients.All.SendAsync( SignalRMethod.UpdateShape, res.Item1, res.Item2, guid);
        }

        /// <summary>
        /// Delete shape in document
        /// </summary>
        /// <param name="idDocument">ID document</param>
        /// <param name="shapeInfo">Information about shape (coords, type) in JSON format.</param>
        /// <param name="userName">Username</param>
        /// <returns>All info about operation</returns>
        [HttpDelete]
        public async Task DeleteShape(Shape shape, string userName, Guid guid)
        {
            var res = await _serializer.DeleteShape(shape, userName);
            await Clients.All.SendAsync( SignalRMethod.DeleteShape, res.Item1, res.Item2, guid);
        }
    }
}
