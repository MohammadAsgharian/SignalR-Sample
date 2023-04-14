using MediatR;
using SignalR_Sample.WebApi.Configurations;
using SignalR_Sample.WebApi.Domain;

namespace SignalR_Sample.WebApi.Application.Queries
{
    public record GetTokenResponse(
       long PersonId,
       string UserName,
       string Token);

    public record GetTokenQuery(string userName) : IRequest<GetTokenResponse>;

    public class GetTokenHandler : IRequestHandler<GetTokenQuery, GetTokenResponse>
    {

        private readonly IJwtTokenGenerator jwtTokenGenerator;
        private readonly IPerson personRepository;
        private readonly JwtSettings jwtSettings;

        public GetTokenHandler(
            JwtSettings _jwtSettings,
            IJwtTokenGenerator _jwtTokenGenerator,
            IPerson _personRepository)
        {
            jwtTokenGenerator = _jwtTokenGenerator;
            personRepository = _personRepository;
            jwtSettings = _jwtSettings;
        }

        public async Task<GetTokenResponse> Handle(GetTokenQuery request, CancellationToken cancellationToken)
        {
            var result =
                   await personRepository.GetByUserName(request.userName, cancellationToken);
            string token =
                  jwtTokenGenerator.GenerateToken(result.Id, result.UserName);

            return new GetTokenResponse(
                PersonId: result.Id,
                UserName: result.UserName,
                Token: token);
        }
    }
}
