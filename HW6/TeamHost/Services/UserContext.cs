using System.Security.Claims;
using TeamHost.Interfaces;

namespace TeamHost.Services;

public class UserContext : IUserContext
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="httpContextAccessor">Http акссесор</param>
    public UserContext(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    /// <inheritdoc />
    public Guid? CurrentUserId
    {
        get
        {
            if (!User.Claims.Any()) return null;
            return Guid.TryParse(User?.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value, out var userId)
                ? userId
                : null;
        }
    }

    private ClaimsPrincipal? User => _httpContextAccessor.HttpContext?.User;
}