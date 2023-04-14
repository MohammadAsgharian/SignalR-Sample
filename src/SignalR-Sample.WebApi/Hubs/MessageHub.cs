using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using SignalR_Sample.WebApi.Domain;
using SignalR_Sample.WebApi.Infrastructure.Repositories;
using System.Collections.Concurrent;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SignalR_Sample.WebApi.Hubs
{
    [Authorize]
    public class MessageHub : Hub<MessageHub>
    {
        private static readonly ConnectionMapping<long> users
            = new ConnectionMapping<long>();

        private readonly IPerson personRepository;

        public MessageHub(IPerson _personRepository)
        {
            personRepository = _personRepository;
        }

       
        public override async Task OnConnectedAsync()
        {
            string userName = Context.User.Identity.Name;
            var person =
               await personRepository.GetByUserName(userName);

            users.Add(person.Id, Context.ConnectionId);

            await base.OnConnectedAsync();
        }

        public async Task SendMessage(long PersonId, Message message)
        {

        }


        public override async Task OnDisconnectedAsync(Exception ex)
        {

            string userName = Context.User.Identity.Name;
            var person =
              await personRepository.GetByUserName(userName);
            users.Remove(person.Id, Context.ConnectionId);

            await base.OnDisconnectedAsync(ex);
        }

    }
}
