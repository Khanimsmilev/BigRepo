using Application.CQRS.Users.DTOs;
using AutoMapper;
using MediatR;
using Repository.Common;

namespace Application.CQRS.Users.Queries.Handlers;


public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, UserDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetUserByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.UserRepository.GetByIdAsync(request.UserId);
        if (user == null)
            throw new KeyNotFoundException("User not found");
        //oz custom exception middleqare yazandan sonra keynotfoundu silecem
        return _mapper.Map<UserDto>(user);
    }
}

/*public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, UserDto>
{
private readonly IUnitOfWork _unitOfWork;
private readonly IMapper _mapper;

public GetUserByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
{
    _unitOfWork = unitOfWork;
    _mapper = mapper;
}

public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
{
    var user = await _unitOfWork.UserRepository.GetByIdAsync(request.Id);
    if (user == null)
        throw new NotFoundException("User not found");

    return _mapper.Map<UserDto>(user);
}
}*/
