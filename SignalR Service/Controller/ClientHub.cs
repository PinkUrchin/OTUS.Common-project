using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;

namespace SignalR_Service.Controller
{
    public class ClientHub : Hub
    {
        /// <summary>
        /// Return document by ID
        /// </summary>
        /// <param name="idDocument">ID Document</param>
        /// <returns>Document</returns>
        [HttpGet]
        public async Task GetDocumentById(int idDocument, string userName)
        {
            string doc = "";
            await Clients.Caller.SendAsync("GetDocumentById", doc, userName);
        }

        /// <summary>
        /// Return list documents
        /// </summary>
        /// <returns>List documents</returns>
        [HttpGet]
        public async Task GetListDocuments(string userName)
        {
            List<string> list = new List<string>();
            await Clients.Caller.SendAsync("GetListDocuments", list, userName);
        }

        /// <summary>
        /// Create document
        /// </summary>
        /// <param name="name">Name document</param>
        /// <returns>Successful create document</returns>
        [HttpPost]
        public async Task CreateDocument(string name, string userName)
        {
            int? idDocument = null;
            string doc = "";
            await Clients.All.SendAsync("CreateDocument", doc, idDocument, userName);
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
            bool success = true;
            await Clients.All.SendAsync("DeleteDocumentById", success, userName);
        }

        /// <summary>
        /// Create figure in document
        /// </summary>
        /// <param name="idDocument">ID document</param>
        /// <param name="figureInfo">Information about figure (coords, type) in JSON format.</param>
        /// <param name="userName">Username</param>
        /// <returns>All info about operation</returns>
        [HttpPost]
        public async Task CreateFigure(int idDocument, string figureInfo, string userName)
        {
            int? idFigure = null;
            await Clients.All.SendAsync("CreateFigure", idDocument, figureInfo, idFigure, userName);
        }

        /// <summary>
        /// Update figure in document
        /// </summary>
        /// <param name="idDocument">ID document</param>
        /// <param name="figureInfo">Information about figure (coords, type) in JSON format.</param>
        /// <param name="userName">Username</param>
        /// <returns>All info about operation</returns>
        [HttpPut]
        public async Task UpdateFigure(int idDocument, string figureInfo, string userName)
        {
            int? idFigure = null;
            await Clients.All.SendAsync("UpdateFigure", idDocument, figureInfo, idFigure, userName);
        }

        /// <summary>
        /// Delete figure in document
        /// </summary>
        /// <param name="idDocument">ID document</param>
        /// <param name="figureInfo">Information about figure (coords, type) in JSON format.</param>
        /// <param name="userName">Username</param>
        /// <returns>All info about operation</returns>
        [HttpDelete]
        public async Task DeleteFigure(int idDocument, string figureInfo, string userName)
        {
            int? idFigure = null;
            await Clients.All.SendAsync("DeleteFigure", idDocument, idFigure, userName);
        }
    }
}
