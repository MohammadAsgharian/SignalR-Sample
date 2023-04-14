using SignalR_Sample.WebApi.Domain;
using SignalR_Sample.WebApi.Infrastructure.Context;

namespace SignalR_Sample.WebApi.Infrastructure.Repositories
{
    public class MessageRepository : IMessage
    {
        private readonly SignalRSampleContext Context;

        public MessageRepository(SignalRSampleContext _Context)
        {
            Context = _Context ?? throw new ArgumentNullException(nameof(_Context));
        }

        public async Task<int> CreateMessageAsync(Message request, CancellationToken cancellationToken = default)
        {
           await Context.Set<Message>().AddAsync(request, cancellationToken);
            return Context.SaveChanges();
        }
    }
}
