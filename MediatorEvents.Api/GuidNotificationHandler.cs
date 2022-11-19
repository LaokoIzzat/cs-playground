using MediatR;

namespace MediatorEvents.Api
{
    public sealed class GuidNotificationHandler : INotificationHandler<TimedNotification>
    {
        private readonly TransientService _transientService;

        public GuidNotificationHandler(TransientService transientService)
        {
            _transientService = transientService;
        }

        public Task Handle(TimedNotification notification, CancellationToken cancellationToken)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(_transientService.Id);
            return Task.CompletedTask;
        }
    }
}
