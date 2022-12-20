using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MedAdvisor.Api.Controllers
{
    public class UserFromToken
    {
        public static int getId(string token)
        {
            Console.WriteLine(token);
            var stream = token;
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(stream);
            var tokenS = jsonToken as JwtSecurityToken;
            if (tokenS == null){
                throw new ApplicationException("Invalid token");
            }

            var jti = tokenS.Claims.First(claim => claim.Type == ClaimTypes.Name).Value;

            int userId = int.Parse(jti);
            Console.WriteLine(userId);
            return userId;

        }
    }
}