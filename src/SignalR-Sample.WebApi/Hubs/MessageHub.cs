using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using SignalR_Sample.WebApi.Domain;
using SignalR_Sample.WebApi.Infrastructure.Repositories;
using System.Collections.Concurrent;

namespace SignalR_Sample.WebApi.Hubs
{
    [Authorize]
    public class MessageHub :Hub<MessageHub>
    {
        private static readonly ConcurrentDictionary<long, HashSet<string>> users
            = new ConcurrentDictionary<long, HashSet<string>>();

        private readonly IPerson personRepository;

        public MessageHub(IPerson _personRepository)
        {
            personRepository = _personRepository;
        }

        public IPerson PersonRepository { get; }

        public override async  Task OnConnectedAsync()
        {
            string userName = Context.User.Identity.Name;
            var person =
               await personRepository.GetByUserName(userName);


            string connectionId = Context.ConnectionId;

            var user = users.GetOrAdd(person.Id, _ =>  new HashSet<string>());

            lock (user)
            {
                user.Add(connectionId);
            }
            await base.OnConnectedAsync();
        }
        public override async Task OnDisconnectedAsync(Exception ex)
        {

            string userName = Context.User.Identity.Name;
            var person =
              await personRepository.GetByUserName(userName);
            string connectionId = Context.ConnectionId;
            HashSet<string> connection;
            users.TryGetValue(person.Id, out connection);

            if (connection != null)
            {

                lock (connection)
                {

                    connection.RemoveWhere(x=> x.Equals(connectionId));

                    if (!connection.Any())
                    {
                        users.TryRemove(person.Id, out HashSet<string> removedUser);
                     }
                }
            }

            await base.OnDisconnectedAsync(ex);
        }
    }
}
