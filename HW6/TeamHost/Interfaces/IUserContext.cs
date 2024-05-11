namespace TeamHost.Interfaces;

public interface IUserContext
{
    Guid? CurrentUserId { get; }
}