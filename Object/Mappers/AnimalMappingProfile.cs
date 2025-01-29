using AutoMapper;
using Animals_Web.Object.Dtos;
using Animals_Web.Object;

namespace Animals_Web.Object.Mappers
{
    public class AnimalMappingProfile: Profile
    {

        public AnimalMappingProfile()
        {
            CreateMap<CreateAnimalRequest, Animal>();
            CreateMap<Animal, CreateAnimalResponse>();

        }




    }
}
