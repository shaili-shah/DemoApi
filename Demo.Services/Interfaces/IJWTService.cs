using Demo.Core.ViewModels;

namespace Demo.Services.Interfaces
{
    public interface IJWTService
    {
        string GenerateJwtToken(UserWithRolesViewModel user);
    }
}
