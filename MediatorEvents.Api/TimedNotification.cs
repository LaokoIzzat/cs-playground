using MediatR;

namespace MediatorEvents.Api
{
    public sealed class TimedNotification : INotification
    {
        public TimedNotification(TimeOnly time)
        {
            Time = time;
        }

        public TimeOnly Time { get; }        
    }
}
