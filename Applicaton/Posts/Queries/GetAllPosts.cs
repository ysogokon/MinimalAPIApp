using MediatR;
using Domain.Models;

namespace Applicaton.Posts.Queries;

public class GetAllPosts : IRequest<ICollection<Post>>
{
    
}
