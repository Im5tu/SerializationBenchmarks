using BenchmarkDotNet.Attributes;
using MemoryPack;
using SerializationBenchmarks.Models;

public partial class BinaryBenchmark
{
    [Benchmark, BenchmarkCategory("Serialization", "Binary"), ArgumentsSource(nameof(GenerateDataSets))]
    public byte[] MemoryPack_Serialize(DataSet data)
    {
        return DataConvert_MemoryPack(data.Payload);
    }
    
    [Benchmark, BenchmarkCategory("Deserialization", "Binary"), ArgumentsSource(nameof(GenerateDataSets))]
    public List<User> MemoryPack_Deserialize(DataSet data)
    {
        return MemoryPackSerializer.Deserialize<List<User>>(data.SerializedData.MemoryPack);
    }
    
    private byte[] DataConvert_MemoryPack(List<User> users)
    {
        return MemoryPackSerializer.Serialize(users);
    }
}