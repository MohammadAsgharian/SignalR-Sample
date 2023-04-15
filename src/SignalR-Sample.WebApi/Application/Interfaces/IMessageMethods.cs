namespace SignalR_Sample.WebApi.Application.Interfaces
{
    public interface IMessageMethods
    {
        Task MessageToUser( string message);
        Task MessageToUsers(List<long> connectionIds, string message);
        Task MessageToAllUsers(string message);
    }
}
