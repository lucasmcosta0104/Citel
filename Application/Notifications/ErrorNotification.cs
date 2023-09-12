using MediatR;

namespace Citel.Application.Notifications
{
    public class ErrorNotification : INotification
    {
        public string Message { get; set; }
        public string PilhaErro { get; set; }
    }
}
