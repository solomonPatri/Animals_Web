using Animals_Web.Animals.Dtos;

namespace Animals_Web.Animals.Services
{
    public interface ICommandAnimalService
    {


        Task<AnimalResponse> CreateAsync(AnimalRequest createAnimalRequest);

        Task<AnimalResponse> DeleteAsync(int id);


        Task<AnimalResponse> UpdateAsync(int id, AnimalUpdateRequest createAnimalRequest);










    }
}
