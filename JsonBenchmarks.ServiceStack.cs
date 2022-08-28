using BenchmarkDotNet.Attributes;
using SerializationBenchmarks.Models;

public partial class JsonBenchmark
{
    [Benchmark, BenchmarkCategory("Serialization", "Json"), ArgumentsSource(nameof(GenerateDataSets))]
    public string ServiceStack_Serialize(DataSet data)
    {
        using var config = ServiceStack.Text.JsConfig.With(new ServiceStack.Text.Config
        {
            TextCase = ServiceStack.Text.TextCase.CamelCase
        });
            
        return ServiceStack.Text.JsonSerializer.SerializeToString(data.Payload);
    }

    [Benchmark, BenchmarkCategory("Deserialization", "Json"), ArgumentsSource(nameof(GenerateDataSets))]
    public List<User> ServiceStack_Deserialize(DataSet data)
    {
        using var config = ServiceStack.Text.JsConfig.With(new ServiceStack.Text.Config
        {
            TextCase = ServiceStack.Text.TextCase.CamelCase
        });
        
        return ServiceStack.Text.JsonSerializer.DeserializeFromString<List<User>>(data.Json);
    }
}