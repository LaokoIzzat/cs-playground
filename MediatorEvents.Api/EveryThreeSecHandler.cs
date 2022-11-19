using MediatR;

namespace MediatorEvents.Api
{
    public sealed class EveryThreeSecHandler : INotificationHandler<TimedNotification>
    {
        public Task Handle(TimedNotification notification, CancellationToken cancellationToken)
        {
            if (notification.Time.Second % 3 == 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(notification.Time.ToLongTimeString());
            }
            return Task.CompletedTask;
        }
    }
}
