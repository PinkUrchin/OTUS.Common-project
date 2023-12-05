using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Protocol.Common
{
    public static class Actions
    {
        public static readonly string GetListDocuments = "GetListDocuments";
    }
    public interface IRequest
    {
        [JsonProperty("Action")]
        public string Action { get; set; }
    }
    public class Request: IRequest
    {
        [JsonProperty("Action")]
        public string Action { get; set; }
        public Request(string action_name)
        {
            Action = action_name;
        }
        public static IRequest ReadRequest(string data)
        {
            return JsonConvert.DeserializeObject<IRequest>(data, new RequestConverter());
        }
    }
    public interface IGetListDocuments : IRequest
    {
        string UserName { get; set; }
    }
    public class GetListDocumentsRequest : Request, IGetListDocuments
    {
        [JsonProperty("user_name")]
        public string UserName { get; set; }
        public GetListDocumentsRequest() : base(Actions.GetListDocuments) { }
    }
    public static class RequestMaker
    {
        private delegate IRequest Maker();
        private static Dictionary<string, Maker> m_makers = new Dictionary<string, Maker> {
            { Actions.GetListDocuments, ()=>{return new GetListDocumentsRequest(); } } };
        public static IRequest CreateRequest(string action)
        {
            if (!m_makers.TryGetValue(action, out var maker))
                return null;
            return maker();
        }
    }
    internal class RequestConverter: JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(IRequest).IsAssignableFrom(objectType);
        }

        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            var jo = JObject.Load(reader);
            if (!jo.ContainsKey("Action"))
                return null;
            var action = jo["Action"].Value<string>();
            var request = RequestMaker.CreateRequest(action);
            if (request == null)
                return null;
            serializer.Populate(jo.CreateReader(), request);
            return request;
        }

        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }

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