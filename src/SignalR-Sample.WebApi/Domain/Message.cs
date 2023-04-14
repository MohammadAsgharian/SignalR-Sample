using System.Diagnostics;

namespace SignalR_Sample.WebApi.Domain
{
    public class Message : Entity<long>
    {
        public string Body { get; set; }
        public long PersonId { get; set; }
        public Person Person { get; set; }

        public Message() { }
    }
}
