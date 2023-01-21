using Applicaton.Posts.Commands;
using Applicaton.Posts.Queries;
using Domain.Models;
using MediatR;
using MinimalApi.Abstractions;

namespace MinimalApi.EndppintDefinitions;

public class PostEndpointDefinition : IEndpointDefinition
{
  //THIS IS NET7 implementation
  public void RegisterEndpoints ( WebApplication app )
  {
    var posts = app.MapGroup ( "/api/posts" );

    posts.MapGet ( "/{id}", GetPostById ).WithName ( "GetPostById" );
    posts.MapPost ( "/", CreatePost );
    posts.MapGet ( "/", GetAllPosts );
    posts.MapPut ( "/{id}", UpdatePost );
    posts.MapDelete ( "/{id}", DeletePost );
  }

  private async Task<IResult> GetPostById ( IMediator mediator, int id )
  {
    var getPost = new GetPostById { PostId = id };
    var post = await mediator.Send ( getPost );
    return TypedResults.Ok ( post );
  }

  private async Task<IResult> CreatePost ( IMediator mediator, Post post )
  {
    var createPost = new CreatePost { PostContent = post.Content };
    var createdPost = await mediator.Send ( createPost );
    return Results.CreatedAtRoute ( "GetPostById", new { createdPost.Id }, createdPost );
  }

  private async Task<IResult> GetAllPosts ( IMediator mediator )
  {
    var getCommand = new GetAllPosts ();
    var posts = await mediator.Send ( getCommand );
    return TypedResults.Ok ( posts );
  }

  private async Task<IResult> UpdatePost ( IMediator mediator, Post post, int id )
  {
    var updatePost = new UpdatePost { PostId = id, UpdatedContent = post.Content };
    var updatedPost = await mediator.Send ( updatePost );
    return TypedResults.Ok ( updatePost );
  }

  private async Task<IResult> DeletePost ( IMediator mediator, int id )
  {
    var deletePost = new DeletePost { PostId = id };
    await mediator.Send ( deletePost );
    return TypedResults.NoContent ();
  }

  // THIS IS GOOD FOR NET6

  // public void RegisterEndpoints ( WebApplication app )
  // {
  // var posts = app.MapGroup("/api/posts");
  //    app.MapGet ( "/api/posts/{id}", async ( IMediator mediator, int id ) =>
  //   {
  //     var getPost = new GetPostById { PostId = id };
  //     var post = await mediator.Send ( getPost );
  //     return Results.Ok ( post );
  //   } ).WithName ( "GetPostById" );

  //   app.MapPost ( "/api/posts", async ( IMediator mediator, [FromBody] Post post ) =>
  //   {
  //     var createPost = new CreatePost { PostContent = post.Content };
  //     var createdPost = await mediator.Send ( createPost );
  //     return Results.CreatedAtRoute ( "GetPostById", new { createdPost.Id }, createdPost );
  //   } );

  //   app.MapGet ( "/api/posts", async ( IMediator mediator ) =>
  //   {
  //     var getCommand = new GetAllPosts ();
  //     var posts = await mediator.Send ( getCommand );
  //     return Results.Ok ( posts );
  //   } );

  //   app.MapPut ( "/api/posts/{id}", async ( IMediator mediator, Post post, int id ) =>
  //   {
  //     var updatePost = new UpdatePost { PostId = id, UpdatedContent = post.Content };
  //     var updatedPost = await mediator.Send ( updatePost );
  //     return Results.Ok ( updatePost );
  //   } );

  //   app.MapDelete ( "/api/posts/{id}", async ( IMediator mediator, int id ) =>
  //   {
  //     var deletePost = new DeletePost { PostId = id };
  //     await mediator.Send ( deletePost );
  //     return Results.NoContent ();
  //} );
  // }

}
