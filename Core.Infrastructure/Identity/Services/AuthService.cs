using Core.Application.Common.Models.Identity;
using Core.Application.Common.Exceptions;
using Core.Application.Common.Identity;
using Core.Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Core.Domain;
using Core.Application.Common.Interfaces;
using Core.Domain.Enums;

namespace Core.Infrastructure.Identity.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly JwtSettings _jwtSettings;
    private readonly IUserRepository _userRepository;
    private readonly ITeamUserRepository _teamUserRepository;
    public AuthService(UserManager<ApplicationUser> userManager,
                      SignInManager<ApplicationUser> signInManager,
                      IOptions<JwtSettings> jwtSettings,
                      IUserRepository userRepository,
                      ITeamUserRepository teamUserRepository)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _jwtSettings = jwtSettings.Value;
        _userRepository = userRepository;
        _teamUserRepository = teamUserRepository;
    }

    public async Task<AuthResponse> Login(AuthRequest request)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user == null)
        {
            throw new NotFoundException($"User with {request.Email} not found.", request.Email);
        }

        var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
        if (!result.Succeeded)
        {
            throw new BadRequestException($"Credentials for '{request.Email} aren't valid'.");
        }

        JwtSecurityToken jwtSecurityToken = await GenerateToken(user);

        var response = new AuthResponse
        {
            Id = user.Id,
            Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
            Email = user.Email,
            UserName = user.UserName
        };

        return response;
    }

    public async Task<RegistrationResponse> RegisterEmployee(RegistrationRequest request)
    {
        if (request.UserRole != UserRoleEnum.Employee || request.UserRole != UserRoleEnum.HR)
        {
            throw new BadRequestException($"Invalid Role: `{request.UserRole}` for User: {request.UserName}");
        }

        var user = new ApplicationUser
        {
            Email = request.Email,
            UserName = request.UserName,
            EmailConfirmed = true,
        };

        var result = await _userManager.CreateAsync(user, request.Password);

        var coreUser = new User
        {
            Uid = new Guid(user.Id),
            FirstName = request.FirstName,
            LastName = request.LastName,
            CompanyEmail = request.Email,
            CompanyId = request.CompanyId,
            DateOfBirth = request.DateOfBirth,
            DateOfEmployment = request.DateOfEmployment,
            StackPosition = request.StackPosition,
            Seniority = request.Seniority,
            IsTeamLead = request.IsTeamLead,
            TeamLeadUid = request.TeamLeadUid,
            DedicatedHR = request.DedicatedHRUid,
            ReligiousHolidayDay = request.ReligiousHolidayDay,
            PhoneNumber = request.PhoneNumber
        };

        var teamUser = new TeamUser
        {
            Uid = Guid.NewGuid(),
            UserUid = new Guid(user.Id),
            TeamUid = request.TeamUid,
        };


        if (result.Succeeded)
        {
            await _userManager.AddToRoleAsync(user, request.UserRole.ToString());

            await _userRepository.CreateAsync(coreUser);
            await _teamUserRepository.CreateAsync(teamUser);

            return new RegistrationResponse() { UserId = user.Id };
        }
        else
        {
            StringBuilder str = new StringBuilder();
            foreach (var err in result.Errors)
            {
                str.AppendFormat("•{0}\n", err.Description);
            }

            throw new BadRequestException($"{str}");
        }
    }

    private async Task<JwtSecurityToken> GenerateToken(ApplicationUser user)
    {
        var userClaims = await _userManager.GetClaimsAsync(user);
        var roles = await _userManager.GetRolesAsync(user);

        var roleeClaims = roles.Select(x => new Claim(ClaimTypes.Role, x)).ToList();

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim("uid", user.Id)
        }
        .Union(userClaims)
        .Union(roleeClaims);

        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));

        var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

        var jwtSecurityToken = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
            signingCredentials: signingCredentials
            );

        return jwtSecurityToken;
    }

}
