using Blog2.API.Data.Models.Request.Posts;
using Blog2.API.Data.Models.Response;

namespace Blog2.API.Contracts.Services.IServises
{
    public interface IPostService
    {
        Task<PostCreateRequest> CreatePost();
        Task<Guid> CreatePost(PostCreateRequest model);
        Task<PostEditRequest> EditPost(Guid Id);
        Task EditPost(PostEditRequest model, Guid Id);
        Task RemovePost(Guid id);
        Task<List<Post>> GetPosts();
        Task<Post> ShowPost(Guid id);
    }
}
