using Blog2.DAL.Models;

namespace Blog2.DAL.Repositories.IRepositories
{
    public interface ITagRepository
    {
        List<Tag> GetAllTags();
        Tag GetTag(Guid id);
        Task AddTag(Tag tag);
        Task UpdateTag(Tag tag);
        Task RemoveTag(Guid id);
        Task<bool> SaveChangesAsync();
    }
}
