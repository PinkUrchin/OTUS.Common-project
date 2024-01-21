using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protocol.Common
{
    public interface IShape : IResponse
    {
        [JsonProperty("Id")]
        int Id { get; set; }
        [JsonProperty("ShapeType")]
        byte ShapeType { get; set; }
        [JsonProperty("CreateDate")]
        DateTime CreateDate { get; set; }
        [JsonProperty("UpdateDate")]
        DateTime UpdateDate { get; set; }

        [JsonProperty("CreateAuthor")]
        string CreateAuthor { get; set; }

        [JsonProperty("UpdateAuthor")]
        string UpdateAuthor { get; set; }

        [JsonProperty("Color")]
        string Color { get; set; }

        [JsonProperty("DocumentId")]
        int DocumentId { get; set; }
        [JsonProperty("Coords")]
        string Coords { get; set; }
    }
    public class Shape: BaseResponse, IShape
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
        [JsonProperty("ShapeType")]
        public byte ShapeType { get; set; }
        [JsonProperty("CreateDate")]
        public DateTime CreateDate { get; set; }
        [JsonProperty("UpdateDate")]
        public DateTime UpdateDate { get; set; }

        [JsonProperty("CreateAuthor")]
        public string CreateAuthor { get; set; }

        [JsonProperty("UpdateAuthor")]
        public string UpdateAuthor { get; set; }
        
        [JsonProperty("Color")]
        public string  Color { get; set; }
     
        [JsonProperty("DocumentId")]
        public int DocumentId { get; set; }
        [JsonProperty("Coords")]
        public string Coords { get; set; }

        public Shape() : base(ResponseName.Shape) { }
    }
}
