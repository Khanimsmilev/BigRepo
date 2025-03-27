using Application.CQRS.Users.DTOs;
using MediatR;
using Repository.Repositories;

namespace Application.CQRS.Users.Queries.Handlers
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, List<GetUserByIdResponse>>
    {
        private readonly IUserRepository _userRepository;

        public GetAllUsersHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<GetUserByIdResponse>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAll();

            return users.Select(user => new GetUserByIdResponse
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
            }).ToList();
        }
    }
}
