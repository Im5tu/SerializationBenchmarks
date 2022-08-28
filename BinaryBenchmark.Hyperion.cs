using BenchmarkDotNet.Attributes;
using Hyperion;
using SerializationBenchmarks.Models;

public partial class BinaryBenchmark
{
    private readonly Serializer _hyperionSerializer= new Hyperion.Serializer();

    
    [Benchmark, BenchmarkCategory("Serialization", "Binary"), ArgumentsSource(nameof(GenerateDataSets))]
    public byte[] Hyperion_Serialize(DataSet data)
    {
        return DataConvert_Hyperion(data.Payload);
    }
    
    [Benchmark, BenchmarkCategory("Deserialization", "Binary"), ArgumentsSource(nameof(GenerateDataSets))]
    public List<User> Hyperion_Deserialize(DataSet data)
    {
        using var ms = new MemoryStream(data.SerializedData.Hyperion);
        ms.Position = 0;
        return _hyperionSerializer.Deserialize<List<User>>(ms);
    }
    
    private byte[] DataConvert_Hyperion(List<User> users)
    {
        using var ms = new MemoryStream();
        _hyperionSerializer.Serialize(users, ms);
        return ms.ToArray();
    }
}