using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SignalR_Sample.WebApi.Domain;

namespace SignalR_Sample.WebApi.Infrastructure.Configurations.Messages
{
    internal sealed class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.ToTable("Message", "SignalRSampleDB");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Body)
                   .HasMaxLength(500)
                   .IsRequired();


            builder.HasOne(x => x.Person)
                    .WithMany()
                    .HasForeignKey("PersonId");

        }
    }
}
