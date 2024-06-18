```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3737/23H2/2023Update/SunValley3)
Intel Core i7-8550U CPU 1.80GHz (Kaby Lake R), 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.300
  [Host]     : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX2


```
| Method          | iterationNumber | Mean          | Error        | StdDev        | Median        | Gen0     | Allocated |
|---------------- |---------------- |--------------:|-------------:|--------------:|--------------:|---------:|----------:|
| **MyString**        | **10**              |     **151.10 ns** |     **3.085 ns** |      **5.484 ns** |     **150.92 ns** |   **0.0801** |     **336 B** |
| MyStringBuilder | 10              |      75.54 ns |     1.601 ns |      4.247 ns |      75.55 ns |   0.0362 |     152 B |
| **MyString**        | **100**             |   **2,781.74 ns** |    **55.362 ns** |    **143.893 ns** |   **2,796.68 ns** |   **4.9858** |   **20856 B** |
| MyStringBuilder | 100             |   1,000.36 ns |    19.908 ns |     34.341 ns |   1,002.50 ns |   0.3052 |    1280 B |
| **MyString**        | **1000**            | **246,418.51 ns** | **4,881.438 ns** | **11,410.204 ns** | **248,931.98 ns** | **678.7109** | **2840456 B** |
| MyStringBuilder | 1000            |   7,892.33 ns |   157.363 ns |    433.424 ns |   7,763.62 ns |   3.5095 |   14712 B |
