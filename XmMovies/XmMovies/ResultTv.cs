using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace XmMovies
{
    public class ResultTv
    {
        [JsonProperty("original_name")]
        public string original_name { get; set; }

        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("name")]
        public string nombreLista { get; set; }

        [JsonProperty("vote_count")]
        public int vote_count { get; set; }

        [JsonProperty("vote_average")]
        public double vote_average { get; set; }

        [JsonProperty("poster_path")]
        public string poster_path { get; set; }

        [JsonProperty("first_air_date")]
        public string first_air_date { get; set; }

        [JsonProperty("popularity")]
        public double popularity { get; set; }

        [JsonProperty("genre_ids")]
        public List<int> genre_ids { get; set; }

        [JsonProperty("original_language")]
        public string original_language { get; set; }

        [JsonProperty("backdrop_path")]
        public string backdrop_path { get; set; }

        [JsonProperty("overview")]
        public string overview { get; set; }

        [JsonProperty("origin_country")]
        public List<string> origin_country { get; set; }
        
    }
}
