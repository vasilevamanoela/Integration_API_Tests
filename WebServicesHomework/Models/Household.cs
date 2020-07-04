namespace WebServicesHomework.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    public partial class Household
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("updatedAt", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? UpdatedAt { get; set; }

        [JsonProperty("createdAt", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? CreatedAt { get; set; }

        [JsonProperty("links", NullValueHandling = NullValueHandling.Ignore)]
        public List<Link> Links { get; set; }

        public static Household FromJson(string json) => JsonConvert.DeserializeObject<Household>(json, WebServicesHomework.Models.Converter.Settings);
    }
}
