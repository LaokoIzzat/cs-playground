using MediatR;

namespace MediatorEvents.Api
{
    public sealed class EverySecHandler : INotificationHandler<TimedNotification>
    {
        public Task Handle(TimedNotification notification, CancellationToken cancellationToken)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(notification.Time.ToLongTimeString());
            return Task.CompletedTask;
        }
    }
}
