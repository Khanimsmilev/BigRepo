using Application.CQRS.Users.DTOs;
using MediatR;
using Repository.Repositories;

namespace Application.CQRS.Users.Queries.Handlers
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, GetUserByIdResponse>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByIdHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<GetUserByIdResponse> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.UserId);
            if (user == null)
                return null;

            return new GetUserByIdResponse
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                ProfilePictureUrl = user.ProfilePictureUrl,
                Headline = user.Headline,
                Summary = user.Summary,
                CurrentCompany = user.CurrentCompany,
                CurrentPosition = user.CurrentPosition,
                Location = user.Location,
                Industry = user.Industry,
                LinkedInUrl = user.LinkedInUrl,
                Role = user.Role.ToString(),
                LastActiveAt = user.LastActiveAt ?? DateTime.MinValue
            };
        }
    }
}
