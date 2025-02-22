using Animals_Web.Animals.Dtos;
using Animals_Web.Animals.Exceptions;
using Animals_Web.Animals.Repository;

namespace Animals_Web.Animals.Services
{
    public class QueryAnimalService : IQueryAnimalService
    {
        private readonly IAnimalRepo _repo;

        public QueryAnimalService(IAnimalRepo repo)
        {

            this._repo = repo;


        }

        public async Task<GetAllAnimalDto> GetAllAsync()
        {
            GetAllAnimalDto response = await this._repo.GetAllAsync();
            if(response != null)
            {
                return response;
            }
            throw new AnimalNotFoundException();



        }


        public async  Task<GetAllAnimalDto> FindByNameAsync(string Name)
        {
            GetAllAnimalDto response = await this._repo.FindByNameAsync(Name);
            if(response!= null)
            {
                return response;


            }
            throw new AnimalNotFoundException();






        }

        public  async Task<AnimalResponse> FindByIdAsync(int id)
        {
            AnimalResponse response = await this._repo.FindByIdAsync(id);
            if(response!= null)
            {
                return response;


            }
            throw new AnimalNotFoundException();





        }

        public async Task<GetAllAnimalNamesDto> GetAllAnimalNamesAsync()
        {
            GetAllAnimalNamesDto response = await this._repo.GetAllAnimalNamesAsync();

            if(response != null)
            {

                return response;
            }

            throw new AnimalNotFoundException();







        }















    }
}
