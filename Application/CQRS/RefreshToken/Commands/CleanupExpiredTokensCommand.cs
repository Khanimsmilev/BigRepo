using Common.GlobalResponses.Generics;
using MediatR;
public class CleanupExpiredTokensCommand : IRequest<Result<string>> { }

