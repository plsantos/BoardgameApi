using BoardgameApi.Model;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using MongoDB.EntityFrameworkCore.Extensions;

namespace BoardgameApi.Repository;


public class BoardgameDbContext : DbContext, IBoardgameRepository
{
    public DbSet<Match> Matches { get; set; }

    public BoardgameDbContext(DbContextOptions<BoardgameDbContext> options) : base(options)
    { }

    public static BoardgameDbContext Create(IMongoDatabase database) =>
        new(new DbContextOptionsBuilder<BoardgameDbContext>()
            .UseMongoDB(database.Client, database.DatabaseNamespace.DatabaseName)
            .Options);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Match>().ToCollection("matches");
    }

    public Match? GetMatch(Guid id)
    {
        return Matches.FirstOrDefault(x => x.Id == id);
    }

    public IEnumerable<Match> GetAllMatchesFrom(string playerName)
    {
        return Matches.Where(x => x.Players.Any(x => x.Name == playerName)).ToList();
    }

    public Guid Create(Match match)
    {
        match.Id = Guid.NewGuid();
        Matches.Add(match);
        SaveChanges();

        return match.Id;
    }

    public bool DeleteMatch(Guid id)
    {
        var matchForDeletion = Matches.FirstOrDefault(x => x.Id == id);

        // Não existe
        if (matchForDeletion == null)
            return false;

        Matches.Remove(matchForDeletion);
        SaveChanges();
        return true;
    }

    public bool UpdateMatch(Guid id, Match match)
    {
        var originalMatch = Matches.FirstOrDefault(x => x.Id == id);

        // Não existe
        if (originalMatch == null)
            return false;

        originalMatch.BoardgameName = match.BoardgameName;
        originalMatch.Players = match.Players;

        Matches.Update(originalMatch);
        SaveChanges();
        return true;
    }
}
