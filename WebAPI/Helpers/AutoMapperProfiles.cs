using AutoMapper;
using Service.Models;
using WebAPI.Controllers;
using WebAPI.Dtos;

namespace WebAPI.Helpers
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