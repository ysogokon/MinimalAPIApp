using Domain.Models;
using MediatR;

namespace Applicaton.Posts.Commands;

public class CreatePost : IRequest<Post>
{
  public string? PostContent { get; set; }
}
