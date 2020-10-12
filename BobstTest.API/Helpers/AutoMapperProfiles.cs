using AutoMapper;
using BLL.Models;
using BobstTest.API.Controllers;
using BobstTest.API.Dtos;

namespace BobstTest.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Machine, MachinesToReturnDto>()
                 .ForMember(d => d.Production, o => o.MapFrom(s => s.MachineProduction.TotalProduction));
           
            CreateMap<Machine, MachineToReturnDto>().ReverseMap();

            CreateMap<MachineProduction, MachineProductionToReturnDto>();

        }
    }
}