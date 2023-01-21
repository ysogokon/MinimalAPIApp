using Domain.Models;
using MediatR;

namespace Applicaton.Posts.Queries;

public class GetPostById : IRequest<Post?>
{
  public int? PostId { get; set; }
}
