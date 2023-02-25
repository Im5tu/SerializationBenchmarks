using MemoryPack;
using MessagePack;
using ProtoBuf;

namespace SerializationBenchmarks.Models;

[MessagePackObject, ProtoContract, MemoryPackable]
public partial class Order
{
    [Key(0), ProtoMember(1)]
    public int OrderId { get; set; }
    [Key(1), ProtoMember(2)]
    public string Item { get; set; }
    [Key(2), ProtoMember(3)]
    public int Quantity { get; set; }
    [Key(3), ProtoMember(4)]
    public int? LotNumber { get; set; }
}