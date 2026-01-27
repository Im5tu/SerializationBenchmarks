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

## Current .NET 9 Serializer Results (2025-12-31)

| Method                            | data   | Mean         | Error       | StdDev      | Median       | Min          | Max          | Ratio | RatioSD | Gen0      | Gen1     | Gen2     | Allocated   | Alloc Ratio |
|---------------------------------- |------- |-------------:|------------:|------------:|-------------:|-------------:|-------------:|------:|--------:|----------:|---------:|---------:|------------:|------------:|
| Jil_Deserialize                   | Large  |           NA |          NA |          NA |           NA |           NA |           NA |     ? |       ? |        NA |       NA |       NA |          NA |           ? |                                                                                                                                                              
| SpanJson_Deserialize              | Large  |  54,478.2 us | 1,082.70 us | 1,063.36 us |  54,320.1 us |  52,783.0 us |  56,243.7 us |  0.74 |    0.02 |  700.0000 | 600.0000 | 200.0000 | 44666.42 KB |        1.61 |
| UTF8Json_Deserialize              | Large  |  65,441.2 us | 1,136.97 us | 1,007.89 us |  65,366.2 us |  64,093.8 us |  67,190.9 us |  0.89 |    0.02 |  777.7778 | 666.6667 | 222.2222 | 44667.09 KB |        1.61 |
| SystemTextJson_SrcGen_Deserialize | Large  |  73,088.0 us | 1,368.07 us | 1,872.64 us |  72,317.8 us |  70,671.6 us |  78,111.5 us |  0.99 |    0.03 |  571.4286 | 428.5714 | 142.8571 |  27752.9 KB |        1.00 |
| SystemTextJson_Deserialize        | Large  |  73,634.1 us | 1,457.38 us | 1,619.88 us |  73,363.0 us |  71,824.8 us |  77,093.2 us |  1.00 |    0.03 |  571.4286 | 428.5714 | 142.8571 | 27752.86 KB |        1.00 |
| ServiceStack_Deserialize          | Large  | 116,346.9 us | 2,221.62 us | 2,377.11 us | 117,131.2 us | 112,845.8 us | 119,929.6 us |  1.58 |    0.05 |  800.0000 | 600.0000 | 200.0000 | 37471.97 KB |        1.35 |
| NewtonsoftJson_Deserialize        | Large  | 133,121.1 us | 2,637.44 us | 5,144.12 us | 130,887.5 us | 126,023.5 us | 143,068.4 us |  1.81 |    0.08 | 1000.0000 | 750.0000 | 250.0000 | 39138.03 KB |        1.41 |
|                                   |        |              |             |             |              |              |              |       |         |           |          |          |             |             |
| Jil_Deserialize                   | Medium |           NA |          NA |          NA |           NA |           NA |           NA |     ? |       ? |        NA |       NA |       NA |          NA |           ? |
| SpanJson_Deserialize              | Medium |   8,412.7 us |   161.22 us |   198.00 us |   8,409.0 us |   7,976.1 us |   8,902.9 us |  0.67 |    0.02 |  250.0000 | 187.5000 | 109.3750 | 11124.62 KB |        1.60 |
| UTF8Json_Deserialize              | Medium |  11,080.4 us |   215.09 us |   220.89 us |  11,077.3 us |  10,684.5 us |  11,415.6 us |  0.89 |    0.02 |  250.0000 | 187.5000 | 109.3750 | 11124.73 KB |        1.60 |
| SystemTextJson_SrcGen_Deserialize | Medium |  12,316.5 us |   107.62 us |   100.67 us |  12,296.4 us |  12,159.7 us |  12,494.8 us |  0.99 |    0.01 |  140.6250 |  78.1250 |        - |  6935.37 KB |        1.00 |
| SystemTextJson_Deserialize        | Medium |  12,474.1 us |    81.77 us |    76.48 us |  12,471.2 us |  12,353.9 us |  12,629.3 us |  1.00 |    0.01 |  140.6250 |  78.1250 |        - |  6935.37 KB |        1.00 |
| ServiceStack_Deserialize          | Medium |  20,520.3 us |   123.55 us |   115.57 us |  20,518.6 us |  20,272.1 us |  20,712.3 us |  1.65 |    0.01 |  187.5000 |  93.7500 |        - |   9357.1 KB |        1.35 |
| NewtonsoftJson_Deserialize        | Medium |  21,150.3 us |   155.28 us |   145.25 us |  21,180.1 us |  20,886.1 us |  21,437.6 us |  1.70 |    0.02 |  187.5000 |  62.5000 |        - |  9776.73 KB |        1.41 |
|                                   |        |              |             |             |              |              |              |       |         |           |          |          |             |             |
| Jil_Deserialize                   | Small  |           NA |          NA |          NA |           NA |           NA |           NA |     ? |       ? |        NA |       NA |       NA |          NA |           ? |
| SpanJson_Deserialize              | Small  |     321.8 us |     1.76 us |     1.37 us |     321.6 us |     319.7 us |     324.4 us |  0.64 |    0.01 |   52.2461 |  52.2461 |  52.2461 |   446.97 KB |        1.60 |
| UTF8Json_Deserialize              | Small  |     377.7 us |     4.70 us |     4.40 us |     376.0 us |     372.8 us |     387.5 us |  0.75 |    0.01 |   52.7344 |  47.8516 |  47.3633 |   447.08 KB |        1.60 |
| SystemTextJson_SrcGen_Deserialize | Small  |     496.2 us |     5.10 us |     4.77 us |     497.3 us |     483.8 us |     503.5 us |  0.98 |    0.01 |    4.8828 |   1.9531 |        - |   279.73 KB |        1.00 |
| SystemTextJson_Deserialize        | Small  |     505.2 us |     6.52 us |     6.10 us |     506.1 us |     496.3 us |     516.4 us |  1.00 |    0.02 |    4.8828 |   1.9531 |        - |   279.73 KB |        1.00 |
| ServiceStack_Deserialize          | Small  |     806.6 us |     4.31 us |     4.03 us |     807.0 us |     800.2 us |     814.1 us |  1.60 |    0.02 |    6.8359 |   2.9297 |        - |   379.04 KB |        1.36 |
| NewtonsoftJson_Deserialize        | Small  |     851.9 us |     8.37 us |     7.83 us |     851.8 us |     837.7 us |     867.9 us |  1.69 |    0.02 |    7.8125 |   4.8828 |        - |   398.46 KB |        1.42 |
|                                   |        |              |             |             |              |              |              |       |         |           |          |          |             |             |
| SpanJson_Serialize                | Large  |  13,175.9 us |   107.89 us |    95.64 us |  13,156.0 us |  13,058.9 us |  13,400.8 us |  0.42 |    0.01 |   46.8750 |  46.8750 |  46.8750 | 16384.11 KB |        0.48 |
| Jil_Serialize                     | Large  |  27,910.4 us |   551.11 us |   515.50 us |  27,885.0 us |  27,202.4 us |  28,896.7 us |  0.88 |    0.02 |  875.0000 | 812.5000 | 187.5000 |  67812.8 KB |        2.00 |
| SystemTextJson_Serialize          | Large  |  31,564.5 us |   435.24 us |   385.83 us |  31,515.6 us |  31,152.7 us |  32,598.8 us |  1.00 |    0.02 |         - |        - |        - | 33828.14 KB |        1.00 |
| SystemTextJson_SrcGen_Serialize   | Large  |  32,713.6 us |   477.96 us |   399.12 us |  32,747.7 us |  31,995.7 us |  33,363.9 us |  1.04 |    0.02 |         - |        - |        - | 33828.16 KB |        1.00 |
| UTF8Json_Serialize                | Large  |  34,443.0 us |   787.38 us | 2,321.61 us |  34,470.4 us |  29,442.8 us |  41,212.3 us |  1.09 |    0.07 |  733.3333 | 733.3333 | 733.3333 | 82320.09 KB |        2.43 |
| NewtonsoftJson_Serialize          | Large  |  57,080.6 us | 1,108.35 us | 1,553.76 us |  56,660.0 us |  55,171.1 us |  60,559.9 us |  1.81 |    0.05 |  888.8889 | 666.6667 |        - | 81289.39 KB |        2.40 |
| ServiceStack_Serialize            | Large  |  72,153.2 us | 1,430.71 us | 1,405.14 us |  71,742.6 us |  69,637.1 us |  74,587.7 us |  2.29 |    0.05 |  875.0000 |        - |        - | 77248.26 KB |        2.28 |
|                                   |        |              |             |             |              |              |              |       |         |           |          |          |             |             |
| SpanJson_Serialize                | Medium |   4,068.9 us |    77.35 us |    82.76 us |   4,066.4 us |   3,936.9 us |   4,255.8 us |  0.39 |    0.02 |  195.3125 | 195.3125 | 195.3125 |  4096.28 KB |        0.49 |
| Jil_Serialize                     | Medium |   8,152.8 us |   272.09 us |   802.26 us |   8,469.7 us |   6,185.6 us |   9,246.4 us |  0.78 |    0.08 |  507.8125 | 460.9375 | 335.9375 | 16800.89 KB |        2.00 |
| UTF8Json_Serialize                | Medium |   9,642.8 us |   276.92 us |   807.80 us |   9,472.9 us |   8,304.8 us |  11,948.3 us |  0.92 |    0.08 |  703.1250 | 703.1250 | 703.1250 | 20445.85 KB |        2.44 |
| SystemTextJson_Serialize          | Medium |  10,458.9 us |   197.33 us |   375.44 us |  10,438.4 us |   9,588.4 us |  11,157.5 us |  1.00 |    0.05 |  125.0000 | 125.0000 | 125.0000 |  8379.53 KB |        1.00 |
| SystemTextJson_SrcGen_Serialize   | Medium |  12,881.4 us |   252.88 us |   337.59 us |  12,920.5 us |  11,718.6 us |  13,498.1 us |  1.23 |    0.05 |  125.0000 | 125.0000 | 125.0000 |  8379.53 KB |        1.00 |
| NewtonsoftJson_Serialize          | Medium |  17,425.1 us |   347.00 us |   838.05 us |  17,546.3 us |  14,826.3 us |  19,019.9 us |  1.67 |    0.10 |  578.1250 | 531.2500 | 343.7500 | 20167.49 KB |        2.41 |
| ServiceStack_Serialize            | Medium |  25,097.6 us |   656.19 us | 1,934.80 us |  25,020.2 us |  20,593.8 us |  29,624.7 us |  2.40 |    0.20 |  500.0000 | 281.2500 | 281.2500 | 19051.54 KB |        2.27 |
|                                   |        |              |             |             |              |              |              |       |         |           |          |          |             |             |
| SpanJson_Serialize                | Small  |     181.5 us |     3.77 us |    11.12 us |     182.6 us |     158.1 us |     209.0 us |  0.47 |    0.04 |   83.2520 |  83.2520 |  83.2520 |   256.13 KB |        0.76 |
| UTF8Json_Serialize                | Small  |     222.7 us |     4.31 us |     4.79 us |     222.5 us |     213.3 us |     233.0 us |  0.58 |    0.04 |  148.6816 | 148.6816 | 148.6816 |   551.82 KB |        1.64 |
| Jil_Serialize                     | Small  |     322.2 us |    13.65 us |    39.61 us |     337.9 us |     231.8 us |     370.2 us |  0.84 |    0.11 |   99.8535 |  99.8535 |  99.8535 |   673.97 KB |        2.01 |
| SystemTextJson_SrcGen_Serialize   | Small  |     373.2 us |     7.38 us |    18.92 us |     373.1 us |     329.1 us |     414.9 us |  0.97 |    0.07 |   99.6094 |  99.6094 |  99.6094 |   335.64 KB |        1.00 |
| SystemTextJson_Serialize          | Small  |     386.7 us |     7.73 us |    21.53 us |     389.9 us |     331.6 us |     436.8 us |  1.00 |    0.08 |   99.6094 |  99.6094 |  99.6094 |   335.64 KB |        1.00 |
| NewtonsoftJson_Serialize          | Small  |     767.5 us |    21.54 us |    63.18 us |     776.2 us |     629.6 us |     919.8 us |  1.99 |    0.20 |   99.6094 |  99.6094 |  99.6094 |   821.09 KB |        2.45 |
| ServiceStack_Serialize            | Small  |     938.1 us |    18.75 us |    45.28 us |     936.0 us |     828.0 us |   1,054.8 us |  2.43 |    0.18 |   90.8203 |  90.8203 |  90.8203 |   763.05 KB |        2.27 |


