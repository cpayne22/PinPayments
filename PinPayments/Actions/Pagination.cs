using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace PinPayments.Actions
{
    public class Pagination
    {
        [JsonProperty("current")]
        public int Current { get; set; }

        [JsonProperty("previous")]
        public int? Previous { get; set; }

        [JsonProperty("next")]
        public int? Next { get; set; }

        [JsonProperty("per_page")]
        public int PageSize { get; set; }

        [JsonProperty("pages")]
        public int? Pages { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }

    }
}
