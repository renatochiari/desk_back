using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Desk.Domain.Entities;
using Microsoft.IdentityModel.Tokens;

namespace Desk.Domain.Services
{
    public static class TokenService
    {
        public static string GerarToken(Usuario usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            var clienteId = "";

            if (usuario.ClienteId != null)
                usuario.ClienteId.ToString();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuario.Nome),
                    new Claim(ClaimTypes.Role, usuario.Regra),
                    new Claim("usuarioId", usuario.Id.ToString()),
                    new Claim("empresaId", usuario.EmpresaId.ToString()),
                    new Claim("clienteId", clienteId)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}