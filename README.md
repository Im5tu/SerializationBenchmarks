# SerializationBenchmarks

As part of a [YouTube video](https://www.youtube.com/watch?v=XMoNYQPi2k8), I went through a bunch of serializers to see their current levels of performance. I'm happy for this repository to be improved in terms of fixing any minor issues, adding new scenarios or adding serialization frameworks.

## Serializers

### JSON

- [Jil](https://www.nuget.org/packages/Jil/)
- [Newtonsoft.Json](https://www.nuget.org/packages/Newtonsoft.Json/)
- [ServiceStack.Text](https://www.nuget.org/packages/ServiceStack.Text/)
- [SpanJson](https://www.nuget.org/packages/SpanJson)
- System.Text.Json (with & without Source Generator)
- [UTF8Json](https://www.nuget.org/packages/Utf8Json)

### Binary

- [AvroConvert](https://www.nuget.org/packages/AvroConvert/)
- [Bebop](https://www.nuget.org/packages/bebop)
- [BSON](https://www.nuget.org/packages/MongoDB.Bson)
- [CBOR](https://www.nuget.org/packages/Dahomey.Cbor)
- [GroBuf](https://www.nuget.org/packages/GroBuf)
- [Hyperion](https://www.nuget.org/packages/Hyperion)
- [MessagePack](https://www.nuget.org/packages/MessagePack)
- [MemoryPack](https://www.nuget.org/packages/MemoryPack)
- [MsgPack](https://www.nuget.org/packages/MsgPack)
- [protobuf-net](https://www.nuget.org/packages/protobuf-net)

## Current JSON Serializer Results (2023-02-26)

```
BenchmarkDotNet=v0.13.5, OS=Windows 11 (10.0.22621.1265/22H2/2022Update/SunValley2)
Intel Core i9-9900K CPU 3.60GHz (Coffee Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.200
[Host]     : .NET 7.0.3 (7.0.323.6910), X64 RyuJIT AVX2
DefaultJob : .NET 7.0.3 (7.0.323.6910), X64 RyuJIT AVX2
```

|                            Method |   data |         Mean |       Error |      StdDev |       Median |          Min |          Max | Ratio | RatioSD |      Gen0 |      Gen1 |     Gen2 |   Allocated | Alloc Ratio |
|---------------------------------- |------- |-------------:|------------:|------------:|-------------:|-------------:|-------------:|------:|--------:|----------:|----------:|---------:|------------:|------------:|
|              SpanJson_Deserialize |  Large |  91,190.8 us | 1,811.48 us | 4,374.94 us |  89,969.2 us |  83,768.1 us | 104,369.6 us |  0.66 |    0.05 | 4000.0000 | 3833.3333 | 666.6667 | 44667.44 KB |        1.00 |
|                   Jil_Deserialize |  Large | 100,230.1 us | 1,943.11 us | 2,237.69 us | 100,638.2 us |  96,002.4 us | 103,568.0 us |  0.72 |    0.02 | 4000.0000 | 3833.3333 | 666.6667 | 27753.73 KB |        0.62 |
|              UTF8Json_Deserialize |  Large | 109,200.0 us | 2,085.04 us | 2,047.79 us | 109,092.9 us | 105,728.9 us | 113,311.5 us |  0.79 |    0.02 | 3800.0000 | 3600.0000 | 600.0000 | 44666.62 KB |        1.00 |
|        SystemTextJson_Deserialize |  Large | 138,832.0 us | 1,958.74 us | 1,832.20 us | 138,740.8 us | 136,207.2 us | 141,876.0 us |  1.00 |    0.00 | 3750.0000 | 3500.0000 | 500.0000 | 44668.96 KB |        1.00 |
| SystemTextJson_SrcGen_Deserialize |  Large | 140,451.0 us | 2,175.38 us | 2,034.85 us | 140,515.7 us | 137,389.1 us | 144,502.9 us |  1.01 |    0.02 | 3750.0000 | 3500.0000 | 500.0000 | 44668.96 KB |        1.00 |
|          ServiceStack_Deserialize |  Large | 220,351.1 us | 4,329.13 us | 7,112.88 us | 218,680.2 us | 210,853.8 us | 238,109.4 us |  1.58 |    0.06 | 4666.6667 | 2333.3333 | 333.3333 | 37471.89 KB |        0.84 |
|        NewtonsoftJson_Deserialize |  Large | 249,970.0 us | 4,223.49 us | 4,519.08 us | 248,670.5 us | 244,194.6 us | 260,768.2 us |  1.80 |    0.04 | 5000.0000 | 2500.0000 | 500.0000 | 39137.85 KB |        0.88 |
|                                   |        |              |             |             |              |              |              |       |         |           |           |          |             |             |
|                   Jil_Deserialize | Medium |  16,157.2 us |   266.15 us |   316.83 us |  16,072.6 us |  15,767.3 us |  16,985.5 us |  0.59 |    0.02 |  843.7500 |  750.0000 |        - |  6935.28 KB |        0.62 |
|              SpanJson_Deserialize | Medium |  16,572.0 us |   267.62 us |   237.24 us |  16,686.7 us |  16,136.5 us |  16,803.6 us |  0.61 |    0.01 | 1093.7500 |  968.7500 | 250.0000 | 11124.97 KB |        1.00 |
|              UTF8Json_Deserialize | Medium |  21,231.9 us |   414.06 us |   552.76 us |  21,134.0 us |  20,066.9 us |  22,387.3 us |  0.78 |    0.03 | 1093.7500 |  968.7500 | 250.0000 | 11125.04 KB |        1.00 |
|        SystemTextJson_Deserialize | Medium |  27,273.0 us |   329.03 us |   307.77 us |  27,179.3 us |  26,864.5 us |  28,011.8 us |  1.00 |    0.00 | 1093.7500 |  968.7500 | 250.0000 | 11125.72 KB |        1.00 |
| SystemTextJson_SrcGen_Deserialize | Medium |  27,648.3 us |   241.70 us |   214.26 us |  27,591.1 us |  27,366.2 us |  28,085.3 us |  1.01 |    0.02 | 1093.7500 |  968.7500 | 250.0000 | 11126.42 KB |        1.00 |
|          ServiceStack_Deserialize | Medium |  48,323.4 us |   734.66 us |   687.20 us |  48,138.1 us |  47,236.9 us |  49,689.3 us |  1.77 |    0.03 | 1181.8182 | 1000.0000 |  90.9091 |  9357.83 KB |        0.84 |
|        NewtonsoftJson_Deserialize | Medium |  55,349.4 us | 1,089.57 us | 2,298.27 us |  55,172.9 us |  51,556.2 us |  60,647.0 us |  2.05 |    0.07 | 1100.0000 |  900.0000 |        - |  9776.74 KB |        0.88 |
|                                   |        |              |             |             |              |              |              |       |         |           |           |          |             |             |
|              SpanJson_Deserialize |  Small |     511.2 us |     9.20 us |     8.15 us |     509.2 us |     501.2 us |     528.3 us |  0.54 |    0.01 |   51.7578 |   51.7578 |  51.7578 |   446.93 KB |        1.60 |
|                   Jil_Deserialize |  Small |     564.0 us |     2.39 us |     2.00 us |     563.5 us |     561.7 us |     567.8 us |  0.60 |    0.00 |   34.1797 |   10.7422 |        - |   279.63 KB |        1.00 |
|              UTF8Json_Deserialize |  Small |     665.7 us |     5.09 us |     4.76 us |     665.6 us |     658.7 us |     673.7 us |  0.71 |    0.00 |   83.0078 |   61.5234 |  48.8281 |   447.05 KB |        1.60 |
|        SystemTextJson_Deserialize |  Small |     939.9 us |     1.45 us |     1.21 us |     939.7 us |     937.5 us |     941.7 us |  1.00 |    0.00 |   34.1797 |   11.7188 |        - |   279.71 KB |        1.00 |
| SystemTextJson_SrcGen_Deserialize |  Small |     983.0 us |     2.19 us |     1.94 us |     983.0 us |     979.7 us |     985.9 us |  1.05 |    0.00 |   33.2031 |   11.7188 |        - |   279.71 KB |        1.00 |
|          ServiceStack_Deserialize |  Small |   1,551.9 us |    13.64 us |    12.76 us |   1,546.8 us |   1,535.9 us |   1,578.3 us |  1.65 |    0.01 |   44.9219 |   13.6719 |        - |   379.04 KB |        1.36 |
|        NewtonsoftJson_Deserialize |  Small |   1,880.9 us |    28.69 us |    26.84 us |   1,886.8 us |   1,831.2 us |   1,914.5 us |  2.00 |    0.03 |   46.8750 |   19.5313 |        - |   398.46 KB |        1.42 |
|                                   |        |              |             |             |              |              |              |       |         |           |           |          |             |             |
|                SpanJson_Serialize |  Large |  24,379.2 us |    67.39 us |    56.27 us |  24,383.5 us |  24,263.1 us |  24,476.9 us |  0.48 |    0.00 |  125.0000 |  125.0000 | 125.0000 | 16384.13 KB |        0.48 |
|                UTF8Json_Serialize |  Large |  39,032.1 us |   765.63 us | 1,419.15 us |  38,884.8 us |  36,683.0 us |  42,188.1 us |  0.80 |    0.03 |  615.3846 |  615.3846 | 615.3846 | 82319.57 KB |        2.40 |
|   SystemTextJson_SrcGen_Serialize |  Large |  49,655.5 us |   217.47 us |   181.60 us |  49,619.5 us |  49,443.4 us |  50,147.9 us |  0.98 |    0.00 |         - |         - |        - | 34296.93 KB |        1.00 |
|          SystemTextJson_Serialize |  Large |  50,513.3 us |   170.93 us |   151.53 us |  50,520.8 us |  50,184.7 us |  50,817.3 us |  1.00 |    0.00 |         - |         - |        - | 34296.93 KB |        1.00 |
|                     Jil_Serialize |  Large |  53,530.0 us | 1,067.88 us | 1,425.59 us |  53,763.7 us |  50,595.6 us |  55,955.4 us |  1.07 |    0.03 | 5000.0000 | 4888.8889 | 888.8889 |    67819 KB |        1.98 |
|          NewtonsoftJson_Serialize |  Large | 125,169.9 us | 2,045.01 us | 1,812.85 us | 125,387.6 us | 122,390.9 us | 128,757.7 us |  2.48 |    0.04 | 6600.0000 | 3600.0000 | 800.0000 | 81290.58 KB |        2.37 |
|            ServiceStack_Serialize |  Large | 146,043.9 us |   293.87 us |   274.89 us | 145,935.9 us | 145,687.9 us | 146,551.0 us |  2.89 |    0.01 | 6000.0000 |         - |        - | 78487.63 KB |        2.29 |
|                                   |        |              |             |             |              |              |              |       |         |           |           |          |             |             |
|                SpanJson_Serialize | Medium |   6,141.6 us |    56.25 us |    52.61 us |   6,155.3 us |   5,993.7 us |   6,201.1 us |  0.48 |    0.01 |  117.1875 |  117.1875 | 117.1875 |  4096.11 KB |        0.48 |
|                UTF8Json_Serialize | Medium |  10,055.7 us |   199.79 us |   177.11 us |  10,020.6 us |   9,819.5 us |  10,372.9 us |  0.78 |    0.02 |  500.0000 |  500.0000 | 500.0000 | 20445.27 KB |        2.41 |
|          SystemTextJson_Serialize | Medium |  12,890.4 us |   203.52 us |   190.38 us |  12,866.9 us |  12,676.6 us |  13,272.9 us |  1.00 |    0.00 |  187.5000 |  187.5000 | 187.5000 |  8496.96 KB |        1.00 |
|   SystemTextJson_SrcGen_Serialize | Medium |  13,029.8 us |   164.63 us |   153.99 us |  13,040.7 us |  12,804.6 us |  13,314.2 us |  1.01 |    0.02 |  187.5000 |  187.5000 | 187.5000 |  8496.96 KB |        1.00 |
|                     Jil_Serialize | Medium |  16,192.0 us |   315.34 us |   410.04 us |  16,162.8 us |  15,534.3 us |  17,039.5 us |  1.26 |    0.05 | 1906.2500 | 1812.5000 | 875.0000 | 16806.86 KB |        1.98 |
|          NewtonsoftJson_Serialize | Medium |  31,214.2 us |   558.44 us |   948.28 us |  30,899.0 us |  30,212.6 us |  33,347.0 us |  2.41 |    0.07 | 2312.5000 | 1875.0000 | 875.0000 | 20170.37 KB |        2.37 |
|            ServiceStack_Serialize | Medium |  38,538.6 us |   314.84 us |   294.50 us |  38,582.1 us |  38,049.6 us |  39,009.7 us |  2.99 |    0.04 | 1571.4286 |  142.8571 | 142.8571 | 19358.84 KB |        2.28 |
|                                   |        |              |             |             |              |              |              |       |         |           |           |          |             |             |
|                SpanJson_Serialize |  Small |     234.9 us |     0.43 us |     0.38 us |     234.9 us |     234.1 us |     235.3 us |  0.47 |    0.00 |   75.6836 |   75.6836 |  75.6836 |   256.07 KB |        0.75 |
|                UTF8Json_Serialize |  Small |     303.2 us |     0.89 us |     0.84 us |     303.3 us |     301.8 us |     304.4 us |  0.61 |    0.00 |  148.9258 |  148.9258 | 148.9258 |   551.72 KB |        1.62 |
|                     Jil_Serialize |  Small |     436.1 us |    19.80 us |    58.37 us |     473.4 us |     322.6 us |     486.5 us |  0.70 |    0.03 |   99.6094 |   99.6094 |  99.6094 |   673.91 KB |        1.98 |
|          SystemTextJson_Serialize |  Small |     499.2 us |     3.20 us |     2.84 us |     499.9 us |     492.4 us |     502.9 us |  1.00 |    0.00 |   89.8438 |   89.8438 |  89.8438 |   340.86 KB |        1.00 |
|   SystemTextJson_SrcGen_Serialize |  Small |     503.1 us |     2.69 us |     2.38 us |     503.0 us |     498.8 us |     507.4 us |  1.01 |    0.01 |   89.8438 |   89.8438 |  89.8438 |   340.85 KB |        1.00 |
|          NewtonsoftJson_Serialize |  Small |   1,102.0 us |    11.72 us |     9.15 us |   1,104.2 us |   1,081.5 us |   1,110.3 us |  2.21 |    0.03 |  148.4375 |  113.2813 |  89.8438 |   821.44 KB |        2.41 |
|            ServiceStack_Serialize |  Small |   1,581.4 us |    17.93 us |    16.77 us |   1,577.9 us |   1,562.8 us |   1,617.2 us |  3.17 |    0.04 |  142.5781 |   82.0313 |  82.0313 |   784.99 KB |        2.30 |

## Current Binary Serializer Results (2023-02-26)

```
BenchmarkDotNet=v0.13.5, OS=Windows 11 (10.0.22621.1265/22H2/2022Update/SunValley2)
Intel Core i9-9900K CPU 3.60GHz (Coffee Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.200
[Host]     : .NET 7.0.3 (7.0.323.6910), X64 RyuJIT AVX2
DefaultJob : .NET 7.0.3 (7.0.323.6910), X64 RyuJIT AVX2
```

|                  Method |   data |          Mean |        Error |       StdDev |           Min |           Max |       Gen0 |      Gen1 |     Gen2 |  Allocated |
|------------------------ |------- |--------------:|-------------:|-------------:|--------------:|--------------:|-----------:|----------:|---------:|-----------:|
|      GroBuf_Deserialize |  Large |  47,243.86 us |   825.702 us |   772.362 us |  45,642.06 us |  48,513.91 us |  3636.3636 | 3545.4545 | 545.4545 | 26179193 B |
|       Bebop_Deserialize |  Large |  48,244.74 us |   748.848 us |   700.473 us |  47,523.21 us |  49,245.47 us |  3909.0909 | 3818.1818 | 727.2727 | 26980756 B |
|  MemoryPack_Deserialize |  Large |  48,738.47 us |   911.477 us |   852.597 us |  47,061.95 us |  50,501.60 us |  3636.3636 | 3545.4545 | 545.4545 | 26179103 B |
| MessagePack_Deserialize |  Large |  62,726.35 us | 1,155.674 us | 1,330.876 us |  60,548.57 us |  65,081.39 us |  3500.0000 | 3375.0000 | 500.0000 | 26179115 B |
| ProtoBufNet_Deserialize |  Large |  71,688.15 us | 1,416.613 us | 2,031.664 us |  69,305.33 us |  76,257.39 us |  3714.2857 | 3571.4286 | 571.4286 | 26820875 B |
|    Hyperion_Deserialize |  Large |  87,696.21 us | 1,700.080 us | 1,889.634 us |  85,881.60 us |  91,572.22 us |  4166.6667 | 4000.0000 | 500.0000 | 31180175 B |
|     MsgPack_Deserialize |  Large |  92,672.91 us | 1,770.147 us | 1,817.811 us |  89,019.35 us |  96,053.55 us |  4166.6667 | 4000.0000 | 500.0000 | 32018907 B |
| AvroConvert_Deserialize |  Large | 196,401.45 us | 3,830.642 us | 4,980.917 us | 187,416.40 us | 203,311.00 us | 10000.0000 | 3666.6667 | 333.3333 | 96425000 B |
|        BSON_Deserialize |  Large | 235,586.13 us | 3,199.265 us | 2,836.065 us | 229,802.00 us | 240,312.37 us |  8333.3333 | 4333.3333 | 333.3333 | 69298835 B |
|                         |        |               |              |              |               |               |            |           |          |            |
|      GroBuf_Deserialize | Medium |   4,257.91 us |    62.966 us |    52.579 us |   4,179.05 us |   4,336.40 us |   773.4375 |  703.1250 |        - |  6533041 B |
|       Bebop_Deserialize | Medium |   4,402.57 us |    60.201 us |    56.312 us |   4,308.14 us |   4,478.53 us |   804.6875 |  750.0000 |        - |  6732454 B |
|  MemoryPack_Deserialize | Medium |   4,425.59 us |    43.134 us |    40.347 us |   4,370.96 us |   4,497.73 us |   773.4375 |  703.1250 |        - |  6532969 B |
| ProtoBufNet_Deserialize | Medium |   8,896.05 us |    44.146 us |    39.134 us |   8,804.73 us |   8,960.84 us |   796.8750 |  593.7500 |        - |  6693108 B |
| MessagePack_Deserialize | Medium |   8,967.02 us |    74.913 us |    66.408 us |   8,843.58 us |   9,075.46 us |   765.6250 |  687.5000 |        - |  6532978 B |
|    Hyperion_Deserialize | Medium |  13,124.22 us |    46.479 us |    41.203 us |  13,063.96 us |  13,210.24 us |   921.8750 |  843.7500 |        - |  7789506 B |
|     MsgPack_Deserialize | Medium |  13,680.20 us |   189.208 us |   202.450 us |  13,328.87 us |  14,038.78 us |   953.1250 |  906.2500 |        - |  7992954 B |
| AvroConvert_Deserialize | Medium |  43,866.48 us |   713.613 us |   667.514 us |  42,987.47 us |  45,111.19 us |  2692.3077 | 1076.9231 | 230.7692 | 24169490 B |
|        BSON_Deserialize | Medium |  59,161.54 us | 1,155.333 us | 1,080.699 us |  57,379.79 us |  60,921.69 us |  2222.2222 | 1222.2222 | 222.2222 | 17298596 B |
|                         |        |               |              |              |               |               |            |           |          |            |
|      GroBuf_Deserialize |  Small |     113.90 us |     1.860 us |     1.649 us |     111.64 us |     117.01 us |    31.4941 |   10.4980 |        - |   263784 B |
|       Bebop_Deserialize |  Small |     116.13 us |     1.069 us |     1.000 us |     114.89 us |     118.71 us |    32.4707 |   12.0850 |        - |   272000 B |
|  MemoryPack_Deserialize |  Small |     121.76 us |     0.376 us |     0.314 us |     120.74 us |     121.99 us |    31.4941 |   10.4980 |        - |   263712 B |
| MessagePack_Deserialize |  Small |     299.24 us |     0.495 us |     0.439 us |     298.79 us |     300.21 us |    31.2500 |   10.2539 |        - |   263713 B |
| ProtoBufNet_Deserialize |  Small |     302.80 us |     4.197 us |     6.152 us |     298.31 us |     321.27 us |    32.2266 |   10.7422 |        - |   270233 B |
|    Hyperion_Deserialize |  Small |     354.44 us |     1.090 us |     1.019 us |     353.28 us |     356.81 us |    37.5977 |   12.6953 |        - |   315425 B |
|     MsgPack_Deserialize |  Small |     463.82 us |     4.525 us |     4.232 us |     458.79 us |     472.56 us |    38.0859 |   12.6953 |        - |   322225 B |
| AvroConvert_Deserialize |  Small |   1,516.93 us |     8.215 us |     7.684 us |   1,504.66 us |   1,527.68 us |   134.7656 |   48.8281 |        - |  1135455 B |
|        BSON_Deserialize |  Small |   1,697.43 us |    19.415 us |    18.161 us |   1,666.60 us |   1,727.83 us |    82.0313 |   27.3438 |        - |   701884 B |
|                         |        |               |              |              |               |               |            |           |          |            |
|    MemoryPack_Serialize |  Large |   9,668.02 us |    11.755 us |     9.816 us |   9,649.58 us |   9,682.30 us |    31.2500 |   31.2500 |  31.2500 |  9818513 B |
|        GroBuf_Serialize |  Large |  10,991.49 us |    13.141 us |    11.649 us |  10,968.58 us |  11,013.30 us |    62.5000 |   62.5000 |  62.5000 | 18824229 B |
|         Bebop_Serialize |  Large |  12,556.43 us |    55.511 us |    46.354 us |  12,493.10 us |  12,641.42 us |          - |         - |        - |       36 B |
|   MessagePack_Serialize |  Large |  16,490.02 us |    66.105 us |    61.834 us |  16,413.60 us |  16,612.91 us |          - |         - |        - |  7196899 B |
|   ProtoBufNet_Serialize |  Large |  27,214.02 us |   270.428 us |   239.727 us |  26,966.38 us |  27,802.83 us |   156.2500 |  156.2500 | 156.2500 | 27893153 B |
|      Hyperion_Serialize |  Large |  34,844.59 us |   425.809 us |   398.302 us |  34,004.25 us |  35,126.87 us |   600.0000 |   66.6667 |  66.6667 | 28827900 B |
|       MsgPack_Serialize |  Large |  40,435.03 us |   372.214 us |   329.958 us |  39,724.02 us |  40,921.32 us |  1230.7692 |  384.6154 | 307.6923 | 67710617 B |
|   AvroConvert_Serialize |  Large |  55,918.00 us |   640.324 us |   598.960 us |  54,529.86 us |  56,514.13 us |  4111.1111 |  111.1111 | 111.1111 | 78042956 B |
|          BSON_Serialize |  Large | 139,522.40 us | 1,145.433 us | 1,071.439 us | 137,698.95 us | 141,130.38 us |  4750.0000 |         - |        - | 90285250 B |
|                         |        |               |              |              |               |               |            |           |          |            |
|    MemoryPack_Serialize | Medium |   2,344.52 us |    27.653 us |    24.514 us |   2,318.72 us |   2,405.98 us |    85.9375 |   85.9375 |  85.9375 |  2446033 B |
|        GroBuf_Serialize | Medium |   2,594.14 us |    51.653 us |    59.484 us |   2,480.14 us |   2,687.87 us |   109.3750 |  109.3750 | 109.3750 |  4688436 B |
|         Bebop_Serialize | Medium |   2,874.85 us |     8.709 us |     6.800 us |   2,869.72 us |   2,887.92 us |          - |         - |        - |       27 B |
|   MessagePack_Serialize | Medium |   4,229.39 us |    82.978 us |    77.618 us |   4,104.00 us |   4,339.72 us |    31.2500 |   31.2500 |  31.2500 |  1737144 B |
|   ProtoBufNet_Serialize | Medium |   7,162.14 us |    45.605 us |    40.428 us |   7,107.72 us |   7,238.80 us |   140.6250 |  125.0000 | 125.0000 |  7090069 B |
|      Hyperion_Serialize | Medium |   8,857.20 us |    29.018 us |    25.724 us |   8,821.47 us |   8,914.76 us |   296.8750 |  156.2500 | 156.2500 |  7197143 B |
|       MsgPack_Serialize | Medium |   9,629.06 us |   188.542 us |   376.539 us |   8,914.96 us |  10,518.29 us |   671.8750 |  406.2500 | 390.6250 | 15023469 B |
|   AvroConvert_Serialize | Medium |  16,328.77 us |   310.634 us |   305.085 us |  15,725.40 us |  16,876.81 us |  1375.0000 |  562.5000 | 343.7500 | 19539986 B |
|          BSON_Serialize | Medium |  37,320.81 us |   603.465 us |   564.481 us |  36,480.74 us |  38,157.81 us |  1428.5714 |  285.7143 | 285.7143 | 22510582 B |
|                         |        |               |              |              |               |               |            |           |          |            |
|    MemoryPack_Serialize |  Small |      86.05 us |     0.790 us |     0.701 us |      85.32 us |      87.32 us |    16.1133 |   16.1133 |  16.1133 |    98798 B |
|        GroBuf_Serialize |  Small |      90.58 us |     1.163 us |     1.088 us |      89.51 us |      92.61 us |    27.2217 |   27.2217 |  27.2217 |   189554 B |
|         Bebop_Serialize |  Small |     114.32 us |     0.799 us |     0.748 us |     113.45 us |     116.12 us |          - |         - |        - |       24 B |
|   MessagePack_Serialize |  Small |     159.42 us |     1.411 us |     1.178 us |     157.78 us |     161.28 us |     8.0566 |         - |        - |    69336 B |
|   ProtoBufNet_Serialize |  Small |     259.28 us |     3.939 us |     3.492 us |     252.99 us |     266.47 us |    26.8555 |    4.3945 |        - |   228617 B |
|       MsgPack_Serialize |  Small |     281.98 us |     2.989 us |     2.496 us |     278.27 us |     285.97 us |    70.8008 |   12.2070 |        - |   596033 B |
|      Hyperion_Serialize |  Small |     339.40 us |     2.626 us |     2.193 us |     335.48 us |     342.36 us |    52.2461 |   25.8789 |  22.4609 |   384295 B |
|   AvroConvert_Serialize |  Small |     773.36 us |     8.749 us |     8.184 us |     763.25 us |     792.67 us |   129.8828 |   61.5234 |  44.9219 |   983877 B |
|          BSON_Serialize |  Small |   1,449.58 us |    28.409 us |    29.174 us |   1,417.69 us |   1,504.62 us |   158.2031 |  101.5625 |  95.7031 |  1093695 B |
