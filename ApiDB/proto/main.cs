using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Protocol.Common
{
    public static class Actions
    {
        public static readonly string GetListDocuments = "GetListDocuments";
        public static readonly string GetDocumentById = "GetDocumentById";
        public static readonly string CreateDocument = "CreateDocument";
        public static readonly string DeleteDocumentById = "DeleteDocumentById";
        public static readonly string CreateFigure = "CreateFigure";
        public static readonly string UpdateFigure = "UpdateFigure";
        public static readonly string DeleteFigure = "DeleteFigure";
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

    
}