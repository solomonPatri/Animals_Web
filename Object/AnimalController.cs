using Animals_Web.Object;
using Animals_Web.Object.Dtos;
using Animals_Web.Object.Repository;
using Microsoft.AspNetCore.Mvc;


namespace Animals_Web.Object
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
