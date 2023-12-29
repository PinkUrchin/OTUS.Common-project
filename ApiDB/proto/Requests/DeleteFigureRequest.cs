using Newtonsoft.Json;
using Protocol.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace protocol.Requests
{
    public interface IDeleteShapeRequest
    {
        string UserName { get; set; }
        int DocumentId { get; set; }
        string ShapeInfo { get; set; }
    }

    public class DeleteShapeRequest : Request, IDeleteShapeRequest
    {
        [JsonProperty("user_name")]
        public string UserName { get; set; }
        [JsonProperty("document_id")]
        public int DocumentId { get; set; }
        [JsonProperty("Shape_info")]
        public string ShapeInfo { get; set; }
        public DeleteShapeRequest() : base(Actions.DeleteShape) { }
    }
}
