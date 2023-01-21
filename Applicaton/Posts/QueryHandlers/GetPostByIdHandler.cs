using Applicaton.Abstractions;
using Applicaton.Posts.Queries;
using Domain.Models;
using MediatR;

namespace Applicaton.Posts.QueryHandlers;

public class GetPostByIdHandler : IRequestHandler<GetPostById, Post?>
{
  private readonly IPostRepository _postsRepo;

  public GetPostByIdHandler ( IPostRepository postsRepo )
  {
    _postsRepo = postsRepo;
  }
  public async Task<Post?> Handle ( GetPostById request, CancellationToken cancellationToken )
  {
    return request.PostId is not null ? await _postsRepo.GetPostById ( request.PostId.Value ) : new Post ();
  }
}
