using System.Text.Json;
using System.Text.Json.Serialization;
using BenchmarkDotNet.Attributes;
using SerializationBenchmarks.Models;
using SolTechnology.Avro;

public partial class BinaryBenchmark : SerializerBenchmark
{
    public IEnumerable<DataSet> GenerateDataSets()
    {
        var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
        options.Converters.Add(new JsonStringEnumConverter());
        var sets = new[]
        {
#if DATASET_SMALL            
            new { File = "Data_Small.json", Subset = "Small" },
#endif
#if DATASET_MEDIUM            
            new { File = "Data_Medium.json", Subset = "Medium" },
#endif
#if DATASET_LARGE            
            new { File = "Data_Large.json", Subset = "Large" },
#endif
        };

        foreach (var set in sets)
        {
            var json = File.ReadAllText(set.File);
            var users = JsonSerializer.Deserialize<List<User>>(json, options);
            yield return new DataSet
            {
                Name = set.Subset,
                Payload = users,
                SerializedData = new()
                {
                    AvroConvert = DataConvert_AvroConvert(users),
                    BSON = DataConvert_BSON(users),
                    GroBuf = DataConvert_GroBuf(users),
                    Hyperion = DataConvert_Hyperion(users),
                    MessagePack = DataConvert_MessagePack(users),
                    MemoryPack = DataConvert_MemoryPack(users),
                    MsgPack = DataConvert_MsgPack(users),
                    ProtoBufNet = DataConvert_ProtoBufNet(users)
                }
            };
        }
    }

    public class DataSet
    {
        public string Name { get; set; }
        public List<User> Payload { get; set; }
        public SerializedData SerializedData { get; set; }
        public override string ToString() => Name;
    }

    public class SerializedData
    {
        public byte[] AvroConvert { get; set; }
        public byte[] BSON { get; set; }
        public byte[] GroBuf { get; set; }
        public byte[] Hyperion { get; set; }
        public byte[] MessagePack { get; set; }
        public byte[] MsgPack { get; set; }
        public byte[] ProtoBufNet { get; set; }
        public byte[] MemoryPack { get; set; }
    }
}