using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protocol.Common
{
    public class DocumentHeader
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
        [JsonProperty("Title")]
        public string Title { get; set; }
        [JsonProperty("UserName")]
        public string UserName { get; set; }
        [JsonProperty("CreateDate")]
        public DateTime CreateDate { get; set; }
        [JsonProperty("UpdateDate")]
        public DateTime UpdateDate { get; set; }
        [JsonProperty("UpdateAuthor")]
        public string UpdateAuthor { get; set; }
        [JsonProperty("CreateAuthor")]
        public string CreateAuthor { get; set; }
    }
    public class Document
    {
        [JsonProperty("Header")]
        public DocumentHeader Header { get; set; }
        [JsonProperty("Body")]
        public List<Shape> Body { get; set; }
    }
}
