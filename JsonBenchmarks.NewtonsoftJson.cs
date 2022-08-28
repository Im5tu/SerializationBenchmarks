using BenchmarkDotNet.Attributes;
using SerializationBenchmarks.Models;

public partial class JsonBenchmark
{
    private readonly Newtonsoft.Json.JsonSerializerSettings _newtonsoftSettings 
        = new() { ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver { NamingStrategy = new Newtonsoft.Json.Serialization.CamelCaseNamingStrategy() } };
    
    [Benchmark, BenchmarkCategory("Serialization", "Json"), ArgumentsSource(nameof(GenerateDataSets))]
    public string NewtonsoftJson_Serialize(DataSet data)
    {
        return Newtonsoft.Json.JsonConvert.SerializeObject(data.Payload, _newtonsoftSettings);
    }
    
    [Benchmark, BenchmarkCategory("Deserialization", "Json"), ArgumentsSource(nameof(GenerateDataSets))]
    public List<User> NewtonsoftJson_Deserialize(DataSet data)
    {
        return Newtonsoft.Json.JsonConvert.DeserializeObject<List<User>>(data.Json, _newtonsoftSettings);
    }
}