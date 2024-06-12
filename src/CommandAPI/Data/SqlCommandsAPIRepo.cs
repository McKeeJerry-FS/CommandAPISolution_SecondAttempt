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
        throw new NotImplementedException();
    }

    public void DeleteCommand(Command cmd)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Command> GetAllCommands()
    {
        return _context.CommandItems.ToList();
    }

    public Command GetCommandById(int id)
    {
        return _context.CommandItems.FirstOrDefault(c => c.Id == id)!;
    }

    public void UpdateCommand(Command cmd)
    {
        throw new NotImplementedException();
    }
}
