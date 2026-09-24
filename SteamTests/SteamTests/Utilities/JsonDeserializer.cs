using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace SteamTests.Utilities
{
    public class JsonDeserializer
    {
        public T Deserialize<T>(string path)
        {
            string json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<T>(json) ?? throw new InvalidOperationException($"Could not deserialize file: {path}");
        }
    }
}
