using BenchmarkDotNet.Attributes;
using SerializationBenchmarks.Models;

public partial class JsonBenchmark
{
    private Jil.Options _jilOptions = new(serializationNameFormat: Jil.SerializationNameFormat.CamelCase);
    
    [Benchmark, BenchmarkCategory("Serialization", "Json"), ArgumentsSource(nameof(GenerateDataSets))]
    public string Jil_Serialize(DataSet data)
    {
        return Jil.JSON.Serialize(data.Payload, _jilOptions);
    }
    
    [Benchmark, BenchmarkCategory("Deserialization", "Json"), ArgumentsSource(nameof(GenerateDataSets))]
    public List<User> Jil_Deserialize(DataSet data)
    {
        return Jil.JSON.Deserialize<List<User>>(data.Json, _jilOptions);
    }
}