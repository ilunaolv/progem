using PROGEM.Domain.Interfaces;

namespace PROGEM.Infrastructure.Notifications;

public class EmailNotificationService : INotificationService
{
    public Task SendAsync(string recipient, string subject, string message)
    {
        return Task.CompletedTask;
    }

    public Task SendBulkAsync(System.Collections.Generic.IEnumerable<string> recipients, string subject, string message)
    {
        return Task.CompletedTask;
    }
}