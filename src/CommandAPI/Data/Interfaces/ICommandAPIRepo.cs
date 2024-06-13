using System.Collections.Generic;
using CommandAPI.Models;

namespace CommandAPI.Data.Interfaces;

public interface ICommandAPIRepo
{

    bool SaveChanges();

    IEnumerable<Command> GetAllCommands();
    Command GetCommandById(int id);
    void CreateCommand(Command cmd);
    void DeleteCommand(Command cmd);
    void UpdateCommand(Command cmd);
}
