using DataAcess;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Factories;

namespace WebApi.Controllers
{
    [Route("api/subject")]
    [ApiController]
    public class SubjectController:ControllerBase
    {
        private IEFRepository _repository;

        public SubjectController(IEFRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public ActionResult Get()
        {
            var result = _repository.GetSubjects().Select(p => ModalFactory.Create(p));
            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var result = ModalFactory.Create( _repository.GetSubjects().FirstOrDefault(p=>p.SubjectId==id));
            return Ok(result);
        }
    }
}
