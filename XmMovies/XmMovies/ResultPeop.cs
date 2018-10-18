using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace XmMovies
{
    public class ResultPeop
    {
        [JsonProperty("popularity")]
        public double popularity { get; set; }

        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("profile_path")]
        public string profile_path { get; set; }

        [JsonProperty("name")]
        public string nombreLista { get; set; }

        [JsonProperty("known_for")]
        public List<KnownForPeop> known_for { get; set; }

        [JsonProperty("adult")]
        public bool adult { get; set; }
        
    }
}
