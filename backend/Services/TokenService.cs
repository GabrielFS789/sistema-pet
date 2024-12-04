using backend.AppDbContext;
using backend.DTOS;
using backend.Repositories.Interface;
using backend.Services.Interface;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace backend.Services
{
    public class TokenService : ITokenService
    {

        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _uof;
        public TokenService(IConfiguration configuration, IUnitOfWork uof)
        {
            _configuration = configuration;
            _uof = uof;
        }
        public string GerarToken(LoginDto login)
        {
            var usuario = _uof.UsuarioRepository.GetByEmail(login.Email);
            if (usuario is null || !Criptografia.Compara(login.Password, usuario.Password) || login.Email != usuario.Email)
            {
                return string.Empty;
            }

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtKey:secretKey"] ?? string.Empty));
            var signInCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var issuer = _configuration["Jwtkey:issuer"] ?? String.Empty;
            var audience = _configuration["Jwtkey:audience"] ?? String.Empty;

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, usuario.Nome),
                new Claim("usuarioId", usuario.Id.ToString()),
                new Claim("permissaoId", usuario.PermissaoId.ToString()),
                new Claim("Administrador", usuario.Administrador.ToString()),
            };

            var permissaoJson = JObject.FromObject(usuario.Permissao);
            foreach (var permissao in permissaoJson)
            {
                claims.Add(new Claim(permissao.Key, permissao.Value.ToString()));
            }

            var tokenOptions = new JwtSecurityToken(issuer,
               audience,
               claims,
               expires: DateTime.UtcNow.AddHours(1),
               signingCredentials: signInCredentials
               );

            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);

        }
    }
}
