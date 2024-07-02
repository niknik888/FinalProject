using Blog2.API.Data.Models.Response;

namespace Blog2.API.Data.Repositories.IRepositories
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
