using Newtonsoft.Json;
using Protocol.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protocol.Common
{
    public interface IGetListDocuments : IRequest
    {
        string UserName { get; set; }
    }
    public class GetListDocumentsRequest : Request, IGetListDocuments
    {
        [JsonProperty("user_name")]
        public string UserName { get; set; }
        public GetListDocumentsRequest() : base(Actions.GetListDocuments) { }
    }
}
