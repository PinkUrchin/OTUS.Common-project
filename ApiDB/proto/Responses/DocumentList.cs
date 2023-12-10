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
    }

    public class DocumentList
    {
        [JsonProperty("Documents")]
        public List<DocumentHeader> Documents { set; get; }
        public DocumentList()
        {
            Documents = new List<DocumentHeader>();
        }
    }
}
