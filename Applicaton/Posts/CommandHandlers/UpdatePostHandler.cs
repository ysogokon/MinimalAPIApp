using Applicaton.Abstractions;
using Applicaton.Posts.Commands;
using Domain.Models;
using MediatR;

namespace Applicaton.Posts.CommandHandlers;

public class UpdatePostHandler : IRequestHandler<UpdatePost, Post?>
{
  private readonly IPostRepository _postsRepo;
  public UpdatePostHandler ( IPostRepository postsRepo )
  {
    _postsRepo = postsRepo;
  }

  public async Task<Post?> Handle ( UpdatePost request, CancellationToken cancellationToken )
  {
    var post = request.UpdatedContent is not null && request.PostId is not null ?
      await _postsRepo.UpdatePost ( request.UpdatedContent, request.PostId.Value ) : new Post ();
    return post;
  }
}
