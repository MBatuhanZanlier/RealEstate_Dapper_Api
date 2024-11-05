using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RealEstate_Dapper_Api.Tools
{
    public class JwtTokenGenerator
    { 
        public static TokenResposeViewModel GenerateToken(GetCheckAppUserViewModel model)
        {
            var claims=new List<Claim>(); 
            if(!string.IsNullOrWhiteSpace(model.Role))
            {
                claims.Add(new Claim(ClaimTypes.Role, model.Role)); 

                claims.Add(new Claim(ClaimTypes.NameIdentifier,model.ıd.ToString())); 

                if(!string.IsNullOrWhiteSpace(model.Usurname)) 
                    claims.Add(new Claim("Usurname",model.Usurname)); 

                var key=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwTokenDefaults.Key)); 
                var signinCredentials=new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
                var expireDate = DateTime.UtcNow.AddDays(JwTokenDefaults.Expire);   
                JwtSecurityToken token=new JwtSecurityToken(issuer:JwTokenDefaults.ValidAudience,claims:claims,notBefore:DateTime.UtcNow,expires:expireDate,signingCredentials:signinCredentials);
                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                return new TokenResposeViewModel(tokenHandler.WriteToken(token), expireDate);

            }
            return null;
        }
    }
}
