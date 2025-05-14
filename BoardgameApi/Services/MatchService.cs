using BoardgameApi.Model;
using BoardgameApi.Repository;

namespace BoardgameApi.Services;

public class MatchService : IMatchService
{
    private readonly IBoardgameRepository _boardgameRepository;
    public MatchService(IBoardgameRepository boardgameRepository)
    {
        _boardgameRepository = boardgameRepository;
    }

    public Match? GetMatch(Guid id)
    {
        return _boardgameRepository.GetMatch(id);
    }

    public Guid Create(Match match)
    {
        return _boardgameRepository.Create(match);
    }

    public IEnumerable<Match> GetMatches(string playerName)
    {
        // Retornar partidas que o jogador participou
        return _boardgameRepository.GetAllMatchesFrom(playerName);
    }

    public bool DeleteMatch(Guid id)
    {
        return _boardgameRepository.DeleteMatch(id);
    }

    public bool UpdateMatch(Guid id ,Match match)
    {
        return _boardgameRepository.UpdateMatch(id, match);
    }
}
