using Animals_Web.Data;
using Animals_Web.Object.Dtos;
using Animals_Web.Object.Repository;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Animals_Web.Object.Repository
{
    public class AnimalRepo : IAnimalRepo
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public AnimalRepo(AppDbContext context,IMapper mapper)
        {
            this._appDbContext = context;
            this._mapper = mapper;

        }

        public async Task<List<Animal>> GetAllAsync()
        {

            return await _appDbContext.Animals.ToListAsync();


        }



        public async Task<CreateAnimalResponse> CreateAnimal(CreateAnimalRequest createAnimalRequest)
        {

            Animal animals = _mapper.Map<Animal>(createAnimalRequest);

            _appDbContext.Animals.Add(animals);

            await _appDbContext.SaveChangesAsync();

            CreateAnimalResponse response = _mapper.Map<CreateAnimalResponse>(animals);

            return response;






        }






    }
}
