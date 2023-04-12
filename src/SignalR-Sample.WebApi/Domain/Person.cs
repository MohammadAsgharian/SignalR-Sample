namespace SignalR_Sample.WebApi.Domain
{
    public class Person : Entity<long>
    {
        public string Name { get; private set; }
        public string UserName { get; private set; }

        public Person()
        {

        }
    }
}
