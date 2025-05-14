namespace BoardgameApi.Model;

public class Player
{
    public required string Name { get; set; }
    public int Points { get; set; }
    public bool IsWinner { get; set; }
}
