﻿using System.Text.Json.Serialization;

namespace WheaterApi.Model
{
    public class WheaterModel
    {
        [JsonPropertyName("latitude")]
        public double Latitude { get; set; }

        [JsonPropertyName("longitude")]
        public double Longitude { get; set; }


    }
}
