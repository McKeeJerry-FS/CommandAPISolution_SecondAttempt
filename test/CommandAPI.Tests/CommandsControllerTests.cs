using System;
using System.Collections.Generic;
using Moq;
using AutoMapper;
using CommandAPI.Models;
using CommandAPI.Data;
using CommandAPI.Data.Interfaces; 
using CommandAPI.Dtos;
using CommandAPI.Profiles;
using Xunit;
using CommandAPI.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace CommandAPI.Tests;

public class CommandsControllerTests
{
    Mock<ICommandAPIRepo> mockRepo;
    CommandsProfile realProfile;
    MapperConfiguration configuration;
    IMapper mapper;

    public CommandsControllerTests()
    {
        mockRepo = new Mock<ICommandAPIRepo>();
        realProfile = new CommandsProfile();
        configuration = new MapperConfiguration(cfg => cfg.AddProfile(realProfile));
        mapper = new Mapper(configuration);
    }

    public void Dispose(){
        mockRepo = null;
        mapper = null;
        configuration = null;
        realProfile = null;
    }

    // GetAllCommands Test

    [Fact]
    public void GetCommandItems_ReturnZeroItems_WhenDbIsEmpty(){
        //Arrange
        //We need to create an instance of our controller class

        mockRepo.Setup(repo => repo.GetAllCommands()).Returns(GetCommands(0));

        var controller = new CommandsController( mockRepo.Object, mapper );
        
        //Act
        var result = controller.GetAllCommands();
        //Assert
        Assert.IsType<OkObjectResult>(result.Result);
    } 

    [Fact]
    public void GetAllCommands_ReturnsOneItem_WhenDBHasOneResource(){
        // Arrange
        mockRepo.Setup(repo => repo.GetAllCommands()).Returns(GetCommands(1));
        var controller = new CommandsController(mockRepo.Object, mapper);

        // Act
        var result = controller.GetAllCommands();

        // Assert
        var okResult = result.Result as OkObjectResult;
        var commands = okResult.Value as List<CommandReadDto>;

        Assert.Single(commands); 
    }

    [Fact]
    public void GetAllCommands_Returns200OK_WhenDBHasOneResource(){
        //Arrange
        mockRepo.Setup(repo => repo.GetAllCommands()).Returns(GetCommands(1));
        var controller = new CommandsController(mockRepo.Object, mapper);
        //Act
        var result = controller.GetAllCommands();
        //Assert
        Assert.IsType<OkObjectResult>(result.Result);
    }

    [Fact]
    public void GetAllCommands_ReturnsCorrectType_WhenDBHasOneResource(){
        //Arrange
        mockRepo.Setup(repo => repo.GetAllCommands()).Returns(GetCommands(1));
        var controller = new CommandsController(mockRepo.Object, mapper);

        //Act
        var result = controller.GetAllCommands();

        //Assert
        Assert.IsType<ActionResult<IEnumerable<CommandReadDto>>>(result);
    }

    // GetCommandsById

    //Returns 404 NotFound
    [Fact]
    public void GetCommandsById_Returns404NotFound_WhenNonExistentIDProvided(){
        //Arrange
        mockRepo.Setup(repo => repo.GetCommandById(0)).Returns(() => null);
        var controller = new CommandsController(mockRepo.Object, mapper);
        //Act
        var result = controller.GetCommandById(1);
        //Assert
        Assert.IsType<NotFoundResult>(result.Result);
    }

    //Returns 200 Ok <Object>
    [Fact]
    public void GetCommandsById_Returns200Ok__WhenValidIDProvided(){
        //Arrange
        mockRepo.Setup(repo => repo.GetCommandById(1)).Returns(new Command{
            Id = 1,
            HowTo = "mock",
            Platform = "Mock",
            CommandLine = "Mock"
        });
        var controller = new CommandsController(mockRepo.Object, mapper);
        //Act
        var result = controller.GetCommandById(1);
        //Assert
        Assert.IsType<OkObjectResult>(result.Result);
    }

    // //Returns 200 Ok <ActionResult>
    // [Fact]
    // public void GetCommandsById_Returns200OK__WhenValidIDProvided(){
    //     //Arrange
    //     mockRepo.Setup(repo => repo.GetCommandById(1)).Returns(new Command {
    //         Id = 1,
    //         HowTo = "mock",
    //         Platform = "Mock",
    //         CommandLine = "Mock"
    //     });
    //     var controller = new CommandsController(mockRepo.Object, mapper);
    //     //Act
    //     var result = controller.GetCommandById(1);
    //     //Assert
    //     Assert.IsType<ActionResult<CommandReadDto>>(result);
    // }


    private List<Command> GetCommands(int num){
        var commands = new List<Command>();
        if(num > 0){
            commands.Add(new Command{
                Id = 0,
                HowTo = "How to generate a migration",
                Platform = ".NET Core EF",
                CommandLine = "dotnet ef migrations add <Name of Migration"
            });
        }
    return commands; 
    }
}
