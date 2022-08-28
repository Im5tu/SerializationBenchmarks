using System.Text.Json;
using System.Text.Json.Serialization;
using BenchmarkDotNet.Attributes;
using SerializationBenchmarks.Models.Bebop;
using Wrapper = SerializationBenchmarks.Models.Bebop.UserWrapper;

public partial class BinaryBenchmark
{
    [Benchmark, BenchmarkCategory("Serialization", "Binary"), ArgumentsSource(nameof(GenerateBebopDataSets))]
    public byte[] Bebop_Serialize(BebopDataSet data)
    {
        return DataConvert_Bebop(data.Payload);
    }
    
    [Benchmark, BenchmarkCategory("Deserialization", "Binary"), ArgumentsSource(nameof(GenerateBebopDataSets))]
    public User[] Bebop_Deserialize(BebopDataSet data)
    {
        return Wrapper.Decode(data.Data).Users;
    }
    
    private byte[] DataConvert_Bebop(User[] users)
    {
        return Wrapper.Encode(new Wrapper { Users = users });
    }
    
    public IEnumerable<BebopDataSet> GenerateBebopDataSets()
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
            var users = JsonSerializer.Deserialize<List<User>>(json, options)!.ToArray();
            yield return new BebopDataSet
            {
                Name = set.Subset,
                Payload = users,
                Data = DataConvert_Bebop(users)
            };
        }
    }

    public class BebopDataSet
    {
        public string Name { get; set; }
        public User[] Payload { get; set; }
        public byte[] Data { get; set; }
        public override string ToString() => Name;
    }
}