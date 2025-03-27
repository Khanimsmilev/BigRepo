using Application.CQRS.Posts.DTOs;
using Application.CQRS.Posts.Queries;
using MediatR;
using Repository.Repositories;

namespace Application.CQRS.Posts.Handlers.QueryHandlers;

public class GetPostByIdQueryHandler : IRequestHandler<GetPostByIdQuery, PostDto>
{
    private readonly IPostRepository _postRepository;

    public GetPostByIdQueryHandler(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    public async Task<PostDto> Handle(GetPostByIdQuery request, CancellationToken cancellationToken)
    {
        var post = await _postRepository.GetByIdAsync(request.Id);
       // if (post == null) throw new NotFoundException("Post not found");

        return new PostDto
        {
            Id = post.Id,
            UserId = post.UserId,
            Content = post.Content,
            ImageUrl = post.ImageUrl,
            CreatedDate = post.CreatedDate
        };
    }
}
