
namespace BoardgameApi.Model;

public class Match
{
    public Guid Id { get; set; }
    public required string BoardgameName { get; set; }
    public required IEnumerable<Player> Players { get; set; }
}
