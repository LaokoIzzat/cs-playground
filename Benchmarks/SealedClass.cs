namespace BenchmarkPerformance
{
    public sealed class SealedClass : BaseClass
    {
        public override void VoidMethod() { }
        public override int IntMethod() { return 3; }
    }
}
