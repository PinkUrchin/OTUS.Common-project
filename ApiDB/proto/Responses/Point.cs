using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Protocol.Common
{
    public class Point
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
        [JsonProperty("PointNum")]
        public int PointNum { get; set; }
        [JsonProperty("X")]
        public double X { get; set; }
        [JsonProperty("Y")]
        public double Y { get; set; }
        [JsonProperty("PrimitiveId")]
        public int PrimitiveId { get; set; }
    }
}
