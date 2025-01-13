using Animals_Web.Object;
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

        [HttpGet("AgeUnder20")]

        public async Task<ActionResult<IEnumerable<Animal>>> GetAnimalsUnderAge20()
        {
            var animals = await _animalRepo.GetAnimalsUnderAge20();

            return Ok(animals);




        }


        
        [HttpGet("GetUsernameNameStartB")]

        public async Task<ActionResult<IEnumerable<Animal>>> GetUsernameNameStartB()
        {
            var animals = await _animalRepo.GetUsernameNameStartB();

            return Ok(animals);


        }

        [HttpGet("GetIdNrPar")]

        public async Task<ActionResult<IEnumerable<Animal>>> GetIdNrPar()
        {

            var animals = await _animalRepo.GetIdNrPar();

            return Ok(animals);



        }



















    }













}