## Changes 

- .NET 10 Migration

  | Package           | Old     | New    | Change |
  |-------------------|---------|--------|--------|
  | AvroConvert       | 3.4.10  | 3.4.16 | patch  |
  | bebop             | 3.0.14  | 3.2.3  | minor  |
  | bebop-tools       | 3.0.14  | 3.2.3  | minor  |
  | BenchmarkDotNet   | 0.14.0  | 0.15.8 | minor  |
  | Bogus             | 35.6.1  | 35.6.5 | patch  |
  | Dahomey.Cbor      | 1.24.3  | 1.25.1 | minor  |
  | MemoryPack        | 1.21.3  | 1.21.4 | patch  |
  | MessagePack       | 2.5.192 | 3.1.4  | major  |
  | MongoDB.Bson      | 2.30.0  | 3.5.2  | major  |
  | Newtonsoft.Json   | 13.0.3  | 13.0.4 | patch  |
  | protobuf-net      | 3.2.45  | 3.2.56 | patch  |
  | ServiceStack.Text | 8.4.0   | 10.0.4 | major  |

This is a known .NET compatibility issue with Jil. The error occurs because:

1. .NET 7+ added new overloads for TimeSpan.FromSeconds (both double and long versions)
2. Jil hasn't been updated since 2019 and doesn't support modern .NET versions, so this has been removed


