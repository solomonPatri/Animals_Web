using AutoMapper;
using Animals_Web.Animals.Dtos;
using Animals_Web.Animals;

namespace Animals_Web.Animals.Mappers
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
