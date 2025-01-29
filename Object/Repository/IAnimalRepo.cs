using Animals_Web.Object;
using Animals_Web.Object.Dtos;

namespace Animals_Web.Object.Repository
{
    public interface IAnimalRepo
    {
        Task<List<Animal>> GetAllAsync();

        Task<CreateAnimalResponse> CreateAnimal(CreateAnimalRequest createAnimalRequest);



    }
}
