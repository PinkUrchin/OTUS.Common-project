using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protocol.Common
{
    public interface IDocumentListResponse : IResponse
    {
        [JsonProperty("Documents")]
        List<DocumentHeader> Documents { set; get; }
    }
    public class DocumentList: BaseResponse, IDocumentListResponse
    {
        [JsonProperty("Documents")]
        public List<DocumentHeader> Documents { set; get; }
        public DocumentList(): base (ResponseName.DocumentList)
        {
            Documents = new List<DocumentHeader>();
        }
    }
}
