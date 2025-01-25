using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace TeamProjectManager.API.Utilities;

public class JwtHelper
{
	private readonly string _secretKey;
	private readonly string _issuer;
	private readonly string _audience;
	private readonly int _tokenExpirationMinutes;

	public JwtHelper(IConfiguration configuration)
	{
		_secretKey = configuration["Jwt:Secret"] ?? throw new ArgumentNullException(nameof(_secretKey));
		_issuer = configuration["Jwt:Issuer"] ?? "TeamProjectManager";
		_audience = configuration["Jwt:Audience"] ?? "TeamProjectManagerUsers";
		_tokenExpirationMinutes = int.TryParse(configuration["Jwt:ExpirationMinutes"], out var minutes) ? minutes : 60;
	}

	public string GenerateToken(string userId, string userName)
	{
		var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
		var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

		var claims = new[]
		{
			new Claim(JwtRegisteredClaimNames.Sub, userId),
			new Claim(JwtRegisteredClaimNames.UniqueName, userName),
			new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString())
        };

		var token = new JwtSecurityToken(
			issuer: _issuer,
			audience: _audience,
			claims: claims,
			expires: DateTime.UtcNow.AddMinutes(_tokenExpirationMinutes),
			signingCredentials: credentials
		);

		return new JwtSecurityTokenHandler().WriteToken(token);
	}
}
