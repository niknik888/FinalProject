using Blog2.DAL.Models;
using Blog2.DAL.Repositories.IRepositories;

namespace Blog2.DAL.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private Blog2DbContext _context;

        public CommentRepository(Blog2DbContext context)
        {
            _context = context;
        }

        public List<Comment> GetAllComments()
        {
            return _context.Comments.ToList();
        }

        public Comment GetComment(Guid id)
        {
            return _context.Comments.FirstOrDefault(c => c.Id == id);
        }

        public List<Comment> GetCommentsByPostId(Guid id)
        {
            return _context.Comments.Where(c => c.PostId == id).ToList();
        }

        public async Task AddComment(Comment comment)
        {
            _context.Comments.Add(comment);
            await SaveChangesAsync();
        }

        public async Task UpdateComment(Comment comment)
        {
            _context.Comments.Update(comment);
            await SaveChangesAsync();
        }

        public async Task RemoveComment(Guid id)
        {
            _context.Comments.Remove(GetComment(id));
            await SaveChangesAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            if (await _context.SaveChangesAsync() > 0)
            {
                return true;
            }
            return false;
        }
    }
}
