namespace Events.Api
{
    public sealed class TransientService
    {
        public Guid Id { get; } = Guid.NewGuid(); 
    }
}
