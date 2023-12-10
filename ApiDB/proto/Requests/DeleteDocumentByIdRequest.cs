using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protocol.Common
{
    public interface IDeleteDocumentByIdRequest: IRequest
    {
        string UserName { get; set; }
        int DocumentId { get; set; }
    }
    public class DeleteDocumentByIdRequest : Request, IDeleteDocumentByIdRequest
    {
        [JsonProperty("user_name")]
        public string UserName { get; set; }
        [JsonProperty("document_id")]
        public int DocumentId { get; set; }
        public DeleteDocumentByIdRequest() : base(Actions.DeleteDocumentById) { }
    }
}
