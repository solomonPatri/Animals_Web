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

        public async Task<ActionResult<GetAllAnimalDto>> GetAllAsync()
        {
            try
            {
                GetAllAnimalDto animals = await _query.GetAllAsync();

                return Ok(animals);
            }catch(AnimalNotFoundException nf)
            {
                return NotFound(nf.Message);
            }

        }

        [HttpPost("create")]
        public async Task<ActionResult<AnimalResponse>> CreateAnimalAsync([FromBody]AnimalRequest createAnimalRequest)
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
        public async Task<ActionResult<AnimalResponse>> DeleteAnimalAsync([FromRoute] int id)
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
        public async Task<ActionResult<AnimalResponse>> EditAnimalAsync([FromRoute] int id, [FromBody] AnimalUpdateRequest animal)
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


        public async Task<ActionResult<GetAllAnimalNamesDto>> GetAllAnimalNamesAsync()
        {

            try
            {
                GetAllAnimalNamesDto response = await this._query.GetAllAnimalNamesAsync();
                 return   Accepted("", response);

            }catch(AnimalNotFoundException nf)
            {
                return NotFound(nf.Message);
            }



        }


        [HttpGet("find/Name/{name}")]

        public async Task<ActionResult<GetAllAnimalDto>> GetAnimalByNameAsync([FromRoute] string name)
        {


            try
            {

                GetAllAnimalDto response = await this._query.FindByNameAsync(name);

                return Accepted("", response);


            }catch(AnimalNotFoundException nf)
            {
                return NotFound(nf.Message);

            }

          






        }

        [HttpGet("find/Id/{id}")]

        public async Task<ActionResult<AnimalResponse>> GetByIdAsync([FromRoute] int id)
        {
            try
            {
                AnimalResponse response = await this._query.FindByIdAsync(id);

                return Accepted("", response);
            }catch(AnimalNotFoundException nf)
            {
                return NotFound(nf.Message);


            }







        }











    }


















}
