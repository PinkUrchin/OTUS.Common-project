using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protocol.Common
{
    public class Shape
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
        [JsonProperty("Color")]
        public string  Color { get; set; }
     
        [JsonProperty("DocumentId")]
        public int DocumentId { get; set; }
        [JsonProperty("Coords")]
        public string Coords { get; set; }
    }
}
