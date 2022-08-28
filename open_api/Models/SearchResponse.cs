using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace open_api.Models
{
    [MetadataType(typeof(Result))]
    public class SearchResponse
    {
        [JsonProperty("result")]
        public Result[] Result { get; set; }
    }

    public class Result
    {
        [JsonProperty("categories")]
        public List<string> Categories { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("icon_url")]
        public string Icon_Url { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("updated_at")]
        public string UpdatedAt { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
