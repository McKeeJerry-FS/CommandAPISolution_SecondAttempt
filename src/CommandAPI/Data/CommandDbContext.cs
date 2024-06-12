using Microsoft.EntityFrameworkCore;
using CommandAPI.Models;

namespace CommandAPI.Data;

public class CommandDbContext : DbContext
{
    public CommandDbContext(DbContextOptions options) : base(options){

    }
    public DbSet<Command> CommandItems { get; set; }
}
