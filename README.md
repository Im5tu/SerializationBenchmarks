# SerializationBenchmarks

As part of a [recent YouTube video](), I went through a bunch of serializers to see their current levels of performance. I'm happy for this repository to be improved in terms of fixing any minor issues, adding new scenarios or adding serialization frameworks.

## Serializers

### JSON
- Jil: https://www.nuget.org/packages/Jil/
- Newtonsoft.Json: https://www.nuget.org/packages/Newtonsoft.Json/
- ServiceStack.Text: https://www.nuget.org/packages/ServiceStack.Text/
- SpanJson: https://www.nuget.org/packages/SpanJson
- UTF8Json: https://www.nuget.org/packages/Utf8Json

### Binary
- AvroConvert: https://www.nuget.org/packages/AvroConvert/
- Bebop: https://www.nuget.org/packages/bebop
- BSON: https://www.nuget.org/packages/MongoDB.Bson
- GroBuf: https://www.nuget.org/packages/GroBuf
- Hyperion: https://www.nuget.org/packages/Hyperion
- MessagePack: https://www.nuget.org/packages/MessagePack
- MsgPack: https://www.nuget.org/packages/MsgPack
- protobuf-net: https://www.nuget.org/packages/protobuf-net

## Current JSON Serializer Results (2022-08-28)

```
BenchmarkDotNet=v0.13.2, OS=Windows 11 (10.0.22000.856/21H2)
Intel Core i9-9900K CPU 3.60GHz (Coffee Lake), 1 CPU, 16 logical and 8 physical cores
.NET SDK=7.0.100-preview.7.22377.5
  [Host]     : .NET 7.0.0 (7.0.22.37506), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.0 (7.0.22.37506), X64 RyuJIT AVX2
```

