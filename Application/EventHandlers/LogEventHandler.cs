using Citel.Application.Notifications;
using MediatR;

namespace ProdutoApi.Application.EventHandlers
{
    public class LogEventHandler :  INotificationHandler<CategoriaCriadoNotification>, 
                                    INotificationHandler<ErrorNotification>,
                                    INotificationHandler<CategoriaExcluidoNotification>,
                                    INotificationHandler<EditaCategoriaNotification>
    {
        private readonly ILogger _logger;

        public LogEventHandler(ILogger<LogEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(CategoriaCriadoNotification notification, CancellationToken cancellationToken)
        {
            var message = "Categoria criada com sucesso";
            _logger.LogInformation(message, notification);
            return Task.CompletedTask;
        }

        public Task Handle(ErrorNotification notification, CancellationToken cancellationToken)
        {
            _logger.LogError(notification.Message, notification);
            return Task.CompletedTask;
        }

        public Task Handle(CategoriaExcluidoNotification notification, CancellationToken cancellationToken)
        {
            var message = "Categoria excluída com sucesso";
            _logger.LogInformation(message, notification);
            return Task.CompletedTask;
        }

        public Task Handle(EditaCategoriaNotification notification, CancellationToken cancellationToken)
        {
            var message = "Categoria alterada com sucesso";
            _logger.LogInformation(message, notification);
            return Task.CompletedTask;
        }
    }
}
