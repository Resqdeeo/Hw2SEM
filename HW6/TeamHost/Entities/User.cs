using TeamHost.Common;

namespace TeamHost.Entities;

/// <summary>
///     Сущнсоть пользователя
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