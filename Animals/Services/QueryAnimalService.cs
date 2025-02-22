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

        public async Task<List<Animal>> GetAllAsync()
        {

            return await this._repo.GetAllAsync();


        }


        public async  Task<AnimalResponse> FindByName(string Name)
        {
            AnimalResponse response = await this._repo.FindByName(Name);
            if(response!= null)
            {
                return response;


            }
            throw new AnimalNotFoundException();






        }

        public  async Task<AnimalResponse> FindById(int id)
        {
            AnimalResponse response = await this._repo.FindById(id);
            if(response!= null)
            {
                return response;


            }
            throw new AnimalNotFoundException();





        }

        public async Task<GetAllAnimalNamesDto> GetAllAnimalNames()
        {
            GetAllAnimalNamesDto response = await this._repo.GetAllAnimalNames();

            if(response != null)
            {

                return response;
            }

            throw new AnimalNotFoundException();







        }















    }
}
