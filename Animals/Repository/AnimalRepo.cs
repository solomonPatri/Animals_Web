using Animals_Web.Data;
using Animals_Web.Animals.Dtos;
using Animals_Web.Animals.Repository;
using AutoMapper;
using Microsoft.EntityFrameworkCore;


namespace Animals_Web.Animals.Repository
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



        public async Task<AnimalResponse> CreateAsync(AnimalRequest createAnimalRequest)
        {

            Animal animals = _mapper.Map<Animal>(createAnimalRequest);

            _appDbContext.Animals.Add(animals);

            await _appDbContext.SaveChangesAsync();

            AnimalResponse response = _mapper.Map<AnimalResponse>(animals);

            return response;






        }

        public async Task<AnimalResponse> DeleteAsync(int id)
        {

            Animal animal = await _appDbContext.Animals.FindAsync(id);


            AnimalResponse response = _mapper.Map<AnimalResponse>(animal);

            _appDbContext.Remove(animal);

            await _appDbContext.SaveChangesAsync();

            return response;
        }

        public async Task<AnimalResponse> UpdateAsync(int id, AnimalUpdateRequest animal)
        {
            Animal anim= await _appDbContext.Animals.FindAsync(id);

            if (animal.Name != null)
            {
                anim.Name = animal.Name;
            }

            if (animal.Age.HasValue)
            {
                anim.Age = animal.Age.Value;
            }

            if (animal.Country!=null)
            {
                anim.Country = animal.Country;
            }

            if (animal.Weight.HasValue)
            {
                anim.Weight = animal.Weight.Value;
            }


            _appDbContext.Animals.Update(anim);


            await _appDbContext.SaveChangesAsync();


            AnimalResponse update = _mapper.Map<AnimalResponse>(anim);


            return update;




        }


        public async Task<AnimalResponse> FindByName(string names)
        {

            Animal animal = await _appDbContext.Animals.FirstOrDefaultAsync(s => s.Name.Equals(names));

            AnimalResponse response = _mapper.Map<AnimalResponse>(animal);

            return response;


        }

        public async Task<AnimalResponse> FindById(int id)
        {

            Animal animal = await _appDbContext.Animals.FindAsync(id);

            AnimalResponse response = _mapper.Map<AnimalResponse>(animal);

            return response;



        }

        public async Task<GetAllAnimalNamesDto> GetAllAnimalNames()
        {
            List<string> names = await _appDbContext.Animals.Select(n => n.Name).ToListAsync();

            GetAllAnimalNamesDto response = new GetAllAnimalNamesDto();

            response.Names = names;

            return response;


        }




















    }
}
