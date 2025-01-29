using Animals_Web.Animals;
using Animals_Web.Animals.Dtos;

namespace Animals_Web.Animals.Repository
{
    public interface IAnimalRepo
    {
        Task<List<Animal>> GetAllAsync();

        Task<CreateAnimalResponse> CreateAnimal(CreateAnimalRequest createAnimalRequest);



    }
}