|                     Method |   data |         Mean |       Error |      StdDev |          Min |          Max | Ratio | RatioSD |      Gen0 |      Gen1 |      Gen2 |   Allocated | Alloc Ratio |
|--------------------------- |------- |-------------:|------------:|------------:|-------------:|-------------:|------:|--------:|----------:|----------:|----------:|------------:|------------:|
|       SpanJson_Deserialize |  Large | 101,661.9 μs |   874.84 μs |   818.33 μs | 100,470.2 μs | 102,896.4 μs |  0.73 |    0.01 | 4000.0000 | 2000.0000 |  666.6667 | 44666.61 KB |        1.00 |
|            Jil_Deserialize |  Large | 108,768.4 μs | 1,155.14 μs | 1,080.52 μs | 107,054.8 μs | 110,868.5 μs |  0.78 |    0.02 | 3800.0000 | 1800.0000 |  600.0000 | 27753.05 KB |        0.62 |
|       UTF8Json_Deserialize |  Large | 119,316.9 μs |   758.12 μs |   709.15 μs | 117,974.9 μs | 120,617.9 μs |  0.86 |    0.01 | 3800.0000 | 1800.0000 |  600.0000 |  44666.6 KB |        1.00 |
| SystemTextJson_Deserialize |  Large | 139,241.3 μs | 2,025.72 μs | 1,894.86 μs | 135,596.8 μs | 142,510.1 μs |  1.00 |    0.00 | 3750.0000 | 1750.0000 |  500.0000 | 44670.27 KB |        1.00 |
|   ServiceStack_Deserialize |  Large | 224,654.8 μs | 2,433.58 μs | 2,276.38 μs | 221,246.3 μs | 228,378.6 μs |  1.61 |    0.03 | 4666.6667 | 2333.3333 |  333.3333 | 37471.91 KB |        0.84 |
| NewtonsoftJson_Deserialize |  Large | 275,030.3 μs | 3,333.39 μs | 3,118.05 μs | 270,979.2 μs | 280,813.0 μs |  1.98 |    0.03 | 5500.0000 | 3000.0000 |  500.0000 | 42297.98 KB |        0.95 |
|                            |        |              |             |             |              |              |       |         |           |           |           |             |             |
|       SpanJson_Deserialize | Medium |  22,156.4 μs |   363.75 μs |   340.25 μs |  21,613.9 μs |  22,832.4 μs |  0.66 |    0.02 | 1156.2500 | 1031.2500 |  343.7500 | 11124.72 KB |        1.00 |
|            Jil_Deserialize | Medium |  24,329.3 μs |   134.05 μs |   118.83 μs |  24,039.8 μs |  24,487.2 μs |  0.72 |    0.01 | 1125.0000 |  968.7500 |  281.2500 |  6935.68 KB |        0.62 |
|       UTF8Json_Deserialize | Medium |  26,809.2 μs |   256.31 μs |   239.75 μs |  26,435.5 μs |  27,234.7 μs |  0.80 |    0.02 | 1156.2500 | 1031.2500 |  343.7500 | 11125.34 KB |        1.00 |
| SystemTextJson_Deserialize | Medium |  33,726.8 μs |   506.27 μs |   473.56 μs |  32,793.0 μs |  34,495.0 μs |  1.00 |    0.00 | 1125.0000 | 1000.0000 |  312.5000 | 11126.73 KB |        1.00 |
|   ServiceStack_Deserialize | Medium |  57,686.8 μs | 1,130.38 μs | 1,301.75 μs |  55,395.8 μs |  59,785.2 μs |  1.71 |    0.06 | 1333.3333 |  777.7778 |  222.2222 |  9357.37 KB |        0.84 |
| NewtonsoftJson_Deserialize | Medium |  64,757.3 μs |   440.60 μs |   390.58 μs |  64,096.6 μs |  65,423.3 μs |  1.92 |    0.03 | 1500.0000 |  875.0000 |  250.0000 | 10563.82 KB |        0.95 |
|                            |        |              |             |             |              |              |       |         |           |           |           |             |             |
|       SpanJson_Deserialize |  Small |     527.0 μs |     0.87 μs |     0.72 μs |     525.8 μs |     528.0 μs |  0.56 |    0.00 |   51.7578 |   51.7578 |   51.7578 |   446.93 KB |        1.60 |
|            Jil_Deserialize |  Small |     593.2 μs |     2.39 μs |     2.00 μs |     590.2 μs |     597.4 μs |  0.63 |    0.00 |   34.1797 |   16.6016 |         - |   279.63 KB |        1.00 |
|       UTF8Json_Deserialize |  Small |     695.0 μs |     3.47 μs |     3.07 μs |     691.1 μs |     701.2 μs |  0.74 |    0.00 |   82.0313 |   65.4297 |   47.8516 |   447.08 KB |        1.60 |
| SystemTextJson_Deserialize |  Small |     944.2 μs |     3.15 μs |     2.95 μs |     940.3 μs |     949.3 μs |  1.00 |    0.00 |   34.1797 |   16.6016 |         - |   279.68 KB |        1.00 |
|   ServiceStack_Deserialize |  Small |   1,615.9 μs |     4.78 μs |     3.99 μs |   1,609.8 μs |   1,623.9 μs |  1.71 |    0.00 |   44.9219 |   21.4844 |         - |   379.04 KB |        1.36 |
| NewtonsoftJson_Deserialize |  Small |   1,908.8 μs |     3.54 μs |     2.95 μs |   1,903.8 μs |   1,914.0 μs |  2.02 |    0.01 |   52.7344 |   25.3906 |         - |    431.2 KB |        1.54 |
|                            |        |              |             |             |              |              |       |         |           |           |           |             |             |
|         SpanJson_Serialize |  Large |  24,109.3 μs |    95.96 μs |    89.77 μs |  23,970.0 μs |  24,276.1 μs |  0.42 |    0.00 |  125.0000 |  125.0000 |  125.0000 | 16384.13 KB |        0.48 |
|         UTF8Json_Serialize |  Large |  40,362.9 μs |    93.65 μs |    83.02 μs |  40,163.7 μs |  40,522.2 μs |  0.70 |    0.00 |  333.3333 |  333.3333 |  333.3333 |  82319.4 KB |        2.40 |
|   SystemTextJson_Serialize |  Large |  57,987.4 μs |   246.64 μs |   218.64 μs |  57,614.8 μs |  58,366.4 μs |  1.00 |    0.00 |         - |         - |         - | 34297.07 KB |        1.00 |
|              Jil_Serialize |  Large |  59,603.1 μs |   961.06 μs |   802.53 μs |  58,141.5 μs |  60,744.8 μs |  1.03 |    0.01 | 4777.7778 | 2000.0000 |  666.6667 | 67817.08 KB |        1.98 |
|     ServiceStack_Serialize |  Large |  92,589.8 μs |   196.22 μs |   173.94 μs |  92,345.7 μs |  92,823.8 μs |  1.60 |    0.01 | 6000.0000 |         - |         - | 78480.48 KB |        2.29 |
|   NewtonsoftJson_Serialize |  Large | 133,693.5 μs | 2,312.63 μs | 2,050.08 μs | 129,370.6 μs | 136,320.5 μs |  2.31 |    0.04 | 6750.0000 | 3750.0000 | 1000.0000 | 81290.86 KB |        2.37 |
|                            |        |              |             |             |              |              |       |         |           |           |           |             |             |
|         SpanJson_Serialize | Medium |   6,183.1 μs |    55.63 μs |    52.03 μs |   6,042.5 μs |   6,249.6 μs |  0.45 |    0.00 |  125.0000 |  125.0000 |  125.0000 |  4096.11 KB |        0.48 |
|         UTF8Json_Serialize | Medium |   9,909.7 μs |   195.12 μs |   246.76 μs |   9,517.7 μs |  10,390.7 μs |  0.72 |    0.02 |  343.7500 |  343.7500 |  343.7500 | 20445.16 KB |        2.41 |
|              Jil_Serialize | Medium |  13,040.8 μs |   238.69 μs |   223.27 μs |  12,575.7 μs |  13,387.1 μs |  0.95 |    0.02 | 1375.0000 | 1296.8750 |  343.7500 | 16802.28 KB |        1.98 |
|   SystemTextJson_Serialize | Medium |  13,747.5 μs |    43.43 μs |    38.50 μs |  13,667.0 μs |  13,815.4 μs |  1.00 |    0.00 |  125.0000 |  125.0000 |  125.0000 |  8496.91 KB |        1.00 |
|     ServiceStack_Serialize | Medium |  27,223.5 μs |   101.26 μs |    89.77 μs |  27,007.7 μs |  27,304.0 μs |  1.98 |    0.01 | 1687.5000 |  218.7500 |  218.7500 | 19357.65 KB |        2.28 |
|   NewtonsoftJson_Serialize | Medium |  30,783.1 μs |   314.51 μs |   278.81 μs |  30,353.3 μs |  31,349.9 μs |  2.24 |    0.02 | 1875.0000 | 1406.2500 |  437.5000 | 20168.28 KB |        2.37 |
|                            |        |              |             |             |              |              |       |         |           |           |           |             |             |
|         SpanJson_Serialize |  Small |     231.9 μs |     0.94 μs |     0.88 μs |     230.9 μs |     233.7 μs |  0.46 |    0.00 |   73.7305 |   73.7305 |   73.7305 |   256.07 KB |        0.75 |
|         UTF8Json_Serialize |  Small |     312.3 μs |     1.63 μs |     1.45 μs |     309.0 μs |     314.9 μs |  0.61 |    0.01 |  149.4141 |  149.4141 |  149.4141 |   551.72 KB |        1.62 |
|              Jil_Serialize |  Small |     333.1 μs |     1.29 μs |     1.21 μs |     331.5 μs |     335.7 μs |  0.65 |    0.01 |  132.3242 |  105.9570 |   90.8203 |    674.6 KB |        1.98 |
|   SystemTextJson_Serialize |  Small |     508.8 μs |     5.53 μs |     5.17 μs |     500.9 μs |     515.5 μs |  1.00 |    0.00 |   89.8438 |   89.8438 |   89.8438 |   340.89 KB |        1.00 |
|     ServiceStack_Serialize |  Small |     948.1 μs |     3.14 μs |     2.62 μs |     942.4 μs |     951.7 μs |  1.87 |    0.02 |  142.5781 |   82.0313 |   82.0313 |   784.79 KB |        2.30 |
|   NewtonsoftJson_Serialize |  Small |   1,093.6 μs |     2.48 μs |     2.07 μs |   1,089.9 μs |   1,096.4 μs |  2.15 |    0.02 |  148.4375 |  113.2813 |   89.8438 |    821.4 KB |        2.41 |

