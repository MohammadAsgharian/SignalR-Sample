namespace SignalR_Sample.WebApi.Domain
{
    public interface IMessage
    {
        /// <summary>
        /// Create New Message
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>Id of new message</returns>
        Task<int> CreateMessage(
            Message request,
            CancellationToken cancellationToken = default);
    }
}
