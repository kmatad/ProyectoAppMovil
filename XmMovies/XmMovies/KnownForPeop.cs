﻿using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace XmMovies
{
    public class KnownForPeop
    {
        [JsonProperty("vote_average")]
        public double vote_average { get; set; }

        [JsonProperty("vote_count")]
        public int vote_count { get; set; }

        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("video")]
        public bool video { get; set; }

        [JsonProperty("media_type")]
        public string media_type { get; set; }

        [JsonProperty("title")]
        public string title { get; set; }

        [JsonProperty("popularity")]
        public double popularity { get; set; }

        [JsonProperty("poster_path")]
        public string poster_path { get; set; }

        [JsonProperty("original_language")]
        public string original_language { get; set; }

        [JsonProperty("original_title")]
        public string original_title { get; set; }

        [JsonProperty("genre_ids")]
        public List<int> genre_ids { get; set; }

        [JsonProperty("backdrop_path")]
        public string backdrop_path { get; set; }

        [JsonProperty("adult")]
        public bool adult { get; set; }

        [JsonProperty("overview")]
        public string overview { get; set; }

        [JsonProperty("release_date")]
        public string release_date { get; set; }
    }
}
