using BenchmarkDotNet.Attributes;
using SerializationBenchmarks.Models;
using SolTechnology.Avro;

public partial class BinaryBenchmark
{
    [Benchmark, BenchmarkCategory("Serialization", "Binary"), ArgumentsSource(nameof(GenerateDataSets))]
    public byte[] AvroConvert_Serialize(DataSet data)
    {
        return DataConvert_AvroConvert(data.Payload);
    }
    
    [Benchmark, BenchmarkCategory("Deserialization", "Binary"), ArgumentsSource(nameof(GenerateDataSets))]
    public List<User> AvroConvert_Deserialize(DataSet data)
    {
        return AvroConvert.Deserialize<List<User>>(data.SerializedData.AvroConvert);
    }

    private byte[] DataConvert_AvroConvert(List<User> users) => AvroConvert.Serialize(users);
}