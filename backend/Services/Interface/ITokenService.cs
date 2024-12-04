using backend.DTOS;

namespace backend.Services.Interface
{
    public interface ITokenService
    {
        string GerarToken(LoginDto loginDto);
    }
}
