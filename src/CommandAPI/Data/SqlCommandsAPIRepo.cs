using System.Collections.Generic;
using System.Linq;
using CommandAPI.Data.Interfaces;
using CommandAPI.Models;

namespace CommandAPI.Data;

public class SqlCommandsAPIRepo : ICommandAPIRepo
{
    private readonly CommandDbContext _context;

    public SqlCommandsAPIRepo(CommandDbContext context){
        _context = context;
    }


    public void CreateCommand(Command cmd)
    {
        if(cmd is null){
            throw new ArgumentNullException(nameof(cmd));
        }
        _context.CommandItems.Add(cmd);
    }

    public void DeleteCommand(Command cmd)
    {
        if(cmd is null){
            throw new ArgumentNullException(nameof(cmd));
        }
        _context.CommandItems.Remove(cmd);
    }

    public IEnumerable<Command> GetAllCommands()
    {
        return _context.CommandItems.ToList();
    }

    public Command GetCommandById(int id)
    {
        return _context.CommandItems.FirstOrDefault(c => c.Id == id)!;
    }

    public bool SaveChanges()
    {
        return (_context.SaveChanges() >= 0);
    }

    public void UpdateCommand(Command cmd)
    {
        //Nothing needs to be done here
    }
}
