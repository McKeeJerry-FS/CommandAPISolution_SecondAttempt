﻿using System.Collections.Generic;
using CommandAPI.Models;
using CommandAPI.Data.Interfaces;

namespace CommandAPI;

public class MockCommandAPIRepo : ICommandAPIRepo
{
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
        var commands = new List<Command>() {
            new Command() {
                Id = 0,
                HowTo = "How to generate a migration",
                CommandLine = "dotnet ef migrations add <name of migration>",
                Platform = ".NET Core EF"
            },
            new Command() {
                Id = 1,
                HowTo = "Run Migrations",
                CommandLine = "dotnet ef database update",
                Platform = ".NET Core EF"
            },
            new Command() {
                Id = 2,
                HowTo = "List of active migrations",
                CommandLine = "dotnet ef migrations list",
                Platform = ".NET Core EF"
            }
        };
        return commands;
    }

    public Command GetCommandById(int id)
    {
        return new Command() {
            Id = 0,
            HowTo = "How to generate a migration",
            CommandLine = "dotnet ef migrations list",
            Platform = ".NET Core EF"
        };
    }

    public bool SaveChanges()
    {
        throw new NotImplementedException();
    }

    public void UpdateCommand(Command cmd)
    {
        throw new NotImplementedException();
    }
}
