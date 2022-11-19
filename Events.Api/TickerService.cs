namespace Events.Api
{
    public sealed class TickerService
    {
        public event EventHandler<TickerEventArgs> Ticked;
        public readonly TransientService _transientService;

        public TickerService(TransientService transientService)
        {
            Ticked += OnEverySecond;
            Ticked += OnEveryThreeSeconds;
            Ticked += OnEverySecondPrintGuid;
            _transientService = transientService;
        }

        public void OnEverySecond(object? sender, TickerEventArgs args)
        {
            Console.WriteLine(args.Time.ToLongTimeString());
        }

        public void OnEveryThreeSeconds(object? sender, TickerEventArgs args)
        {
            if (args.Time.Second % 3 == 0)
                Console.WriteLine(args.Time.ToLongTimeString());
        }

        public void OnEverySecondPrintGuid(object? sender, TickerEventArgs args)
        {
            Console.WriteLine(_transientService.Id);
        }

        public void OnTick(TimeOnly time)
        {
            Ticked?.Invoke(this, new TickerEventArgs(time));
        }
    }

    public class TickerEventArgs
    {
        public TimeOnly Time { get; }

        public TickerEventArgs(TimeOnly time)
        {
            Time = time;
        }
    }
}
