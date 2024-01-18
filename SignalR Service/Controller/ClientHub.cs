using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
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
        public async Task GetDocumentById(int idDocument, string userName)
        {
            var res = await _serializer.GetDocumentById(idDocument, userName);
            await Clients.Caller.SendAsync("GetDocumentById", res, userName);
        }

        /// <summary>
        /// Return list documents
        /// </summary>
        /// <returns>List documents</returns>
        [HttpGet]
        public async Task GetListDocuments(string userName)
        {
            var res = await _serializer.GetListDocuments(userName);
            await Clients.Caller.SendAsync("GetListDocuments", res, userName);
        }

        /// <summary>
        /// Create document
        /// </summary>
        /// <param name="name">Name document</param>
        /// <returns>Successful create document</returns>
        [HttpPost]
        public async Task CreateDocument(string name, string userName)
        {
            var res = await _serializer.CreateDocument(name, userName);
            await Clients.All.SendAsync("CreateDocument", res, userName);
        }

        /// <summary>
        /// Delete document by id
        /// </summary>
        /// <param name="idDocument">ID document</param>
        /// <param name="userName">Username</param>
        /// <returns>Successful delete document</returns>
        [HttpDelete]
        public async Task DeleteDocumentById(int idDocument, string userName)
        {
            var res = await _serializer.GetDocumentById(idDocument, userName);
            await Clients.All.SendAsync("DeleteDocumentById", res, userName);
        }

        /// <summary>
        /// Create shape in document
        /// </summary>
        /// <param name="idDocument">ID document</param>
        /// <param name="shapeInfo">Information about shape (coords, type) in JSON format.</param>
        /// <param name="userName">Username</param>
        /// <returns>All info about operation</returns>
        [HttpPost]
        public async Task CreateShape(int idDocument, string shapeInfo, string userName)
        {
            var res = await _serializer.CreateShape(idDocument, shapeInfo, userName);
            await Clients.All.SendAsync("CreateShape", res, userName);
        }

        /// <summary>
        /// Update shape in document
        /// </summary>
        /// <param name="idDocument">ID document</param>
        /// <param name="shapeInfo">Information about shape (coords, type) in JSON format.</param>
        /// <param name="userName">Username</param>
        /// <returns>All info about operation</returns>
        [HttpPut]
        public async Task UpdateShape(int idDocument, string shapeInfo, string userName)
        {
            var res = await _serializer.UpdateShape(idDocument, shapeInfo, userName);
            await Clients.All.SendAsync("UpdateShape ", res, userName);
        }

        /// <summary>
        /// Delete shape in document
        /// </summary>
        /// <param name="idDocument">ID document</param>
        /// <param name="shapeInfo">Information about shape (coords, type) in JSON format.</param>
        /// <param name="userName">Username</param>
        /// <returns>All info about operation</returns>
        [HttpDelete]
        public async Task DeleteShape(int idDocument, string shapeInfo, string userName)
        {
            var res = await _serializer.DeleteShape(idDocument, shapeInfo, userName);
            await Clients.All.SendAsync("DeleteShape", res, userName);
        }
    }
}
