using Application.CQRS.Posts.Commands;
using Application.CQRS.Posts.DTOs;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Repository.Common;
using Repository.Repositories;

namespace Application.CQRS.Posts.Handlers.CommandHandlers;

public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, CreatePostResponseDto>
{
    private readonly IPostRepository _postRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public CreatePostCommandHandler(IPostRepository postRepository, IMapper mapper)
    {
        _postRepository = postRepository;
        _mapper = mapper;
    }

    public async Task<CreatePostResponseDto> Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {
        var post = _mapper.Map<Post>(request);
        await _postRepository.AddAsync(post);
        await _unitOfWork.SaveChangesAsync();

        return _mapper.Map<CreatePostResponseDto>(post);
    }
}
