using Animals_Web.Animals;
using Animals_Web.Animals.Dtos;
using Animals_Web.Animals.Repository;
using Microsoft.AspNetCore.Mvc;


namespace Animals_Web.Animals
{
    [ApiController]
    [Route("api/v1/[Controller]")]

    public class AnimalController : ControllerBase
    {
        private IAnimalRepo _animalRepo;

        public AnimalController(IAnimalRepo animalRepo)
        {
            this._animalRepo = animalRepo;


        }

        [HttpGet("all")]

        public async Task<ActionResult<IEnumerable<Animal>>> GetAllAsync()
        {
            var animals = await _animalRepo.GetAllAsync();

            return Ok(animals);


        }

        [HttpPost("create")]
        public async Task<ActionResult<AnimalResponse>> CreateAnimal([FromBody]AnimalRequest createAnimalRequest)
        {

            AnimalResponse create = await _animalRepo.CreateAsync(createAnimalRequest);

            return Created("", create);
        }
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<AnimalResponse>> DeleteAnimal([FromRoute] int id)
        {

            AnimalResponse response = await _animalRepo.DeleteAsync(id);



            return Accepted("", response);

        }

        [HttpPut("edit/{id}")]
        public async Task<ActionResult<AnimalResponse>> EditAnimal([FromRoute] int id, [FromBody] AnimalUpdateRequest animal)
        {

            AnimalResponse response = await _animalRepo.UpdateAsync(id, animal);



            return Accepted("", response);

        }




















    }


















}
