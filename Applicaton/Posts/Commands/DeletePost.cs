using MediatR;

namespace Applicaton.Posts.Commands;

public class DeletePost : IRequest
{
  public int PostId { get; set; }
}
