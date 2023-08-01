using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

class Program
{
    static void Main()
    {
        string secretKey = "92694C89053A45D6A1F9AF9250182DB5";

        // User informations
        int userId = 123;
        string userRole = "admin";
        string userName = "Baris";
        string userSurname = "Tuncel";
        string userGender = "Male";

        // Encryption operations
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

        // Claims
        var claims = new[]
        {
            new Claim("id", userId.ToString()),
            new Claim(ClaimTypes.Role, userRole),
            new Claim(ClaimTypes.Name, userName),
            new Claim(ClaimTypes.Name, userSurname),
            new Claim(ClaimTypes.Surname, userGender)
        };

        // JWT Creation
        var token = new JwtSecurityToken(
            issuer: "localhost",      
            audience: "localhost",    
            claims: claims,
            expires: DateTime.Now.AddMinutes(60),
            signingCredentials: credentials
            
        );

        // Print
        var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
        Console.WriteLine($"JWT Token: {tokenString}");
    }
}
