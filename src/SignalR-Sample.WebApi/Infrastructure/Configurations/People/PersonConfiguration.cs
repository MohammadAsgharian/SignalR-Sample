using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SignalR_Sample.WebApi.Domain;

namespace SignalR_Sample.WebApi.Infrastructure.Configurations.People
{
  
    internal sealed class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Person", "SignalRSampleDB");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.UserName)
                   .HasMaxLength(300)
                   .IsRequired();
            builder.Property(x => x.Name)
                   .HasMaxLength(300)
                   .IsRequired();
        }
    }
}
