using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace XmMovies
{
    class RootObjectPeop
    {
        [JsonProperty("page")]
        public int page { get; set; }

        [JsonProperty("total_results")]
        public int total_results { get; set; }

        [JsonProperty("total_pages")]
        public int total_pages { get; set; }

        [JsonProperty("results")]
        public List<ResultPeop> results { get; set; }
    }
}
