using MediatR;
using TeamHost.DTOs.Games.GetAllGames;

namespace TeamHost.Queries.Game.GetAllGames;

/// <summary>
///     Запрос на получения всех игр
/// </summary>
public class GetAllGamesQuery : IRequest<GetAllGamesResponse>
{
}