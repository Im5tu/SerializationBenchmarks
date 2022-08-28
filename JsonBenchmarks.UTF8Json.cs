using BenchmarkDotNet.Attributes;
using SerializationBenchmarks.Models;

public partial class JsonBenchmark
{
    [Benchmark, BenchmarkCategory("Serialization", "Json"), ArgumentsSource(nameof(GenerateDataSets))]
    public byte[] UTF8Json_Serialize(DataSet data)
    {
        return Utf8Json.JsonSerializer.Serialize(data.Payload, Utf8Json.Resolvers.StandardResolver.CamelCase);
    }
    
    [Benchmark, BenchmarkCategory("Deserialization", "Json"), ArgumentsSource(nameof(GenerateDataSets))]
    public List<User> UTF8Json_Deserialize(DataSet data)
    {
        return Utf8Json.JsonSerializer.Deserialize<List<User>>(data.Json, Utf8Json.Resolvers.StandardResolver.CamelCase); 
    }
}