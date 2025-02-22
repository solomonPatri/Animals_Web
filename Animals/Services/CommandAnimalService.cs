using Animals_Web.Animals.Dtos;
using Animals_Web.Animals.Repository;
using Animals_Web.Animals.Exceptions;
using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;
using FluentMigrator.Expressions;

namespace Animals_Web.Animals.Services
{
    public class CommandAnimalService:ICommandAnimalService
    {
        private readonly IAnimalRepo _repo;

        public CommandAnimalService(IAnimalRepo repo)
        {

            this._repo = repo;




        }


        public async Task<AnimalResponse> CreateAsync(AnimalRequest createAnimalRequest)
        {
            AnimalResponse animalexist = await this._repo.FindByNameAnimalAsync(createAnimalRequest.Name);

            if(animalexist == null)
            {
                AnimalResponse response = await this._repo.CreateAsync(createAnimalRequest);
                return response;



            }
            throw new AnimalALreadyExistExceptions();





        }

       public async  Task<AnimalResponse> DeleteAsync(int id)
        {
            AnimalResponse animalexist = await this._repo.FindByIdAsync(id);

            if(animalexist!= null)
            {

                AnimalResponse response = await this._repo.DeleteAsync(id);

                return response;

            }
            throw new AnimalNotFoundException();


        }


        public async Task<AnimalResponse> UpdateAsync(int id, AnimalUpdateRequest createAnimalRequest)
        {

            AnimalResponse update = await this._repo.FindByIdAsync(id);

            if (update != null)
            {
                if(update is AnimalRequest)
                {
                    update.Name = createAnimalRequest.Name ?? update.Name;
                    update.Weight = createAnimalRequest.Weight ?? update.Weight;
                    update.Age = createAnimalRequest.Age ?? update.Age;
                    update.Country = createAnimalRequest.Country ?? update.Country;


                    AnimalResponse response = await this._repo.UpdateAsync(id, createAnimalRequest);

                    return response;


                }throw new AnimalNotUpdateException();
            }
            throw new AnimalNotFoundException();



        }






    }
}
