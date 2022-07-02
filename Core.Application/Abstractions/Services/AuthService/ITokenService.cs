using Core.Application.Repositories;

namespace Core.Application.Abstractions.Services.AuthService
{
    public interface ITokenService : ITransientService
    {
        // Task<IResult<TokenResponse>> GetTokenAsync(TokenRequest request, string ipAddress);
        //
        // Task<IResult<TokenResponse>> RefreshTokenAsync(RefreshTokenRequest request, string ipAddress);
    }
}