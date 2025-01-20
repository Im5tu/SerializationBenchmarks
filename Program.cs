using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using BenchmarkDotNet.Running;
using Bogus;
using SerializationBenchmarks.Models;

internal static class Program
{
    private static void Main()
    {
        //GenerateDataSet();
        VerifySerializedSizes();
        BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run();
    }

    // ReSharper disable once UnusedMember.Local
    private static void VerifySerializedSizes()
    {
        var b = new BinaryBenchmark();
        var j = new JsonBenchmark();

        var binaryDataSets = b.GenerateDataSets().ToList();
        var bebopDataSets = b.GenerateBebopDataSets().ToList();
        var jsonDataSets = j.GenerateDataSets().ToList();

        var binaryResults = new Dictionary<string, Dictionary<string, long>>(StringComparer.OrdinalIgnoreCase)
        {
            ["Small"] = new(),
            ["Medium"] = new(),
            ["Large"] = new(),
        };
        var jsonResults = new Dictionary<string, Dictionary<string, long>>(StringComparer.OrdinalIgnoreCase)
        {
            ["Small"] = new(),
            ["Medium"] = new(),
            ["Large"] = new(),
        };

        foreach (var bds in binaryDataSets)
        {
            var results = binaryResults[bds.Name];
            results["AvroConvert"] = bds.SerializedData.AvroConvert.Length;
            results["BSON"] = bds.SerializedData.BSON.Length;
            results["CBOR"] = bds.SerializedData.CBOR.Length;
            results["GroBuf"] = bds.SerializedData.GroBuf.Length;
            results["Hyperion"] = bds.SerializedData.Hyperion.Length;
            results["MessagePack"] = bds.SerializedData.MessagePack.Length;
            results["MsgPack"] = bds.SerializedData.MsgPack.Length;
            results["ProtoBufNet"] = bds.SerializedData.ProtoBufNet.Length;
        }

        foreach (var bds in bebopDataSets)
        {
            binaryResults[bds.Name]["Bebop"] = bds.Data.Length;
        }

        foreach (var jds in jsonDataSets)
        {
            var results = jsonResults[jds.Name];
            results["Jil"] = Encoding.UTF8.GetBytes(j.Jil_Serialize(jds)).Length;
            results["Newtonsoft.Json"] = Encoding.UTF8.GetBytes(j.NewtonsoftJson_Serialize(jds)).Length;
            results["ServiceStack"] = Encoding.UTF8.GetBytes(j.ServiceStack_Serialize(jds)).Length;
            results["SpanJson"] = j.SpanJson_Serialize(jds).ToArray().Length;
            results["SystemTextJson"] = Encoding.UTF8.GetBytes(j.SystemTextJson_Serialize(jds)).Length;
            results["UTF8Json"] = j.UTF8Json_Serialize(jds).Length;
        }
        
        Console.WriteLine("Binary:");
        foreach (var section in binaryResults)
        {
            Console.WriteLine($"  {section.Key}:");
            foreach (var result in section.Value.OrderBy(x => x.Value))
            {
                Console.WriteLine($"    - {(result.Key + ":").PadRight(15)} {result.Value}");
            }
        }
        
        Console.WriteLine("Json:");
        foreach (var section in jsonResults)
        {
            Console.WriteLine($"  {section.Key}:");
            foreach (var result in section.Value.OrderBy(x => x.Value))
            {
                Console.WriteLine($"    - {(result.Key + ":").PadRight(15)} {result.Value}");
            }
        }
    }
    
    // ReSharper disable once UnusedMember.Local
    private static void GenerateDataSet()
    {
        // Copied from: https://github.com/bchavez/Bogus/blob/master/Examples/GettingStarted/Program.cs
        Randomizer.Seed = new Random(3897234);

        var fruit = new[] { "apple", "banana", "orange", "strawberry", "kiwi" };

        var orderIds = 0;
        var testOrders = new Faker<Order>()
            .StrictMode(true)
            .RuleFor(o => o.OrderId, f => orderIds++)
            .RuleFor(o => o.Item, f => f.PickRandom(fruit))
            .RuleFor(o => o.Quantity, f => f.Random.Number(1, 10))
            .RuleFor(o => o.LotNumber, f => f.Random.Int(0, 100).OrNull(f, .8f));

        var userIds = 0;
        var testUsers = new Faker<User>()
            .RuleFor(u => u.Id, f => userIds++)
            .RuleFor(u => u.FirstName, f => f.Name.FirstName())
            .RuleFor(u => u.LastName, f => f.Name.LastName())
            .RuleFor(u => u.Avatar, f => f.Internet.Avatar())
            .RuleFor(u => u.UserName, (f, u) => f.Internet.UserName(u.FirstName, u.LastName))
            .RuleFor(u => u.Email, (f, u) => f.Internet.Email(u.FirstName, u.LastName))
            .RuleFor(u => u.SomethingUnique, f => $"Value {f.UniqueIndex}")
            .RuleFor(u => u.SomeGuid, Guid.NewGuid)
            .RuleFor(u => u.Gender, f => f.PickRandom<Gender>())
            .RuleFor(u => u.CartId, f => Guid.NewGuid())
            .RuleFor(u => u.FullName, (f, u) => u.FirstName + " " + u.LastName)
            .RuleFor(u => u.Orders, f => testOrders.Generate(Random.Shared.Next(5, 10)));

        var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
        options.Converters.Add(new JsonStringEnumConverter());
        
        File.WriteAllText("Data_Small.json", JsonSerializer.Serialize(testUsers.Generate(200), options));
        File.WriteAllText("Data_Medium.json", JsonSerializer.Serialize(testUsers.Generate(5_000), options));
        File.WriteAllText("Data_Large.json", JsonSerializer.Serialize(testUsers.Generate(20_000), options));
    }
}