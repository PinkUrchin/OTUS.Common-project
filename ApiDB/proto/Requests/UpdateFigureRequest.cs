using Newtonsoft.Json;
using Protocol.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace protocol.Requests
{
    public interface IUpdateFigureRequest: IRequest
    {
        string UserName { get; set; }
        int DocumentId { get; set; }
        string FigureInfo { get; set; }
    }

    public class UpdateFigureRequest : Request, IUpdateFigureRequest
    {
        [JsonProperty("user_name")]
        public string UserName { get; set; }
        [JsonProperty("document_id")]
        public int DocumentId { get; set; }
        [JsonProperty("figure_info")]
        public string FigureInfo { get; set; }
        public UpdateFigureRequest() : base(Actions.UpdateFigure) { }
    }
}
