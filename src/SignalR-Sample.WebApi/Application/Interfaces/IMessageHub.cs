namespace SignalR_Sample.WebApi.Application.Interfaces
{
    public interface IMessageHub
    {
        Task SendMessageToUser(long personId, string message);
        Task SendMessageToUsers(IEnumerable<long> personIds, string message);
        Task SendMessageToAllUsers(string message);
        
    }
}
