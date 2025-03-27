using Application.CQRS.Posts.Commands;
using MediatR;
using Repository.Repositories;

namespace Application.CQRS.Posts.Handlers.CommandHandlers;

public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand>
{
    private readonly IPostRepository _postRepository;

    public UpdatePostCommandHandler(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    public async Task<Unit> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
    {
        var post = await _postRepository.GetByIdAsync(request.Id);
        //if (post == null) throw new NotFoundException("Post not found");

        post.Content = request.Content;
        post.ImageUrl = request.ImageUrl;
        post.UpdatedDate = DateTime.UtcNow;

        await _postRepository.UpdateAsync(post);
        return Unit.Value; 
    }
}
