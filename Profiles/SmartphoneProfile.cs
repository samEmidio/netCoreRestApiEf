using AutoMapper;
using netCoreRestApiEf.Dtos;
using netCoreRestApiEf.Model;

namespace netCoreRestApiEf.Profiles
{

    public class SmartphoneProfile : Profile
    {

            public SmartphoneProfile()
            {
                CreateMap<Smartphone,SmartphoneReadDto>();
                CreateMap<SmartphoneCreateDto,Smartphone>();
                CreateMap<SmartphoneUpdateDto,Smartphone>();
                CreateMap<Smartphone,SmartphoneUpdateDto>();
            }

    }


}