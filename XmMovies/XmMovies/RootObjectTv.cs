﻿using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace XmMovies
{
    class RootObjectTv
    {
        [JsonProperty("page")]
        public int page { get; set; }

        [JsonProperty("total_results")]
        public int total_results { get; set; }

        [JsonProperty("total_pages")]
        public int total_pages { get; set; }

        [JsonProperty("results")]
        public List<ResultTv> results { get; set; }
    }
}