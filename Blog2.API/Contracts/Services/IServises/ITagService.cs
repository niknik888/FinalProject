using Blog2.API.Data.Models.Request.Tags;
using Blog2.API.Data.Models.Response;

namespace Blog2.API.Contracts.Services.IServises
{
    public interface ITagService
    {
        Task<Guid> CreateTag(TagCreateRequest model);
        Task EditTag(TagEditRequest model);
        Task RemoveTag(Guid id);
        Task<List<Tag>> GetTags();
    }
}
