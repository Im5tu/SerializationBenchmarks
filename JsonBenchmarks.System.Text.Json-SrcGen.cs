using System.Text.Json;
using System.Text.Json.Serialization;
using BenchmarkDotNet.Attributes;
using SerializationBenchmarks.Models;

public partial class JsonBenchmark
{
    [Benchmark, BenchmarkCategory("Serialization", "Json"), ArgumentsSource(nameof(GenerateDataSets))]
    public string SystemTextJson_SrcGen_Serialize(DataSet data)
    {
        return System.Text.Json.JsonSerializer.Serialize(data.Payload, DatasetSerializerContext.Benchmark.ListUser);
    }
    
    [Benchmark, BenchmarkCategory("Deserialization", "Json"), ArgumentsSource(nameof(GenerateDataSets))]
    public List<User> SystemTextJson_SrcGen_Deserialize(DataSet data)
    {
        return System.Text.Json.JsonSerializer.Deserialize<List<User>>(data.Json, DatasetSerializerContext.Benchmark.ListUser);
    }
}

[JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
[JsonSerializable(typeof(List<User>))]
public partial class DatasetSerializerContext : JsonSerializerContext
{
    internal static DatasetSerializerContext Benchmark { get; }

    static DatasetSerializerContext()
    {
        var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
        options.Converters.Add(new JsonStringEnumConverter());
        Benchmark = new DatasetSerializerContext(options);
    }
}