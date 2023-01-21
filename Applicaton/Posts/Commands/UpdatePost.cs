using Domain.Models;
using MediatR;

namespace Applicaton.Posts.Commands;

public class UpdatePost : IRequest<Post?>
{
  public int? PostId { get; set; }
  public string? UpdatedContent { get; set; }
}
