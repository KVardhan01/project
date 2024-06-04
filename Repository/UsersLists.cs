using AuhntctionCRUD.Appmodels;
using AuhntctionCRUD.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuhntctionCRUD.Repository
{
    public class UsersLists
    {
        public readonly IConfiguration _configuration;
        public UsersLists(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public static Credential UserLogin(UserModel userModel)
        {
            using(CrudContext crudContext=new CrudContext()) 
            {
                var record = crudContext.Credentials.Where(x => x.Email == userModel.Email&&x.Password==userModel.Password).FirstOrDefault();
                if (record != null)
                {
                    return record;
                }
                return null;
            }
        }
        public  string GenerateToken(Credential credential)
        {
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["jwt:Key"]));
            var credentials=new SigningCredentials(securitykey,SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Role,credential.Role),
            };
            var token = new JwtSecurityToken(_configuration["jwt:Issuer"], _configuration["jwt:Audiance"], claims, expires: DateTime.Now.AddHours(2),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