## .NET 10 - Binary

| Method                  | data   | Mean         | Error        | StdDev       | Median       | Min          | Max           | Gen0      | Gen1      | Gen2     | Allocated   |
|------------------------ |------- |-------------:|-------------:|-------------:|-------------:|-------------:|--------------:|----------:|----------:|---------:|------------:|
| MemoryPack_Deserialize  | Small  |     58.60 us |     0.518 us |     0.433 us |     58.54 us |     57.74 us |      59.54 us |    5.2490 |    1.7090 |        - |    263712 B |                                                                                                                                                                                                    
| Bebop_Deserialize       | Small  |     69.32 us |     0.603 us |     0.503 us |     69.49 us |     68.48 us |      70.14 us |    5.3711 |    2.6855 |        - |    271976 B |
| GroBuf_Deserialize      | Small  |     87.62 us |     1.735 us |     1.623 us |     87.07 us |     86.03 us |      91.05 us |    5.2490 |    1.7090 |        - |    263784 B |
| Hyperion_Deserialize    | Small  |    156.09 us |     2.267 us |     2.121 us |    155.00 us |    154.10 us |     160.29 us |    6.1035 |    1.9531 |        - |    315232 B |
| ProtoBufNet_Deserialize | Small  |    179.38 us |     2.374 us |     2.221 us |    178.99 us |    175.86 us |     184.31 us |    5.3711 |    1.7090 |        - |    270232 B |
| MsgPack_Deserialize     | Small  |    181.83 us |     2.895 us |     2.708 us |    180.58 us |    177.65 us |     185.74 us |    6.3477 |    1.9531 |        - |    322224 B |
| MessagePack_Deserialize | Small  |    188.58 us |     2.923 us |     2.591 us |    188.53 us |    185.02 us |     194.21 us |    5.1270 |    1.7090 |        - |    263712 B |
| BSON_Deserialize        | Small  |    634.14 us |    12.391 us |    12.724 us |    632.04 us |    617.21 us |     666.96 us |   13.6719 |    3.9063 |        - |    701856 B |
| CBOR_Deserialize        | Small  |    726.58 us |     9.939 us |     9.297 us |    723.16 us |    716.24 us |     742.58 us |    4.8828 |    0.9766 |        - |    263888 B |
| AvroConvert_Deserialize | Small  |    799.89 us |    15.608 us |    13.836 us |    800.85 us |    778.34 us |     822.65 us |   23.4375 |    7.8125 |        - |   1212811 B |
| MemoryPack_Deserialize  | Medium |  1,730.99 us |    33.205 us |    31.060 us |  1,723.75 us |  1,680.50 us |   1,793.02 us |  128.9063 |   83.9844 |        - |   6532960 B |
| Bebop_Deserialize       | Medium |  2,114.38 us |    40.804 us |    43.660 us |  2,106.52 us |  2,038.08 us |   2,197.67 us |  132.8125 |   74.2188 |        - |   6732424 B |
| GroBuf_Deserialize      | Medium |  2,239.64 us |    36.218 us |    37.193 us |  2,229.51 us |  2,195.87 us |   2,337.69 us |  128.9063 |   78.1250 |        - |   6533032 B |
| Hyperion_Deserialize    | Medium |  4,178.03 us |    75.188 us |    70.331 us |  4,163.21 us |  4,041.03 us |   4,311.89 us |  148.4375 |   78.1250 |        - |   7789296 B |
| ProtoBufNet_Deserialize | Medium |  4,806.51 us |    77.923 us |    69.077 us |  4,815.45 us |  4,676.01 us |   4,918.26 us |  132.8125 |   70.3125 |        - |   6693080 B |
| MsgPack_Deserialize     | Medium |  4,951.15 us |    58.342 us |    48.718 us |  4,957.21 us |  4,873.06 us |   5,027.38 us |  156.2500 |  101.5625 |        - |   7992936 B |
| MessagePack_Deserialize | Medium |  5,023.95 us |    46.639 us |    38.946 us |  5,010.15 us |  4,988.89 us |   5,111.67 us |  125.0000 |   70.3125 |        - |   6532960 B |
| AvroConvert_Deserialize | Medium | 15,584.78 us |   311.647 us |   709.777 us | 15,371.05 us | 14,646.55 us |  17,489.67 us |  333.3333 |         - |        - |  27973812 B |
| BSON_Deserialize        | Medium | 16,944.69 us |   254.312 us |   225.441 us | 16,965.89 us | 16,641.48 us |  17,422.88 us |  343.7500 |  187.5000 |        - |  17297736 B |
| CBOR_Deserialize        | Medium | 18,763.49 us |   192.816 us |   180.360 us | 18,716.01 us | 18,546.26 us |  19,101.29 us |  125.0000 |   31.2500 |        - |   6533136 B |
| MemoryPack_Deserialize  | Large  | 28,480.17 us |   489.499 us |   619.059 us | 28,459.89 us | 27,531.77 us |  29,566.49 us |  687.5000 |  656.2500 | 187.5000 |  26179013 B |
| GroBuf_Deserialize      | Large  | 31,123.57 us |   599.308 us |   736.005 us | 31,244.02 us | 30,121.20 us |  32,712.47 us |  687.5000 |  656.2500 | 187.5000 |  26179082 B |
| Bebop_Deserialize       | Large  | 31,199.68 us |   578.133 us |   791.355 us | 31,268.80 us | 29,511.71 us |  32,585.58 us |  750.0000 |  718.7500 | 218.7500 |  26980581 B |
| MessagePack_Deserialize | Large  | 40,768.68 us |   804.164 us | 1,203.635 us | 40,566.98 us | 39,044.56 us |  43,176.89 us |  666.6667 |  583.3333 | 166.6667 |  26178952 B |
| ProtoBufNet_Deserialize | Large  | 41,651.98 us |   825.888 us | 1,489.247 us | 41,366.05 us | 39,410.55 us |  44,965.42 us |  636.3636 |  545.4545 | 181.8182 |  26819234 B |
| Hyperion_Deserialize    | Large  | 45,861.43 us |   827.616 us | 1,534.039 us | 45,520.00 us | 43,038.36 us |  50,297.82 us |  727.2727 |  636.3636 | 181.8182 |  31179836 B |
| MsgPack_Deserialize     | Large  | 48,526.49 us | 1,132.700 us | 3,176.211 us | 47,864.77 us | 44,146.65 us |  58,062.75 us |  727.2727 |  636.3636 | 181.8182 |  32018868 B |
| BSON_Deserialize        | Large  | 82,505.49 us | 1,338.907 us | 1,118.048 us | 82,170.30 us | 80,846.00 us |  84,451.40 us | 1000.0000 |         - |        - |  69296648 B |
| CBOR_Deserialize        | Large  | 93,495.77 us | 1,700.449 us | 1,958.240 us | 93,641.66 us | 90,872.48 us |  97,455.17 us |  666.6667 |  500.0000 | 166.6667 |  26179123 B |
| AvroConvert_Deserialize | Large  | 96,603.79 us | 1,842.595 us | 4,307.008 us | 95,905.85 us | 88,961.50 us | 110,164.90 us | 1500.0000 | 1000.0000 |        - | 112646136 B |
|                         |        |              |              |              |              |              |               |           |           |          |             |
| MemoryPack_Serialize    | Small  |     29.92 us |     0.456 us |     0.427 us |     29.81 us |     29.49 us |      30.86 us |   15.3809 |   15.3809 |  15.3809 |     98827 B |
| GroBuf_Serialize        | Small  |     52.73 us |     0.483 us |     0.428 us |     52.61 us |     52.12 us |      53.54 us |   29.2358 |   29.2358 |  29.2358 |    189635 B |
| Bebop_Serialize         | Small  |     65.31 us |     0.583 us |     0.517 us |     65.15 us |     64.44 us |      66.12 us |         - |         - |        - |           - |
| MessagePack_Serialize   | Small  |     76.49 us |     1.453 us |     1.288 us |     75.86 us |     75.21 us |      79.27 us |    1.3428 |         - |        - |     69336 B |
| ProtoBufNet_Serialize   | Small  |    132.01 us |     2.433 us |     2.498 us |    131.03 us |    128.49 us |     137.68 us |    4.3945 |    0.7324 |        - |    228616 B |
| Hyperion_Serialize      | Small  |    150.60 us |     0.934 us |     0.729 us |    150.38 us |    149.60 us |     151.82 us |   28.0762 |   23.4375 |  23.1934 |    384314 B |
| MsgPack_Serialize       | Small  |    172.07 us |     3.425 us |     4.688 us |    169.90 us |    166.01 us |     180.21 us |   11.7188 |    2.1973 |        - |    596032 B |
| AvroConvert_Serialize   | Small  |    226.91 us |     2.150 us |     1.795 us |    227.45 us |    224.48 us |     230.84 us |   53.4668 |   44.9219 |  44.9219 |    699053 B |
| CBOR_Serialize          | Small  |    432.34 us |     2.183 us |     2.042 us |    432.36 us |    429.07 us |     435.46 us |   47.3633 |   46.8750 |  46.8750 |    282000 B |
| BSON_Serialize          | Small  |    617.90 us |     3.319 us |     2.942 us |    617.93 us |    613.48 us |     624.14 us |  103.5156 |   93.7500 |  93.7500 |   1074658 B |
| MemoryPack_Serialize    | Medium |  1,160.10 us |    21.034 us |    19.676 us |  1,153.16 us |  1,130.71 us |   1,193.22 us |   44.9219 |   44.9219 |  44.9219 |   2446073 B |
| GroBuf_Serialize        | Medium |  1,536.95 us |    21.251 us |    19.879 us |  1,532.46 us |  1,505.51 us |   1,571.38 us |   80.0781 |   80.0781 |  80.0781 |   4688393 B |
| Bebop_Serialize         | Medium |  1,939.76 us |    10.332 us |     9.665 us |  1,936.72 us |  1,928.48 us |   1,956.84 us |         - |         - |        - |           - |
| MessagePack_Serialize   | Medium |  2,347.63 us |    19.786 us |    18.508 us |  2,344.86 us |  2,323.03 us |   2,381.54 us |   19.5313 |   19.5313 |  19.5313 |   1737163 B |
| ProtoBufNet_Serialize   | Medium |  3,616.98 us |    38.971 us |    36.454 us |  3,615.96 us |  3,569.04 us |   3,685.85 us |  136.7188 |  136.7188 | 136.7188 |   7090477 B |
| MemoryPack_Serialize    | Large  |  4,421.75 us |    41.549 us |    36.832 us |  4,407.52 us |  4,383.34 us |   4,506.45 us |   23.4375 |   23.4375 |  23.4375 |   9818534 B |
| Hyperion_Serialize      | Medium |  4,829.83 us |    83.152 us |    77.781 us |  4,815.19 us |  4,697.72 us |   4,994.36 us |  117.1875 |   93.7500 |  93.7500 |   7196817 B |
| MsgPack_Serialize       | Medium |  4,910.87 us |   210.038 us |   619.301 us |  4,576.39 us |  4,312.26 us |   6,365.79 us |  484.3750 |  437.5000 | 437.5000 |  15024012 B |
| GroBuf_Serialize        | Large  |  5,866.50 us |    82.453 us |    68.852 us |  5,866.07 us |  5,750.46 us |   5,949.06 us |   62.5000 |   62.5000 |  62.5000 |  18824593 B |
| Bebop_Serialize         | Large  |  7,803.08 us |   124.266 us |   116.238 us |  7,787.77 us |  7,673.75 us |   8,089.99 us |         - |         - |        - |           - |
| AvroConvert_Serialize   | Medium |  8,584.76 us |   198.541 us |   585.403 us |  8,656.65 us |  6,782.32 us |   9,540.36 us |  523.4375 |  460.9375 | 453.1250 |  14688558 B |
| MessagePack_Serialize   | Large  |  9,737.70 us |   118.544 us |   105.086 us |  9,702.39 us |  9,598.68 us |   9,936.31 us |         - |         - |        - |   7196864 B |
| CBOR_Serialize          | Medium | 11,032.44 us |    53.426 us |    44.614 us | 11,034.91 us | 10,969.34 us |  11,104.22 us |   78.1250 |   78.1250 |  78.1250 |   6976120 B |
| ProtoBufNet_Serialize   | Large  | 15,391.88 us |   150.953 us |   141.202 us | 15,452.92 us | 15,213.55 us |  15,593.49 us |  187.5000 |  187.5000 | 187.5000 |  27893449 B |
| BSON_Serialize          | Medium | 17,465.30 us |   337.291 us |   315.502 us | 17,385.07 us | 17,041.27 us |  18,222.42 us |  343.7500 |  156.2500 | 156.2500 |  22030238 B |
| Hyperion_Serialize      | Large  | 22,064.15 us |   427.043 us |   399.456 us | 21,916.19 us | 21,393.27 us |  22,805.01 us |  125.0000 |   31.2500 |  31.2500 |  28827414 B |
| AvroConvert_Serialize   | Large  | 27,065.59 us |   519.945 us |   533.945 us | 26,796.13 us | 26,508.96 us |  28,451.35 us |  406.2500 |  125.0000 | 125.0000 |  58901806 B |
| MsgPack_Serialize       | Large  | 29,938.69 us |   597.353 us | 1,594.455 us | 30,274.85 us | 25,897.10 us |  32,986.87 us |  718.7500 |  562.5000 | 562.5000 |  67711742 B |
| CBOR_Serialize          | Large  | 47,750.86 us |   766.150 us |   716.657 us | 47,506.22 us | 46,906.84 us |  49,060.20 us |   90.9091 |         - |        - |  34038424 B |
| BSON_Serialize          | Large  | 70,826.86 us | 1,232.575 us | 1,092.646 us | 70,977.39 us | 69,262.30 us |  72,810.54 us |  714.2857 |         - |        - |  88364960 B |

