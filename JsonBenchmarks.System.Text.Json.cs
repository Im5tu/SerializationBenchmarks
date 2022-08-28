using System.Text.Json;
using BenchmarkDotNet.Attributes;
using SerializationBenchmarks.Models;

public partial class JsonBenchmark
{
    [Benchmark(Baseline = true), BenchmarkCategory("Serialization", "Json"), ArgumentsSource(nameof(GenerateDataSets))]
    public string SystemTextJson_Serialize(DataSet data)
    {
        return System.Text.Json.JsonSerializer.Serialize(data.Payload, _systemTextJsonOptions);
    }
    
    [Benchmark(Baseline = true), BenchmarkCategory("Deserialization", "Json"), ArgumentsSource(nameof(GenerateDataSets))]
    public List<User> SystemTextJson_Deserialize(DataSet data)
    {
        return System.Text.Json.JsonSerializer.Deserialize<List<User>>(data.Json, _systemTextJsonOptions);
    }
}