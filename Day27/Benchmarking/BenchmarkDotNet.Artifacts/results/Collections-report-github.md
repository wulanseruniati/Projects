```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3737/23H2/2023Update/SunValley3)
Intel Core i7-8550U CPU 1.80GHz (Kaby Lake R), 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.300
  [Host]     : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX2


```
| Method             | Mean       | Error     | StdDev    | Allocated |
|------------------- |-----------:|----------:|----------:|----------:|
| AccessIntArray     |  0.2492 ns | 0.0083 ns | 0.0065 ns |         - |
| AccessJaggedArray  |  0.1206 ns | 0.0107 ns | 0.0084 ns |         - |
| AccessTupleArray   |  0.7478 ns | 0.0311 ns | 0.0260 ns |         - |
| ForeachIntArray    | 13.6434 ns | 0.3096 ns | 0.5172 ns |         - |
| ForeachJaggedArray |  5.6279 ns | 0.1566 ns | 0.2144 ns |         - |
| ForeachTupleArray  |  2.5463 ns | 0.0413 ns | 0.0386 ns |         - |
