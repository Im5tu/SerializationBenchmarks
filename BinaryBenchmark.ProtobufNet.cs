using BenchmarkDotNet.Attributes;
using ProtoBuf;
using SerializationBenchmarks.Models;

public partial class BinaryBenchmark
{
    [Benchmark, BenchmarkCategory("Serialization", "Binary"), ArgumentsSource(nameof(GenerateDataSets))]
    public byte[] ProtoBufNet_Serialize(DataSet data)
    {
        return DataConvert_ProtoBufNet(data.Payload);
    }
    
    [Benchmark, BenchmarkCategory("Deserialization", "Binary"), ArgumentsSource(nameof(GenerateDataSets))]
    public List<User> ProtoBufNet_Deserialize(DataSet data)
    {
        using var ms = new MemoryStream(data.SerializedData.ProtoBufNet);
        return Serializer.Deserialize<List<User>>(ms);
    }
    
    private byte[] DataConvert_ProtoBufNet(List<User> users)
    {
        using var ms = new MemoryStream();
        Serializer.Serialize(ms, users);
        return ms.ToArray();
    }
}