using BenchmarkDotNet.Attributes;

namespace BenchmarkPerformance
{
    [MemoryDiagnoser(false)]
    public sealed class Benchmarks
    {
        private readonly BaseClass _baseClass = new BaseClass();
        private readonly BaseClass _openClass = new OpenClass();
        private readonly BaseClass _sealedClass = new SealedClass();

        //[Benchmark]
        //public void OpenVoidMethod() => _openClass.VoidMethod();

        //[Benchmark]
        //public void SealedVoidMethod() => _sealedClass.VoidMethod();

        //[Benchmark]
        //public void OpenIntMethod() => _openClass.IntMethod();

        //[Benchmark]
        //public void SealedIntMethod() => _sealedClass.IntMethod();

        [Benchmark]
        public bool IsCheckOpenClass() => _openClass is OpenClass;

        [Benchmark]
        public bool IsCheckSealedClass() => _sealedClass is SealedClass;
    }
}
