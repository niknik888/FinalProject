using Microsoft.AspNetCore.Identity;

namespace Blog2.API.Data.Models.Response
{
    public class Role : IdentityRole
    {
        public int? SecurityLvl { get; set; } = null;
    }
}
