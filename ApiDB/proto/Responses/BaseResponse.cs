using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using protocol.Requests;
using Protocol.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protocol.Common
{ 
    public interface IResponse
    {
        [JsonProperty("ClassName")]
        public string ClassName { get; set; }
    }
    public  class BaseResponse: IResponse
    {
        [JsonProperty("ClassName")]
        public string ClassName { get; set; }

        public static IResponse ReadResponse(string data)
        {
            return JsonConvert.DeserializeObject<IResponse>(data, new ResponseConverter());
        }

        public BaseResponse(string classname)
        {
            ClassName = classname;
        }
    }

    internal class ResponseConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(IResponse).IsAssignableFrom(objectType);
        }

        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            var jo = JObject.Load(reader);
            if (!jo.ContainsKey("ClassName"))
                return null;
            var classname = jo["ClassName"].Value<string>();
            var response = ResponseMaker.CreateResponse(classname);
            if (response == null)
                return null;
            serializer.Populate(jo.CreateReader(), response);
            return response;
        }

        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }

    public static class ResponseMaker
    {
        private delegate IResponse Maker();
        private static Dictionary<string, Maker> m_makers = new Dictionary<string, Maker> {
            { ResponseName.DocumentList, ()=>{return new DocumentList(); } },
            { ResponseName.Document, ()=>{return new Document(); } },
            { ResponseName.Status, ()=>{return new StatusResponse(); } },
            { ResponseName.Shape, ()=>{return new Shape(); } }
        };
        public static IResponse CreateResponse(string classname)
        {
            if (!m_makers.TryGetValue(classname, out var maker))
                return null;
            return maker();
        }
    }
}
