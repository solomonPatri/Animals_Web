using Animals_Web.Animals.Dtos;

namespace Animals_Web.Animals.Services
{
    public interface IQueryAnimalService
    {
        Task<GetAllAnimalDto> GetAllAsync();


        Task<GetAllAnimalDto> FindByNameAsync(string Name);

        Task<AnimalResponse> FindByIdAsync(int id);

        Task<GetAllAnimalNamesDto> GetAllAnimalNamesAsync();

       






    }
}
