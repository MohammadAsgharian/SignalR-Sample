using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SignalR_Sample.WebApi.Domain
{
    // Repository for Person Entity
    public interface IPerson
    {
        /// <summary>
        /// Get Person By UserName
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>Person</returns>
        Task<Person> GetByUserName(
            string UserName, 
            CancellationToken cancellationToken = default);

       }
}