## Current Binary Serializer Results (2022-08-28)

```
BenchmarkDotNet=v0.13.2, OS=Windows 11 (10.0.22000.856/21H2)
Intel Core i9-9900K CPU 3.60GHz (Coffee Lake), 1 CPU, 16 logical and 8 physical cores
.NET SDK=7.0.100-preview.7.22377.5
  [Host]     : .NET 7.0.0 (7.0.22.37506), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.0 (7.0.22.37506), X64 RyuJIT AVX2
```

|                  Method |   data |          Mean |        Error |       StdDev |           Min |           Max |       Gen0 |      Gen1 |     Gen2 |    Allocated |
|------------------------ |------- |--------------:|-------------:|-------------:|--------------:|--------------:|-----------:|----------:|---------:|-------------:|
|      GroBuf_Deserialize |  Small |     126.06 μs |     0.971 μs |     0.909 μs |     125.17 μs |     128.11 μs |    31.4941 |   15.6250 |        - |     257.6 KB |
|       Bebop_Deserialize |  Small |     128.85 μs |     1.768 μs |     1.653 μs |     126.57 μs |     131.48 μs |    32.4707 |   16.1133 |        - |    265.63 KB |
| MessagePack_Deserialize |  Small |     313.09 μs |     0.727 μs |     0.607 μs |     312.23 μs |     314.30 μs |    31.2500 |   15.6250 |        - |    257.53 KB |
| ProtoBufNet_Deserialize |  Small |     314.95 μs |     0.876 μs |     0.732 μs |     313.22 μs |     316.05 μs |    32.2266 |   16.1133 |        - |     263.9 KB |
|    Hyperion_Deserialize |  Small |     376.44 μs |     1.557 μs |     1.380 μs |     375.18 μs |     379.27 μs |    37.5977 |   18.5547 |        - |    308.03 KB |
|     MsgPack_Deserialize |  Small |     463.16 μs |     1.135 μs |     0.948 μs |     461.80 μs |     465.48 μs |    38.0859 |   19.0430 |        - |    314.67 KB |
| AvroConvert_Deserialize |  Small |   1,624.59 μs |     3.921 μs |     3.667 μs |   1,618.63 μs |   1,631.68 μs |   146.4844 |   91.7969 |        - |   1196.74 KB |
|        BSON_Deserialize |  Small |   1,900.54 μs |     4.469 μs |     3.962 μs |   1,895.06 μs |   1,910.15 μs |    82.0313 |   41.0156 |        - |    685.43 KB |
|      GroBuf_Deserialize | Medium |  10,129.20 μs |   173.654 μs |   145.009 μs |   9,879.41 μs |  10,400.83 μs |  1000.0000 |  828.1250 | 218.7500 |   6380.19 KB |
|       Bebop_Deserialize | Medium |  11,120.75 μs |   129.874 μs |   121.484 μs |  10,882.47 μs |  11,349.30 μs |  1062.5000 |  890.6250 | 265.6250 |   6574.85 KB |
| ProtoBufNet_Deserialize | Medium |  12,238.41 μs |   102.122 μs |    95.525 μs |  12,093.78 μs |  12,413.77 μs |   812.5000 |   31.2500 |  15.6250 |   6536.26 KB |
| MessagePack_Deserialize | Medium |  14,898.30 μs |   220.454 μs |   206.212 μs |  14,631.26 μs |  15,327.40 μs |   984.3750 |  812.5000 | 203.1250 |   6380.07 KB |
|    Hyperion_Deserialize | Medium |  25,265.62 μs |   309.974 μs |   274.784 μs |  24,803.45 μs |  25,858.66 μs |  1187.5000 | 1156.2500 | 281.2500 |   7607.25 KB |
|     MsgPack_Deserialize | Medium |  25,903.01 μs |   499.378 μs |   490.456 μs |  25,214.02 μs |  26,664.18 μs |  1250.0000 | 1218.7500 | 312.5000 |   7805.95 KB |
|       Bebop_Deserialize |  Large |  50,567.56 μs |   573.187 μs |   478.637 μs |  49,608.16 μs |  51,057.62 μs |  3812.5000 | 1250.0000 | 625.0000 |  26348.41 KB |
|      GroBuf_Deserialize |  Large |  51,449.51 μs | 1,015.933 μs |   997.782 μs |  49,537.95 μs |  53,133.28 μs |  3700.0000 | 1200.0000 | 600.0000 |  25565.67 KB |
| AvroConvert_Deserialize | Medium |  51,903.16 μs |   773.060 μs |   645.540 μs |  50,747.35 μs |  52,773.44 μs |  3000.0000 | 1100.0000 | 300.0000 |  25784.39 KB |
| MessagePack_Deserialize |  Large |  64,838.02 μs |   795.729 μs |   744.326 μs |  63,646.10 μs |  66,054.74 μs |  3500.0000 | 1000.0000 | 500.0000 |  25565.52 KB |
| ProtoBufNet_Deserialize |  Large |  68,971.02 μs |   402.711 μs |   356.993 μs |  68,271.01 μs |  69,480.62 μs |  3750.0000 | 1250.0000 | 625.0000 |  26191.24 KB |
|        BSON_Deserialize | Medium |  69,919.83 μs | 1,248.777 μs | 1,168.107 μs |  67,825.73 μs |  71,805.51 μs |  2250.0000 | 1250.0000 | 250.0000 |  16893.21 KB |
|    Hyperion_Deserialize |  Large | 104,109.75 μs | 2,021.546 μs | 2,628.581 μs |  96,510.22 μs | 107,325.70 μs |  4200.0000 | 4000.0000 | 600.0000 |   30449.5 KB |
|     MsgPack_Deserialize |  Large | 104,535.63 μs | 2,084.413 μs | 2,989.403 μs |  95,411.64 μs | 108,830.90 μs |  4400.0000 | 4200.0000 | 600.0000 |  31268.59 KB |
| AvroConvert_Deserialize |  Large | 214,834.48 μs | 4,208.031 μs | 5,760.000 μs | 205,774.70 μs | 222,545.27 μs | 11000.0000 | 3666.6667 | 333.3333 | 102926.81 KB |
|        BSON_Deserialize |  Large | 278,588.00 μs | 3,905.807 μs | 3,653.495 μs | 272,944.85 μs | 285,646.45 μs |  8500.0000 | 4500.0000 | 500.0000 |  67674.98 KB |
|                         |        |               |              |              |               |               |            |           |          |              |
|        GroBuf_Serialize |  Small |      92.10 μs |     0.264 μs |     0.247 μs |      91.59 μs |      92.56 μs |    27.0996 |   27.0996 |  27.0996 |    185.11 KB |
|   MessagePack_Serialize |  Small |     164.27 μs |     0.812 μs |     0.720 μs |     163.57 μs |     165.72 μs |     8.0566 |    1.4648 |        - |     67.71 KB |
|         Bebop_Serialize |  Small |     178.81 μs |     1.618 μs |     1.434 μs |     173.96 μs |     179.84 μs |    71.2891 |   71.2891 |  71.2891 |    361.06 KB |
|   ProtoBufNet_Serialize |  Small |     246.94 μs |     0.470 μs |     0.417 μs |     246.22 μs |     247.65 μs |    26.8555 |    6.3477 |        - |    223.26 KB |
|       MsgPack_Serialize |  Small |     285.85 μs |     0.664 μs |     0.518 μs |     285.31 μs |     287.11 μs |    70.8008 |   18.5547 |        - |    582.06 KB |
|      Hyperion_Serialize |  Small |     346.02 μs |     0.783 μs |     0.694 μs |     345.02 μs |     347.17 μs |    52.7344 |   33.6914 |  22.9492 |     375.3 KB |
|   AvroConvert_Serialize |  Small |   1,222.34 μs |    24.193 μs |    27.861 μs |   1,158.06 μs |   1,262.28 μs |   191.4063 |   85.9375 |  46.8750 |   1446.83 KB |
|          BSON_Serialize |  Small |   1,445.19 μs |     3.636 μs |     3.401 μs |   1,439.43 μs |   1,450.07 μs |   158.2031 |   99.6094 |  95.7031 |   1068.03 KB |
|        GroBuf_Serialize | Medium |   2,891.70 μs |    14.162 μs |    13.247 μs |   2,865.62 μs |   2,914.01 μs |    70.3125 |   70.3125 |  70.3125 |   4578.04 KB |
|   MessagePack_Serialize | Medium |   4,220.83 μs |    24.464 μs |    22.884 μs |   4,156.10 μs |   4,253.07 μs |    70.3125 |   70.3125 |  70.3125 |   1696.47 KB |
|         Bebop_Serialize | Medium |   4,419.32 μs |    88.329 μs |   184.375 μs |   3,889.52 μs |   4,710.28 μs |   531.2500 |  515.6250 | 515.6250 |  10467.91 KB |
|   ProtoBufNet_Serialize | Medium |   6,809.25 μs |    17.698 μs |    16.555 μs |   6,770.83 μs |   6,835.70 μs |   289.0625 |  273.4375 | 273.4375 |   6924.45 KB |
|      Hyperion_Serialize | Medium |   8,771.43 μs |    32.430 μs |    28.748 μs |   8,733.30 μs |   8,826.13 μs |   375.0000 |  234.3750 | 234.3750 |   7028.72 KB |
|       MsgPack_Serialize | Medium |   9,022.49 μs |   175.017 μs |   163.711 μs |   8,827.00 μs |   9,380.08 μs |   687.5000 |  421.8750 | 406.2500 |  14671.52 KB |
|        GroBuf_Serialize |  Large |  12,614.56 μs |   157.163 μs |   147.011 μs |  12,414.40 μs |  12,817.37 μs |    62.5000 |   62.5000 |  62.5000 |  18383.03 KB |
|         Bebop_Serialize |  Large |  16,465.05 μs |    60.234 μs |    56.343 μs |  16,361.03 μs |  16,567.23 μs |   937.5000 |  937.5000 | 937.5000 |  38922.14 KB |
|   MessagePack_Serialize |  Large |  18,148.88 μs |   331.651 μs |   310.227 μs |  17,885.76 μs |  18,783.28 μs |          - |         - |        - |   7028.22 KB |
|   AvroConvert_Serialize | Medium |  24,361.69 μs |   380.250 μs |   355.686 μs |  23,692.54 μs |  24,842.51 μs |  2687.5000 |  593.7500 | 406.2500 |  31075.08 KB |
|   ProtoBufNet_Serialize |  Large |  29,171.30 μs |   231.432 μs |   216.482 μs |  28,909.52 μs |  29,542.02 μs |   125.0000 |  125.0000 | 125.0000 |  27238.93 KB |
|          BSON_Serialize | Medium |  36,583.27 μs |   466.798 μs |   436.643 μs |  36,095.61 μs |  37,408.67 μs |  1500.0000 |  357.1429 | 357.1429 |  21983.21 KB |
|      Hyperion_Serialize |  Large |  38,272.55 μs |   583.632 μs |   545.930 μs |  37,605.90 μs |  39,005.85 μs |   714.2857 |  142.8571 | 142.8571 |  28152.17 KB |
|       MsgPack_Serialize |  Large |  42,688.16 μs |   778.692 μs |   728.389 μs |  41,623.82 μs |  44,013.88 μs |  1230.7692 |  384.6154 | 307.6923 |  66124.36 KB |
|   AvroConvert_Serialize |  Large |  86,476.29 μs | 1,382.152 μs | 1,292.866 μs |  84,737.23 μs |  88,647.35 μs |  9166.6667 |  333.3333 | 166.6667 | 124390.38 KB |
|          BSON_Serialize |  Large | 139,164.09 μs |   197.813 μs |   154.440 μs | 138,923.23 μs | 139,486.33 μs |  4750.0000 |         - |        - |  88169.16 KB |
