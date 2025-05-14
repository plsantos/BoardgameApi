namespace BoardgameApi.Model;

public class NewMatchRequest
{
    public required string BoardgameName { get; set; }
    public required IEnumerable<Player> Players { get; set; }
}
