﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebAPIClient.Models
{
    public class Repository
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("html_url")]
        public Uri GitHubHomeUrl { get; set; }

        [JsonPropertyName("homepage")]
        public Uri Homepage { get; set; }

        [JsonPropertyName("watchers")]
        public int Watchers { get; set; }

        [JsonPropertyName("pushed_at")]
        public DateTime LastPushUtc { get; set; }
        public DateTime LastPush => LastPushUtc.ToLocalTime();
    }
}
