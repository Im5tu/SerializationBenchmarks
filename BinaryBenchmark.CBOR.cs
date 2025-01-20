using BenchmarkDotNet.Attributes;
using Dahomey.Cbor;
using SerializationBenchmarks.Converters.Cbor;
using SerializationBenchmarks.Models;

public partial class BinaryBenchmark
{
    private static readonly CborOptions _options = new();

    static BinaryBenchmark()
    {
        _options.Registry.ConverterRegistry.RegisterConverter(typeof(Guid), new GuidConverter());
    }
    
    [Benchmark, BenchmarkCategory("Serialization", "Binary"), ArgumentsSource(nameof(GenerateDataSets))]
    public Task<byte[]> CBOR_Serialize(DataSet data)
    {
        return DataConvert_CBOR(data.Payload);
    }
    
    [Benchmark, BenchmarkCategory("Deserialization", "Binary"), ArgumentsSource(nameof(GenerateDataSets))]
    public ValueTask<List<User>> CBOR_Deserialize(DataSet data)
    {
        using var ms = new MemoryStream(data.SerializedData.CBOR);
        return Cbor.DeserializeAsync<List<User>>(ms, _options);
    }
    
    private async Task<byte[]> DataConvert_CBOR(List<User> users)
    {
        using var ms = new MemoryStream();
        await Cbor.SerializeAsync(users, ms, _options).ConfigureAwait(false);
        return ms.ToArray();
    }
}