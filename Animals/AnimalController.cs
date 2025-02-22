using Animals_Web.Animals;
using Animals_Web.Animals.Dtos;
using Animals_Web.Animals.Exceptions;
using Animals_Web.Animals.Repository;
using Animals_Web.Animals.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.AccessControl;

namespace Animals_Web.Animals
{
    [ApiController]
    [Route("api/v1/[Controller]")]

    public class AnimalController : ControllerBase
    {
        private ICommandAnimalService _command;
        private IQueryAnimalService _query;


        public AnimalController(ICommandAnimalService command,IQueryAnimalService query)
        {
            this._command = command;
            this._query = query;


        }

        [HttpGet("all")]

        public async Task<ActionResult<IEnumerable<Animal>>> GetAllAsync()
        {
            var animals = await _query.GetAllAsync();

            return Ok(animals);


        }

        [HttpPost("create")]
        public async Task<ActionResult<AnimalResponse>> CreateAnimal([FromBody]AnimalRequest createAnimalRequest)
        {
            try
            {
                AnimalResponse create = await _command.CreateAsync(createAnimalRequest);

                return Created("", create);

            }catch(AnimalALreadyExistExceptions ex)
            {
                return BadRequest(ex.Message);
            }
            
         }
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<AnimalResponse>> DeleteAnimal([FromRoute] int id)
        {
            try
            {
                AnimalResponse response = await _command.DeleteAsync(id);



                return Accepted("", response);
            }catch(AnimalNotFoundException nf)
            {
                return NotFound(nf.Message);
            }


        }

        [HttpPut("edit/{id}")]
        public async Task<ActionResult<AnimalResponse>> EditAnimal([FromRoute] int id, [FromBody] AnimalUpdateRequest animal)
        {
            try
            {
                AnimalResponse response = await _command.UpdateAsync(id, animal);

                return Accepted("", response);
            }catch(AnimalNotUpdateException up)
            {
                return NotFound(up.Message);
            }catch(AnimalNotFoundException nf)
            {

                return NotFound(nf.Message);

            }
        }


        [HttpGet("GetAllAnimalsNames")]


        public async Task<ActionResult<GetAllAnimalNamesDto>> GetAllAnimalNames()
        {

            try
            {
                GetAllAnimalNamesDto response = await this._query.GetAllAnimalNames();
                 return   Accepted("", response);

            }catch(AnimalNotFoundException nf)
            {
                return NotFound(nf.Message);
            }



        }


        [HttpGet("find/Name/{name}")]

        public async Task<ActionResult<AnimalResponse>> GetAnimalByName([FromRoute] string name)
        {


            try
            {

                AnimalResponse response = await this._query.FindByName(name);

                return Accepted("", response);


            }catch(AnimalNotFoundException nf)
            {
                return NotFound(nf.Message);

            }

          






        }

        [HttpGet("find/Id/{id}")]

        public async Task<ActionResult<AnimalResponse>> GetById([FromRoute] int id)
        {
            try
            {
                AnimalResponse response = await this._query.FindById(id);

                return Accepted("", response);
            }catch(AnimalNotFoundException nf)
            {
                return NotFound(nf.Message);


            }







        }











    }


















}
