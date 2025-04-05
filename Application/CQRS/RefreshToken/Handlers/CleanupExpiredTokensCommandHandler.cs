using Common.GlobalResponses.Generics;
using MediatR;
using Repository.Common;
using Application.CQRS.RefreshToken.Commands;

namespace Application.CQRS.RefreshToken.Handlers;
public class CleanupExpiredTokensCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<CleanupExpiredTokensCommand, Result<string>>
{
    public async Task<Result<string>> Handle(CleanupExpiredTokensCommand request, CancellationToken cancellationToken)
    {
        var tokens = await unitOfWork.RefreshTokenRepository.GetAllAsync();
        var expired = tokens.Where(x => x.ExpiryDate < DateTime.UtcNow).ToList();

        foreach (var token in expired)
        {
            unitOfWork.RefreshTokenRepository.Remove(token);
        }

        await unitOfWork.SaveChangesAsync();
        return Result<string>.Success($"{expired.Count} expired tokens cleaned.");
    }
}
