using Applicaton.Abstractions;
using Applicaton.Posts.Commands;
using MediatR;

namespace Applicaton.Posts.CommandHandlers;

public class DeletePostHandler : IRequestHandler<DeletePost>
{
  private readonly IPostRepository _postsRepo;

  public DeletePostHandler ( IPostRepository postsRepo )
  {
    _postsRepo = postsRepo;
  }
  public async Task<Unit> Handle ( DeletePost request, CancellationToken cancellationToken )
  {
    await _postsRepo.DeletePost ( request.PostId );
    return Unit.Value;
  }
}
