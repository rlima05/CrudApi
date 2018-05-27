using AutoMapper;
using CrudApi.Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CrudApi.Controllers
{

    [Route("api/personredis")]
    public class PersonRedisController : Controller
    {
        //TODO: CRIAR POSTMAN, ACERTAR PARA SERIALIZAR NO GETBYID, POSSIVELMENTE TODOS PRECISEM SERIALIZAR

        private readonly IPersonAppServiceRedis _personAppServiceRedis;
        private readonly IPersonAppService _personAppService;

        public PersonRedisController(IPersonAppServiceRedis personAppServiceRedis, IPersonAppService personAppService)
        {
            _personAppServiceRedis = personAppServiceRedis;
            _personAppService = personAppService;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var person = _personAppServiceRedis.GetByKey(id);

            var personMapped = Mapper.Map<Models.Person>(person);

            return Ok(person);
        }

        [HttpPost()]
        public IActionResult CreatePerson([FromBody] Models.Person person)
        {


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var personEntity = Mapper.Map<Domain.Entities.Person>(person);

            var id = _personAppService.Add(personEntity);
            personEntity.PersonId = id;
            _personAppServiceRedis.Add(personEntity);

            return Ok();
        }


        [HttpPut()]
        public IActionResult UpdatePerson([FromBody] Models.Person person)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var personEntity = Mapper.Map<Domain.Entities.Person>(person);

            _personAppService.Update(personEntity);
            _personAppServiceRedis.Update(personEntity);

            return Ok();
        }

        [HttpDelete()]
        public IActionResult DeletePerson([FromBody] Models.Person person)
        {
            var personEntity = Mapper.Map<Domain.Entities.Person>(person);

            _personAppService.Remove(personEntity);
            _personAppServiceRedis.Remove(personEntity.PersonId);
            return Ok();
        }

    }
}