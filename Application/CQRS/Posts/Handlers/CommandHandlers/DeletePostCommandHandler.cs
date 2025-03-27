using Application.CQRS.Posts.Commands;
using MediatR;
using Repository.Repositories;

namespace Application.CQRS.Posts.Handlers.CommandHandlers;

public class DeletePostCommandHandler : IRequestHandler<DeletePostCommand>
{
    private readonly IPostRepository _postRepository;

    public DeletePostCommandHandler(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    public async Task<Unit> Handle(DeletePostCommand request, CancellationToken cancellationToken)
    {
        var post = await _postRepository.GetByIdAsync(request.Id);
        //if (post == null) throw new NotFoundException("Post not found");

        await _postRepository.DeleteAsync(request.Id);
        return Unit.Value;
    }
}

