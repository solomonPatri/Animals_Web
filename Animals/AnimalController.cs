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
        public async Task<ActionResult<CreateAnimalResponse>> CreateAnimal([FromBody]CreateAnimalRequest createAnimalRequest)
        {

            CreateAnimalResponse create = await _animalRepo.CreateAnimal(createAnimalRequest);

            return Created("", create);
        }

      
    }

















}
