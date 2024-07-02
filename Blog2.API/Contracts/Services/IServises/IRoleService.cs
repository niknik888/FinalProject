using Blog2.API.Data.Models.Request.Roles;
using Blog2.API.Data.Models.Response;

namespace Blog2.API.Contracts.Services.IServises
{
    public interface IRoleService
    {
        Task<Guid> CreateRole(RoleCreateRequest model);
        Task EditRole(RoleEditRequest model);
        Task RemoveRole(Guid id);
        Task<List<Role>> GetRoles();
    }
}
