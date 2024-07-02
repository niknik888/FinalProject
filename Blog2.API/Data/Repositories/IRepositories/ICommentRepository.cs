using Blog2.API.Data.Models.Response;

namespace Blog2.API.Data.Repositories.IRepositories
{
    public interface ICommentRepository
    {
        List<Comment> GetAllComments();
        Comment GetComment(Guid id);
        List<Comment> GetCommentsByPostId(Guid id);
        Task AddComment(Comment item);
        Task UpdateComment(Comment item);
        Task RemoveComment(Guid id);
        Task<bool> SaveChangesAsync();
    }
}
