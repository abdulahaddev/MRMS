using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MRMS.DAL;
using MRMS.Model.Authentication;
using MRMS.Model.CommonSection;
using MRMS.Model.EmployeeSection;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MRMS_Final_Project.Services
{
    public class AuthenticateService : IAuthenticateService
    {
       
        private readonly AppSettings _appSettings;

 
        public AuthenticateService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
         
        }
        private readonly List<User> users = new List<User>()
        {
            new User
            {
                UserId= 1,
                FirstName= "MRMS",
                LastName="Project",
                UserName="admin",
                Password="admin"
            }
        };

      


        public User Authenticate(string username, string password)
        {
            var user = users.SingleOrDefault(x => x.UserName == username && x.Password == password);
            //if User not found
            if (user == null)
            {
                return null;
            }
            //If User is found
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name,user.UserId.ToString()),
                    new Claim(ClaimTypes.Role,"Admin"),
                    new Claim(ClaimTypes.Version,"v3.1")
                }),
                Expires = DateTime.UtcNow.AddDays(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);
            user.Password = "";
            return user;
        }


    }
}
