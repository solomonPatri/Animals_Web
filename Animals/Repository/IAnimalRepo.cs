using Animals_Web.Animals;
using Animals_Web.Animals.Dtos;

namespace Animals_Web.Animals.Repository
{
    public interface IAnimalRepo
    {
        Task<GetAllAnimalDto> GetAllAsync();

        Task<AnimalResponse> CreateAsync(AnimalRequest createAnimalRequest);

        Task<AnimalResponse> DeleteAsync(int id);


        Task<AnimalResponse> UpdateAsync(int id,AnimalUpdateRequest createAnimalRequest);


        Task<GetAllAnimalDto> FindByNameAsync(string Name);

        Task<AnimalResponse> FindByIdAsync(int id);

        Task<GetAllAnimalNamesDto> GetAllAnimalNamesAsync();
        Task<AnimalResponse> FindByNameAnimalAsync(string Name);





    }
}
