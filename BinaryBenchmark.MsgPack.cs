using BenchmarkDotNet.Attributes;
using MsgPack.Serialization;
using SerializationBenchmarks.Models;

public partial class BinaryBenchmark
{
    private readonly MessagePackSerializer<List<User>> _msgPackSerializer = MessagePackSerializer.Get<List<User>>();

    [Benchmark, BenchmarkCategory("Serialization", "Binary"), ArgumentsSource(nameof(GenerateDataSets))]
    public byte[] MsgPack_Serialize(DataSet data)
    {
        return DataConvert_MsgPack(data.Payload);
    }
    
    [Benchmark, BenchmarkCategory("Deserialization", "Binary"), ArgumentsSource(nameof(GenerateDataSets))]
    public List<User> MsgPack_Deserialize(DataSet data)
    {
        return _msgPackSerializer.UnpackSingleObject(data.SerializedData.MsgPack);
    }
    
    private byte[] DataConvert_MsgPack(List<User> users)
    {
        return _msgPackSerializer.PackSingleObject(users);
    }
}