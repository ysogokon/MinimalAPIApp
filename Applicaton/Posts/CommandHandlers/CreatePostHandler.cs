using Applicaton.Abstractions;
using Applicaton.Posts.Commands;
using Domain.Models;
using MediatR;

namespace Applicaton.Posts.CommandHandlers;

public class CreatePostHandler : IRequestHandler<CreatePost, Post>
{
  private readonly IPostRepository _postsRepo;
  public CreatePostHandler ( IPostRepository postsRepo )
  {
    _postsRepo = postsRepo;
  }

  public async Task<Post> Handle ( CreatePost request, CancellationToken cancellationToken )
  {
    Post newPost = new ()
    {
      Content = request.PostContent
    };

    return await _postsRepo.CreatePost ( newPost );
  }
}
