using MediatR;
using TeamHost.DTOs.Games.GetByIdGame;

namespace TeamHost.Queries.Game.GetByIdGame;

/// <summary>
///     Запрос на получение игры
/// </summary>
public class GetByIdGameQuery : IRequest<GetByIdGameResponse>
{
    /// <summary>
    ///     Конструктор
    /// </summary>
    /// <param name="id">Ид игры</param>
    public GetByIdGameQuery(Guid id)
    {
        Id = id;
    }

    /// <summary>
    ///     Ид игры
    /// </summary>
    public Guid Id { get; set; }
}