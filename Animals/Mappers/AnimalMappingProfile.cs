using AutoMapper;
using Animals_Web.Animals.Dtos;
using Animals_Web.Animals;

namespace Animals_Web.Animals.Mappers
{
    public class AnimalMappingProfile: Profile
    {

        public AnimalMappingProfile()
        {
            CreateMap<AnimalRequest, Animal>();
            CreateMap<Animal, AnimalResponse>();
            CreateMap<AnimalResponse, AnimalUpdateRequest>();
        }




    }
}
