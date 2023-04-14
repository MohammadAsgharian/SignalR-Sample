namespace SignalR_Sample.WebApi.Hubs
{
    public class UserConnection
    {
        public long PersonId { get; set; }
        public string UserName { get; set; }
        public HashSet<string> ConnectionIds { get; set; }
    }
}
