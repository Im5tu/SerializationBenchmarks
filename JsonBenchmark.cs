using System.Text.Json;
using System.Text.Json.Serialization;
using SerializationBenchmarks.Models;

public partial class JsonBenchmark : SerializerBenchmark
{
    private JsonSerializerOptions _systemTextJsonOptions;

    public IEnumerable<DataSet> GenerateDataSets()
    {
        _systemTextJsonOptions = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
        _systemTextJsonOptions.Converters.Add(new JsonStringEnumConverter());
        var sets = new[]
        {
#if DATASET_SMALL            
            new { File = "Data_Small.json", Subset = "Small" },
#endif
#if DATASET_MEDIUM            
            new { File = "Data_Medium.json", Subset = "Medium" },
#endif
#if DATASET_LARGE            
            new { File = "Data_Large.json", Subset = "Large" },
#endif
        };

        foreach (var set in sets)
        {
            var json = File.ReadAllText(set.File);
            yield return new DataSet { Name = set.Subset, Json = json, Payload = JsonSerializer.Deserialize<List<User>>(json, _systemTextJsonOptions) };
        }
    }

    public class DataSet
    {
        public string Name { get; set; }
        public List<User> Payload { get; set; }
        public string Json { get; set; }

        public override string ToString() => Name;
    }
}