using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protocol.Common
{   
    public interface IShapeRequest: IRequest
    {        
        public int Id { get; set; }
        public int DocumentId { get; set; }
        public byte ShapeType { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string CreateAuthor { get; set; }
        public string UpdateAuthor { get; set; }
        public string Color { get; set; }
        public string Coords { get; set; }
    }
    public class ShapeRequest : Request, IShapeRequest
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("document_id")]
        public int DocumentId { get; set; }

        [JsonProperty("shape_type")]
        public byte ShapeType { get; set; }

        [JsonProperty("create_date")]
        public DateTime CreateDate { get; set; }

        [JsonProperty("update_date")]
        public DateTime UpdateDate { get; set; }

        [JsonProperty("create_author")]
        public string CreateAuthor { get; set; }

        [JsonProperty("update_author")]
        public string UpdateAuthor { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("coords")]
        public string Coords { get; set; }

        public ShapeRequest() : base(Actions.CreateShape) { }
    }
}
