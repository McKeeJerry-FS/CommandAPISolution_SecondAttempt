using AutoMapper;
using CommandAPI.Dtos;
using CommandAPI.Models;

namespace CommandAPI;

public class CommandsProfile : Profile
{
    public CommandsProfile(){
        CreateMap<Command, CommandReadDto>();
    }
}
