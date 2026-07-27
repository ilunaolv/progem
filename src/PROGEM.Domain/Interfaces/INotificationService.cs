namespace PROGEM.Domain.Interfaces;

public interface INotificationService
{
    Task SendAsync(string recipient, string subject, string message);
    Task SendBulkAsync(IEnumerable<string> recipients, string subject, string message);
}