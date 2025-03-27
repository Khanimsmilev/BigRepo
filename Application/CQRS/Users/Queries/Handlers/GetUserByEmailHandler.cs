using Application.CQRS.Users.DTOs;
using AutoMapper;
using MediatR;
using Repository.Repositories;

namespace Application.CQRS.Users.Queries.Handlers;

public class GetUserByEmailHandler : IRequestHandler<GetUserByEmailQuery, GetUserByEmailResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetUserByEmailHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<GetUserByEmailResponse> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByEmailAsync(request.Email);
        return _mapper.Map<GetUserByEmailResponse>(user);
    }
}
