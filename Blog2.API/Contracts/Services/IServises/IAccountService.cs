using Blog2.API.Data.Models.Request.Users;
using Blog2.API.Data.Models.Response;
using Microsoft.AspNetCore.Identity;

namespace Blog2.API.Contracts.Services.IServises
{
    public interface IAccountService
    {
        Task<IdentityResult> Register(RegisterRequest model);
        Task<IdentityResult> EditAccount(UserEditRequest model);
        Task<SignInResult> Login(LoginRequest model);
        Task<UserEditRequest> EditAccount(Guid id);
        Task RemoveAccount(Guid id);
        Task<List<User>> GetAccounts();
    }
}
