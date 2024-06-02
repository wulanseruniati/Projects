int refParam = 7;
int inParam = 10;
int outParam;

ExampleMethod(ref refParam,in inParam,out outParam);
System.Console.WriteLine(refParam);
System.Console.WriteLine(inParam);
System.Console.WriteLine(outParam);

static void ExampleMethod(ref int refParam, in int inParam, out int outParam) {
    refParam += 10;
    //in ga boleh diubah2 - performa bacanya cepet
    //out wajib di-inisialisasi
    outParam = 20;
}