using MessagePack;
using ProtoBuf;

namespace SerializationBenchmarks.Models;

[MessagePackObject, ProtoContract]
public class User
{
    [Key(0), ProtoMember(1)]
    public int Id { get; set; }
    [Key(1), ProtoMember(2)]
    public string FirstName { get; set; }
    [Key(2), ProtoMember(3)]
    public string LastName { get; set; }
    [Key(3), ProtoMember(4)]
    public string FullName { get; set; }
    [Key(4), ProtoMember(5)]
    public string UserName { get; set; }
    [Key(5), ProtoMember(6)]
    public string Email { get; set; }
    [Key(6), ProtoMember(7)]
    public string SomethingUnique { get; set; }
    [Key(7), ProtoMember(8)]
    public Guid SomeGuid { get; set; }
    [Key(8), ProtoMember(9)]
    public string Avatar { get; set; }
    [Key(9), ProtoMember(10)]
    public Guid CartId { get; set; }
    [Key(10), ProtoMember(11)]
    public string SSN { get; set; }
    [Key(11), ProtoMember(12)]
    public Gender Gender { get; set; }
    [Key(12), ProtoMember(13)]
    public List<Order> Orders { get; set; }
}