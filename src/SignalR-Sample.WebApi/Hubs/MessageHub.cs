using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using SignalR_Sample.WebApi.Application.Interfaces;
using SignalR_Sample.WebApi.Domain;
using SignalR_Sample.WebApi.Infrastructure.Repositories;
using System.Collections.Concurrent;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SignalR_Sample.WebApi.Hubs
{
    [Authorize]
    public class MessageHub : Hub<IMessageMethods>, IMessageHub
    {
        private static readonly ConnectionMapping<long> users
            = new ConnectionMapping<long>();

        private readonly IPerson personRepository;
        private readonly IHubContext<MessageHub, IMessageMethods> hubContext;

        public MessageHub(
            IPerson _personRepository,
            IHubContext<MessageHub, IMessageMethods> _hubContext)
        {
            personRepository = _personRepository;
            hubContext = _hubContext;   
        }

       
        public override async Task OnConnectedAsync()
        {
            string userName = Context.User.Identity.Name;
            var person =
               await personRepository.GetByUserName(userName);

            users.Add(person.Id, Context.ConnectionId);

            await base.OnConnectedAsync();
        }

      


        public override async Task OnDisconnectedAsync(Exception ex)
        {

            string userName = Context.User.Identity.Name;
            var person =
              await personRepository.GetByUserName(userName);
            users.Remove(person.Id, Context.ConnectionId);

            await base.OnDisconnectedAsync(ex);
        }

        public Task SendMessageToUser(long personId, string message)
        {
            IEnumerable<string> _connections =
                users.GetConnections(personId);
            hubContext.Clients.Clients(_connections).MessageToUser(message);

            return Task.CompletedTask;

        }

        public Task SendMessageToUsers(IEnumerable<long> personIds, string message)
        {
            throw new NotImplementedException();
        }

        public Task SendMessageToAllUsers(string message)
        {
            throw new NotImplementedException();
        }
    }
}
