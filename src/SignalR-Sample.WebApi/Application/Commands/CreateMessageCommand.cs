using MediatR;
using SignalR_Sample.WebApi.Domain;

namespace SignalR_Sample.WebApi.Application.Commands
{
    public record CreateMessageCommand(long PersonId, string MessageContent) : IRequest<int>;

    public class CreateMessageCommandHandler : IRequestHandler<CreateMessageCommand, int>
    {
        private readonly IPerson personRepository;

        public GetPersonHandler(
            IPerson _personRepository)
        {
            personRepository = _personRepository;
        }

        public async Task<int> Handle(CreateMessageCommand request, CancellationToken cancellationToken)
        {

            return result;
        }
    }

}
