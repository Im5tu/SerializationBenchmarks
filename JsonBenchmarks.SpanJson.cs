using System.Text;
using BenchmarkDotNet.Attributes;
using SerializationBenchmarks.Models;

public partial class JsonBenchmark
{
    [Benchmark, BenchmarkCategory("Serialization", "Json"), ArgumentsSource(nameof(GenerateDataSets))]
    public ArraySegment<byte> SpanJson_Serialize(DataSet data)
    {
        return SpanJson.JsonSerializer.Generic.Utf8.SerializeToArrayPool<List<User>, SpanJson.Resolvers.ExcludeNullsCamelCaseResolver<byte>>(data.Payload);
    }
    
    [Benchmark, BenchmarkCategory("Deserialization", "Json"), ArgumentsSource(nameof(GenerateDataSets))]
    public List<User> SpanJson_Deserialize(DataSet data)
    {
        ReadOnlySpan<byte> json = Encoding.UTF8.GetBytes(data.Json);
        return SpanJson.JsonSerializer.Generic.Utf8.Deserialize<List<User>, SpanJson.Resolvers.ExcludeNullsCamelCaseResolver<byte>>(json);
    }
}