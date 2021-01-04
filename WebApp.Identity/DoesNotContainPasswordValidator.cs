using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace WebApp.Identity
{
    public class DoesNotContainPasswordValidator<Tuser> :
        IPasswordValidator<Tuser> where Tuser : class
    {
        public async Task<IdentityResult> ValidateAsync(UserManager<Tuser> manager, Tuser user, string password)
        {
            var username = await manager.GetUserNameAsync(user);

            if (username == password)
                return IdentityResult.Failed(new IdentityError { Description = "O Login não pode ser igual ao Password" });
            if (password.Contains("password"))
                return IdentityResult.Failed(new IdentityError { Description = "A senha não pode ser Password" });

            return IdentityResult.Success;

        }
    }
}
