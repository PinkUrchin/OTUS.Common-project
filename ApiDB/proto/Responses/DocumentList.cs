using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protocol.Common
{
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
