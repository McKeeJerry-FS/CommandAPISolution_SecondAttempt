using System.Collections.Generic;
using CommandAPI.Data.Interfaces;
using CommandAPI.Dtos;
using CommandAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using AutoMapper;

namespace CommandAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CommandsController : ControllerBase
{
    private readonly ICommandAPIRepo _repo;
    private readonly IMapper _mapper;

    public CommandsController(ICommandAPIRepo repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    // [HttpGet]
    // public ActionResult<IEnumerable<string>> Get(){
    //     return new string[] { "this", "is", "hard", "coded",};
    // }

    [HttpGet]
    public ActionResult<IEnumerable<CommandReadDto>> GetAllCommands(){

        var commandItems = _repo.GetAllCommands();
        return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandItems));
    }

    [HttpGet("{id}")]
    public ActionResult<IEnumerable<CommandReadDto>> GetCommandById(int id){
        var commandItem = _repo.GetCommandById(id);
        if (commandItem is null){
            return NotFound();
        }
        return Ok(_mapper.Map<CommandReadDto>(commandItem));
    }

}
