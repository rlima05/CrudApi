using AutoMapper;
using CrudApi.Application.Interface;
using CrudApi.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CrudApi.Models;

namespace CrudApi.Controllers
{
    [Route("api/person")]
    public class PersonController : Controller
    {
        private readonly IPersonAppService _personAppService;

        public PersonController(IPersonAppService personAppService)
        {
            _personAppService = personAppService;
        }

        [HttpGet()]
        public IActionResult GetPeople()
        {
            var people = _personAppService.GetAll();

            var results = Mapper.Map<IEnumerable<Models.Person>>(people);

            return Ok(results);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var person = _personAppService.GetById(id);

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

            _personAppService.Add(personEntity);

            return Ok();
        }

        [HttpPut()]
        public IActionResult UpdatePerson([FromBody] Models.Person person)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var personEntity = Mapper.Map<Domain.Entities.Person>(person);

            _personAppService.Update(personEntity);

            return Ok();
        }


        [HttpDelete()]
        public IActionResult DeletePerson([FromBody] Models.Person person)
        {
            var personEntity = Mapper.Map<Domain.Entities.Person>(person);

            _personAppService.Remove(personEntity);

            return Ok();
        }
    }
}
