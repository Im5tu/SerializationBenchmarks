using BenchmarkDotNet.Attributes;
using GroBuf;
using GroBuf.DataMembersExtracters;
using SerializationBenchmarks.Models;

public partial class BinaryBenchmark
{
    private readonly Serializer _groSerializer = new Serializer(new PropertiesExtractor(), options : GroBufOptions.WriteEmptyObjects);

    
    [Benchmark, BenchmarkCategory("Serialization", "Binary"), ArgumentsSource(nameof(GenerateDataSets))]
    public byte[] GroBuf_Serialize(DataSet data)
    {
        return DataConvert_GroBuf(data.Payload);
    }
    
    [Benchmark, BenchmarkCategory("Deserialization", "Binary"), ArgumentsSource(nameof(GenerateDataSets))]
    public List<User> GroBuf_Deserialize(DataSet data)
    {
        return _groSerializer.Deserialize<List<User>>(data.SerializedData.GroBuf);
    }
    
    private byte[] DataConvert_GroBuf(List<User> users)
    {
        return _groSerializer.Serialize(users);
    }
}