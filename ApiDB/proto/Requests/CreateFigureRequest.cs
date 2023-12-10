using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protocol.Common
{
    public interface ICreateFigureRequest: IRequest
    {
        string UserName { get; set; }
        int DocumentId { get; set; }
        string FigureInfo { get; set; }
    }
    public class CreateFigureRequest : Request, ICreateFigureRequest
    {
        [JsonProperty("user_name")]
        public string UserName { get; set; }
        [JsonProperty("document_id")]
        public int DocumentId { get; set; }
        [JsonProperty("figure_info")]
        public string FigureInfo { get; set; }
        public CreateFigureRequest() : base(Actions.CreateDocument) { }
    }
}
