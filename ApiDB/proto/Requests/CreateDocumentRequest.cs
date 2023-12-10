using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protocol.Common
{
    public interface ICreateDocumentRequest: IRequest
    {
        string UserName { get; set; }
        string DocumentName { get; set; }
    }
    public class CreateDocumentRequest : Request, ICreateDocumentRequest
    {
        [JsonProperty("user_name")]
        public string UserName { get; set; }
        [JsonProperty("document_name")]
        public string DocumentName { get; set; }
        public CreateDocumentRequest() : base(Actions.CreateDocument) { }
    }
}
