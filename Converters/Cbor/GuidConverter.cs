using Dahomey.Cbor;
using Dahomey.Cbor.Serialization;
using Dahomey.Cbor.Serialization.Converters;

namespace SerializationBenchmarks.Converters.Cbor;

internal sealed class GuidConverter : CborConverterBase<Guid>
{
    private const int CBOR_ARRAY_SIZE = 16;
    private const ulong TAG_UUID = 37;

    public override Guid Read(ref CborReader reader)
    {
        var value = reader.ReadByteString();

        if (value.Length != CBOR_ARRAY_SIZE)
        {
            throw new CborException("Expected a CBOR byte array with 16 elements");
        }

        return new Guid(value);
    }

    public override void Write(ref CborWriter writer, Guid value)
    {
        writer.WriteSemanticTag(TAG_UUID);

        Span<byte> bytes = new byte[CBOR_ARRAY_SIZE];
        if (value.TryWriteBytes(bytes))
        {
            writer.WriteByteString(bytes);
        }
        else
        {
            throw new CborException("Cannot serialize the GUID to CBOR");
        }
    }
}