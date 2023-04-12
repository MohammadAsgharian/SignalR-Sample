using Microsoft.EntityFrameworkCore;
using SignalR_Sample.WebApi.Domain;
using SignalR_Sample.WebApi.Infrastructure.Context;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SignalR_Sample.WebApi.Infrastructure.Repositories
{
    public class PersonRepository : IPerson
    {
        private readonly SignalRSampleContext Context;

        public PersonRepository(SignalRSampleContext _Context)
        {
            Context = _Context ?? throw new ArgumentNullException(nameof(_Context));
        }

        public async Task<Person?> GetByUserName(
            string UserName,
            CancellationToken cancellationToken = default)
            => await Context.People.FirstOrDefaultAsync(
                current => current.UserName == UserName, 
                cancellationToken);
    }
}
