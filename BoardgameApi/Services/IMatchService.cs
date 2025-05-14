
using BoardgameApi.Model;

namespace BoardgameApi.Services;

public interface IMatchService
{
    Match? GetMatch(Guid id);
    IEnumerable<Match> GetMatches(string playerName);
    Guid Create(Match match);
    bool DeleteMatch(Guid id);
    bool UpdateMatch(Guid id, Match match);
}
