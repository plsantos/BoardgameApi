using BoardgameApi.Model;

namespace BoardgameApi.Repository;

public interface IBoardgameRepository
{
    Guid Create(Match match);
    Match? GetMatch(Guid id);
    IEnumerable<Match> GetAllMatchesFrom(string playerName);
    bool DeleteMatch(Guid id);
    bool UpdateMatch(Guid id, Match match);
}
