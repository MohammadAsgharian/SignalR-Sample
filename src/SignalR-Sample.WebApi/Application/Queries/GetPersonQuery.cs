using MediatR;
using SignalR_Sample.WebApi.Configurations;
using SignalR_Sample.WebApi.Domain;

namespace SignalR_Sample.WebApi.Application.Queries
{
    public record GetPersonResponse(
        long Id,
        string Name);

    public record GetPersonQuery() : IRequest<List<GetPersonResponse>>;

    public class GetPersonHandler : IRequestHandler<GetPersonQuery, List<GetPersonResponse>>
    {

        private readonly IPerson personRepository;

        public GetPersonHandler(
            IPerson _personRepository)
        {
            personRepository = _personRepository;
        }

        public async Task<List<GetPersonResponse>> Handle(GetPersonQuery request, CancellationToken cancellationToken)
        {
            var result =
                   await personRepository.GetAll(cancellationToken);

            var response =
                new List<GetPersonResponse>();
            foreach (var person in result)
            {
                response.Add(new GetPersonResponse(
                    Id: person.Id,
                    Name: person.Name));
            }
            return response;
        }
    }
}
