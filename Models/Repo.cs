using System;
using System.Text.Json.Serialization;

namespace console_weatherapp
{
    public class Repository
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
    
}