using Microsoft.EntityFrameworkCore;
using SignalR_Sample.WebApi.Domain;

namespace SignalR_Sample.WebApi.Infrastructure.Context
{
   

    public class SignalRSampleContext : DbContext
    {
        public DbSet<Message> Messages { get; set; }
        public DbSet<Person> People { get; set; }
        public SignalRSampleContext(DbContextOptions<SignalRSampleContext> options) : base(options: options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SignalRSampleContext).Assembly);
        }
    }
}
