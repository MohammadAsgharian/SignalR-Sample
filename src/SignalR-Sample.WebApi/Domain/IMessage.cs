namespace SignalR_Sample.WebApi.Domain
{
    public interface IMessage
    {
        /// <summary>
        /// Create New Message
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        Task<int> CreateMessageAsync(
            Message request,
            CancellationToken cancellationToken = default);
    }
}
