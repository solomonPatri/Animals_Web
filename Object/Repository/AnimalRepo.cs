using Animals_Web.Data;
using Animals_Web.Object.Repository;
using Microsoft.EntityFrameworkCore;

namespace Animals_Web.Object.Repository
{
    public class AnimalRepo : IAnimalRepo
    {
        private readonly AppDbContext _appDbContext;


        public AnimalRepo(AppDbContext context)
        {
            this._appDbContext = context;


        }

        public async Task<List<Animal>> GetAllAsync()
        {

                return await _appDbContext.Animals.ToListAsync();


        }

            public async Task<List<Animal>> GetAnimalsUnderAge20()
            {
                return await _appDbContext.Animals.Where(u => u.Age < 20)
                    .ToListAsync();



            }

            public async Task<List<Animal>> GetUsernameNameStartB()
            {
                return await _appDbContext.Animals.Where(u => u.Name.Contains("B%"))
                    .ToListAsync();


            }

            public async Task<List<Animal>> GetIdNrPar()
            {

                return await _appDbContext.Animals.Where(u => u.Id % 2 == 0)
                   .ToListAsync();
            }


  } }
