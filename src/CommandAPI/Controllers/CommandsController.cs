using System.Collections.Generic;
using CommandAPI.Data.Interfaces;
using CommandAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace CommandAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CommandsController : ControllerBase
{
    private readonly ICommandAPIRepo _repo;

    public CommandsController(ICommandAPIRepo repo)
    {
        _repo = repo;
    }

    // [HttpGet]
    // public ActionResult<IEnumerable<string>> Get(){
    //     return new string[] { "this", "is", "hard", "coded",};
    // }

    [HttpGet]
    public ActionResult<IEnumerable<Command>> Get(){

        var commandItems = _repo.GetAllCommands();
        return Ok(commandItems);
    }

    [HttpGet("{id}")]
    public ActionResult<IEnumerable<Command>> GetCommandById(int id){
        var commandItem = _repo.GetCommandById(id);
        if (commandItem is null){
            return NotFound();
        }
        return Ok(commandItem);
    }

}
