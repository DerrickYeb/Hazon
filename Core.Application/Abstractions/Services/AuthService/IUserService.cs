using Core.Application.Repositories;

namespace Core.Application.Abstractions.Services.AuthService
{
    public interface IUserService : ITransientService
    {
        // Task<Result<List<UserDetailsDto>>> GetAllAsync();
        //
        // Task<IResult<UserDetailsDto>> GetAsync(string userId);
        //
        // Task<IResult<UserRolesResponse>> GetRolesAsync(string userId);
        //
        // Task<IResult<string>> AssignRolesAsync(string userId, UserRolesRequest request);
        // Task<Result<List<PermissionDto>>> GetPermissionsAsync(string id);
    }
}