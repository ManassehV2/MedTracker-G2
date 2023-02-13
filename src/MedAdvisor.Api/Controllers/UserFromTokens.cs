using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MedAdvisor.Api.Controllers
{
    public class UserFromToken
    {
        public static int getId(string token)
        {
            // 
            var streamList = token.Split(" ").ToList();
            string stream;
         
            if (streamList.Count == 0){
                throw new System.Exception("token is empty");
            }
            else if (streamList.Count == 1) {
                stream = streamList[0];
            }
            else{
                stream = streamList[streamList.Count - 1];
            }
        
            
            
        }
    }
}