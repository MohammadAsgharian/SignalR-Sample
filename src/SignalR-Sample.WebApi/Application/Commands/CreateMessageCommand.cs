using MediatR;
using SignalR_Sample.WebApi.Application.Interfaces;
using SignalR_Sample.WebApi.Domain;

namespace SignalR_Sample.WebApi.Application.Commands
{
    public record CreateMessageCommand(long PersonId, string Body) : IRequest<int>;

    public class CreateMessageCommandHandler : IRequestHandler<CreateMessageCommand, int>
    {
        private readonly IMessage messageRepository;
        private readonly IMessageHub messageHub;
        public CreateMessageCommandHandler(
            IMessage _messageRepository,
             IMessageHub _messageHub)
        {
            messageRepository = _messageRepository;
            messageHub = _messageHub;
        }

        public async Task<int> Handle(CreateMessageCommand request, CancellationToken cancellationToken)
        {
            var message =
                new Message()
                {
                    Body = request.Body,
                    PersonId = request.PersonId
                };
            await messageHub.SendMessageToUser(request.PersonId, request.Body);
            return await messageRepository.CreateMessageAsync(message);
        }
    }

}
