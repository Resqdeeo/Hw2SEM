using TeamHost.Domain.Common;

namespace TeamHost.Domain.Entities;

/// <summary>
///     Сущность пользователя
/// </summary>
public class User : BaseAuditableEntity
{
    /// <summary>
    ///     Юзернейм
    /// </summary>
    public string UserName { get; set; }

    /// <summary>
    ///     Почта пользователя
    /// </summary>
    /// 
    public string Email { get; set; }

    /// <summary>
    ///     Инфа пользователя
    /// </summary>
    public UserInfo UserInfo { get; set; }
}