using EvaluatorServer.Models;
using Microsoft.EntityFrameworkCore;

namespace EvaluatorServer.Models;

public class GameRecordContext : DbContext
{
    public GameRecordContext(DbContextOptions<GameRecordContext> options)
        : base(options)
    {
    }

    public DbSet<GameRecord> GameRecords { get; set; } = null!;
}