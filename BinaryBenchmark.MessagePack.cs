using BenchmarkDotNet.Attributes;
using MessagePack;
using SerializationBenchmarks.Models;

public partial class BinaryBenchmark
{
    [Benchmark, BenchmarkCategory("Serialization", "Binary"), ArgumentsSource(nameof(GenerateDataSets))]
    public byte[] MessagePack_Serialize(DataSet data)
    {
        return DataConvert_MessagePack(data.Payload);
    }
    
    [Benchmark, BenchmarkCategory("Deserialization", "Binary"), ArgumentsSource(nameof(GenerateDataSets))]
    public List<User> MessagePack_Deserialize(DataSet data)
    {
        return MessagePackSerializer.Deserialize<List<User>>(data.SerializedData.MessagePack);
    }
    
    private byte[] DataConvert_MessagePack(List<User> users)
    {
        return MessagePackSerializer.Serialize(users);
    }
}