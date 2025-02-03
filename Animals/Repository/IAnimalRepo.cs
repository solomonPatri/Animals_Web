using Animals_Web.Animals;
using Animals_Web.Animals.Dtos;

namespace Animals_Web.Animals.Repository
{
    public interface IAnimalRepo
    {
        Task<List<Animal>> GetAllAsync();

        Task<AnimalResponse> CreateAsync(AnimalRequest createAnimalRequest);

        Task<AnimalResponse> DeleteAsync(int id);


        Task<AnimalResponse> UpdateAsync(int id,AnimalUpdateRequest createAnimalRequest);

    }
}
