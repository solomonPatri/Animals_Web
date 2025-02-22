using Animals_Web.Animals.Dtos;

namespace Animals_Web.Animals.Services
{
    public interface IQueryAnimalService
    {
        Task<List<Animal>> GetAllAsync();


        Task<AnimalResponse> FindByName(string Name);

        Task<AnimalResponse> FindById(int id);

        Task<GetAllAnimalNamesDto> GetAllAnimalNames();








    }
}
