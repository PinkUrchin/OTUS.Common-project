using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protocol.Common
{
    public interface ICreateShapeRequest: IRequest
    {
        string UserName { get; set; }
        int DocumentId { get; set; }
        string ShapeInfo { get; set; }
    }
    public class CreateShapeRequest : Request, ICreateShapeRequest
    {
        [JsonProperty("user_name")]
        public string UserName { get; set; }
        [JsonProperty("document_id")]
        public int DocumentId { get; set; }
        [JsonProperty("Shape_info")]
        public string ShapeInfo { get; set; }
        public CreateShapeRequest() : base(Actions.CreateDocument) { }
    }
}
