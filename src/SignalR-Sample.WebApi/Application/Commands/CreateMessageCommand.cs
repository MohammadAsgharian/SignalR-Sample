using MediatR;
using SignalR_Sample.WebApi.Domain;

namespace SignalR_Sample.WebApi.Application.Commands
{
    public record CreateMessageCommand(long PersonId, string Body) : IRequest<int>;

    public class CreateMessageCommandHandler : IRequestHandler<CreateMessageCommand, int>
    {
        private readonly IMessage messageRepository;

        public CreateMessageCommandHandler(
            IMessage _messageRepository)
        {
            messageRepository = _messageRepository;
        }

        public async Task<int> Handle(CreateMessageCommand request, CancellationToken cancellationToken)
        {
            var message =
                new Message()
                {
                    Body = request.Body,
                    PersonId = request.PersonId
                };
            return await messageRepository.CreateMessageAsync(message);
        }
    }

}
