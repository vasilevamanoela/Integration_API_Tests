namespace WebServicesHomework.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    public partial class Book
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty("author", NullValueHandling = NullValueHandling.Ignore)]
        public string Author { get; set; }

        [JsonProperty("isbn", NullValueHandling = NullValueHandling.Ignore)]
        public string Isbn { get; set; }

        [JsonProperty("publicationDate", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? PublicationDate { get; set; }

        [JsonProperty("updatedAt", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? UpdatedAt { get; set; }

        [JsonProperty("createdAt", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? CreatedAt { get; set; }

        [JsonProperty("links", NullValueHandling = NullValueHandling.Ignore)]
        public List<Link> Links { get; set; }

        public static Book FromJson(string json) => JsonConvert.DeserializeObject<Book>(json, WebServicesHomework.Models.Converter.Settings);
    }
}