## .NET 10 - JSON

| Method                            | data   | Mean         | Error       | StdDev       | Median       | Min          | Max          | Ratio | RatioSD | Gen0      | Gen1     | Gen2     | Allocated   | Alloc Ratio |
|---------------------------------- |------- |-------------:|------------:|-------------:|-------------:|-------------:|-------------:|------:|--------:|----------:|---------:|---------:|------------:|------------:|
| UTF8Json_Deserialize              | Large  |  63,663.3 us | 1,247.41 us |  2,014.33 us |  63,459.0 us |  60,291.2 us |  67,786.9 us |  0.82 |    0.12 |  625.0000 | 500.0000 | 125.0000 | 44666.22 KB |        1.61 |                                                                                                                                                             
| SpanJson_Deserialize              | Large  |  71,378.4 us | 2,036.76 us |  6,005.44 us |  70,187.6 us |  59,708.5 us |  87,731.0 us |  0.92 |    0.15 |  777.7778 | 666.6667 | 222.2222 | 44666.35 KB |        1.61 |
| SystemTextJson_Deserialize        | Large  |  79,153.6 us | 3,919.59 us | 11,557.00 us |  72,910.8 us |  65,929.8 us | 107,322.8 us |  1.02 |    0.21 |  571.4286 | 428.5714 | 142.8571 | 27752.75 KB |        1.00 |
| SystemTextJson_SrcGen_Deserialize | Large  |  90,394.5 us | 1,805.02 us |  5,031.69 us |  89,972.5 us |  81,859.4 us | 104,290.0 us |  1.17 |    0.17 |  571.4286 | 428.5714 | 142.8571 | 27752.75 KB |        1.00 |
| ServiceStack_Deserialize          | Large  | 157,694.0 us | 3,544.85 us | 10,340.49 us | 156,266.8 us | 135,520.4 us | 181,665.2 us |  2.03 |    0.31 | 1000.0000 | 750.0000 | 250.0000 | 37471.39 KB |        1.35 |
| NewtonsoftJson_Deserialize        | Large  | 174,056.7 us | 4,876.56 us | 14,378.66 us | 172,044.8 us | 139,549.5 us | 209,101.4 us |  2.24 |    0.36 | 1000.0000 | 750.0000 | 250.0000 |  39137.7 KB |        1.41 |
|                                   |        |              |             |              |              |              |              |       |         |           |          |          |             |             |
| SpanJson_Deserialize              | Medium |   8,265.4 us |   164.94 us |    284.51 us |   8,202.3 us |   7,717.5 us |   8,793.6 us |  0.75 |    0.03 |  250.0000 | 187.5000 | 109.3750 |  11124.6 KB |        1.60 |
| SystemTextJson_SrcGen_Deserialize | Medium |  10,754.0 us |   184.80 us |    172.86 us |  10,718.4 us |  10,538.6 us |  11,037.1 us |  0.98 |    0.02 |  140.6250 |  78.1250 |        - |  6935.35 KB |        1.00 |
| UTF8Json_Deserialize              | Medium |  10,836.1 us |   214.92 us |    238.89 us |  10,871.8 us |  10,436.4 us |  11,243.3 us |  0.99 |    0.02 |  250.0000 | 187.5000 | 109.3750 |  11124.6 KB |        1.60 |
| SystemTextJson_Deserialize        | Medium |  10,992.0 us |   139.67 us |    130.65 us |  10,973.3 us |  10,826.5 us |  11,313.5 us |  1.00 |    0.02 |  140.6250 |  78.1250 |        - |  6935.35 KB |        1.00 |
| ServiceStack_Deserialize          | Medium |  18,920.3 us |   246.41 us |    205.76 us |  18,999.5 us |  18,547.3 us |  19,178.4 us |  1.72 |    0.03 |  187.5000 |  93.7500 |        - |  9357.05 KB |        1.35 |
| NewtonsoftJson_Deserialize        | Medium |  20,442.8 us |   212.02 us |    177.05 us |  20,492.0 us |  20,114.7 us |  20,714.8 us |  1.86 |    0.03 |  187.5000 |  62.5000 |        - |   9776.7 KB |        1.41 |
|                                   |        |              |             |              |              |              |              |       |         |           |          |          |             |             |
| SpanJson_Deserialize              | Small  |     305.0 us |     3.53 us |      3.30 us |     303.5 us |     301.8 us |     312.7 us |  0.73 |    0.01 |   52.2461 |  52.2461 |  52.2461 |   446.97 KB |        1.60 |
| UTF8Json_Deserialize              | Small  |     364.2 us |     3.45 us |      3.22 us |     363.6 us |     359.8 us |     372.0 us |  0.87 |    0.01 |   52.7344 |  48.3398 |  47.3633 |   447.09 KB |        1.60 |
| SystemTextJson_SrcGen_Deserialize | Small  |     405.7 us |     3.45 us |      3.22 us |     406.1 us |     400.8 us |     410.2 us |  0.97 |    0.01 |    5.3711 |   2.4414 |        - |   279.73 KB |        1.00 |
| SystemTextJson_Deserialize        | Small  |     419.7 us |     2.94 us |      2.75 us |     418.5 us |     416.0 us |     425.1 us |  1.00 |    0.01 |    5.3711 |   2.4414 |        - |   279.73 KB |        1.00 |
| ServiceStack_Deserialize          | Small  |     724.2 us |     4.56 us |      4.27 us |     723.3 us |     717.3 us |     730.7 us |  1.73 |    0.01 |    6.8359 |   2.9297 |        - |   379.04 KB |        1.36 |
| NewtonsoftJson_Deserialize        | Small  |     768.9 us |    10.90 us |     10.20 us |     766.0 us |     753.2 us |     789.4 us |  1.83 |    0.03 |    7.8125 |   4.8828 |        - |   398.46 KB |        1.42 |
|                                   |        |              |             |              |              |              |              |       |         |           |          |          |             |             |
| SpanJson_Serialize                | Large  |  13,138.2 us |    96.97 us |     90.70 us |  13,114.6 us |  13,000.1 us |  13,292.0 us |  0.46 |    0.01 |   78.1250 |  78.1250 |  78.1250 | 16384.12 KB |        0.48 |
| SystemTextJson_Serialize          | Large  |  28,383.6 us |   503.89 us |    446.68 us |  28,253.6 us |  27,723.6 us |  29,462.4 us |  1.00 |    0.02 |   93.7500 |  93.7500 |  93.7500 | 33828.82 KB |        1.00 |
| SystemTextJson_SrcGen_Serialize   | Large  |  29,613.2 us |   298.94 us |    279.63 us |  29,623.1 us |  29,090.4 us |  30,131.6 us |  1.04 |    0.02 |   93.7500 |  93.7500 |  93.7500 | 33828.82 KB |        1.00 |
| UTF8Json_Serialize                | Large  |  39,119.9 us |   748.11 us |  1,270.36 us |  39,192.4 us |  36,894.2 us |  42,374.5 us |  1.38 |    0.05 |  928.5714 | 928.5714 | 928.5714 | 82320.34 KB |        2.43 |
| NewtonsoftJson_Serialize          | Large  |  51,640.5 us |   996.18 us |    883.09 us |  51,514.1 us |  50,298.2 us |  52,754.3 us |  1.82 |    0.04 |  900.0000 | 700.0000 |        - | 81289.28 KB |        2.40 |
| ServiceStack_Serialize            | Large  |  55,926.5 us |   700.10 us |    620.62 us |  55,863.6 us |  55,210.1 us |  57,482.4 us |  1.97 |    0.04 |  888.8889 |        - |        - | 77247.95 KB |        2.28 |
|                                   |        |              |             |              |              |              |              |       |         |           |          |          |             |             |
| SpanJson_Serialize                | Medium |   3,291.5 us |    21.52 us |     20.13 us |   3,300.7 us |   3,255.9 us |   3,317.9 us |  0.33 |    0.00 |  113.2813 | 113.2813 | 113.2813 |  4096.17 KB |        0.49 |
| SystemTextJson_SrcGen_Serialize   | Medium |  10,010.5 us |   102.89 us |     96.25 us |  10,004.7 us |   9,842.7 us |  10,200.9 us |  0.99 |    0.01 |  156.2500 | 156.2500 | 156.2500 |  8380.34 KB |        1.00 |
| SystemTextJson_Serialize          | Medium |  10,079.5 us |   116.83 us |    109.28 us |  10,090.1 us |   9,848.8 us |  10,297.5 us |  1.00 |    0.01 |  156.2500 | 156.2500 | 156.2500 |  8380.34 KB |        1.00 |
| UTF8Json_Serialize                | Medium |  10,804.8 us |   201.67 us |    207.10 us |  10,837.6 us |  10,395.5 us |  11,126.6 us |  1.07 |    0.02 |  546.8750 | 546.8750 | 546.8750 | 20445.63 KB |        2.44 |
| NewtonsoftJson_Serialize          | Medium |  14,191.3 us |   282.51 us |    614.15 us |  14,319.6 us |  12,473.3 us |  15,420.8 us |  1.41 |    0.06 |  578.1250 | 531.2500 | 343.7500 |    20167 KB |        2.41 |
| ServiceStack_Serialize            | Medium |  15,221.0 us |   285.31 us |    280.21 us |  15,285.8 us |  14,596.1 us |  15,612.8 us |  1.51 |    0.03 |  421.8750 | 187.5000 | 187.5000 | 19050.33 KB |        2.27 |
|                                   |        |              |             |              |              |              |              |       |         |           |          |          |             |             |
| SpanJson_Serialize                | Small  |     117.5 us |     1.22 us |      1.14 us |     118.2 us |     115.6 us |     118.5 us |  0.43 |    0.00 |   73.3643 |  73.3643 |  73.3643 |   256.12 KB |        0.76 |
| UTF8Json_Serialize                | Small  |     178.8 us |     1.86 us |      1.74 us |     178.5 us |     176.3 us |     181.9 us |  0.65 |    0.01 |  148.4375 | 148.4375 | 148.4375 |   551.82 KB |        1.64 |
| SystemTextJson_SrcGen_Serialize   | Small  |     273.9 us |     3.68 us |      3.44 us |     272.8 us |     269.0 us |     280.1 us |  0.99 |    0.01 |   90.3320 |  90.3320 |  90.3320 |   336.21 KB |        1.00 |
| SystemTextJson_Serialize          | Small  |     275.9 us |     1.50 us |      1.33 us |     275.7 us |     274.1 us |     278.7 us |  1.00 |    0.01 |   90.3320 |  90.3320 |  90.3320 |   336.21 KB |        1.00 |
| NewtonsoftJson_Serialize          | Small  |     476.8 us |     9.04 us |      8.46 us |     475.3 us |     467.1 us |     497.0 us |  1.73 |    0.03 |   99.6094 |  92.7734 |  89.8438 |   821.16 KB |        2.44 |
| ServiceStack_Serialize            | Small  |     582.9 us |     7.50 us |      6.65 us |     581.4 us |     575.6 us |     596.1 us |  2.11 |    0.03 |   90.8203 |  82.0313 |  82.0313 |   763.02 KB |        2.27 |