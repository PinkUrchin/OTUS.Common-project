using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protocol.Common
{
    public class Primitive
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
        [JsonProperty("Shape")]
        public byte Shape { get; set; }
        [JsonProperty("CreateDate")]
        public DateTime CreateDate { get; set; }
        [JsonProperty("UpdateDate")]
        public DateTime UpdateDate { get; set; }
        [JsonProperty("CreateAuthor")]
        public string CreateAuthor { get; set; }
        [JsonProperty("Red")]
        public byte Red { get; set; }
        [JsonProperty("Green")]
        public byte Green { get; set; }
        [JsonProperty("Blue")]
        public byte Blue { get; set; }
        [JsonProperty("DocumentId")]
        public int DocumentId { get; set; }
        [JsonProperty("Points")]
        public List<Point> Points { get; set; }
    }
}
