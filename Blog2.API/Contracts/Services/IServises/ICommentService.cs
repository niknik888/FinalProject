using Blog2.API.Data.Models.Request.Comments;
using Blog2.API.Data.Models.Response;

namespace Blog2.API.Contracts.Services.IServises
{
    public interface ICommentService
    {
        Task<Guid> CreateComment(CommentCreateRequest model);
        Task<int> EditComment(CommentEditRequest model);
        Task RemoveComment(Guid id);
        Task<List<Comment>> GetComments();
    }
}
