using Application.CQRS.Posts.DTOs;
using Application.CQRS.Posts.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Repository.Repositories;

namespace Application.CQRS.Posts.Handlers.QueryHandlers;

public class GetPostsByUserIdQueryHandler : IRequestHandler<GetPostsByUserIdQuery, List<PostDto>>
{
    private readonly IPostRepository _postRepository;

    public GetPostsByUserIdQueryHandler(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    public async Task<List<PostDto>> Handle(GetPostsByUserIdQuery request, CancellationToken cancellationToken)
    {
        var posts = await _postRepository.GetByUserId(request.UserId).ToListAsync();
        return posts.Select(post => new PostDto
        {
            Id = post.Id,
            UserId = post.UserId,
            Content = post.Content,
            ImageUrl = post.ImageUrl,
            CreatedDate = post.CreatedDate
        }).ToList();
    }
}
