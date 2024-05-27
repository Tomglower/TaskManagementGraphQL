namespace TaskManagement.UserService.JwtToken;

public interface IJwtTokenService
{
    string GenerateToken(string username);
}