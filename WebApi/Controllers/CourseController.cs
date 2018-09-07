using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAcess;
using eLearning.Domain;
using Microsoft.AspNetCore.Mvc;
using WebApi.Factories;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/course")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private IEFRepository _repository;

        public CourseController(IEFRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var result = _repository.GetCourses(true).Select(p => ModalFactory.Create(p));
            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var modal = ModalFactory.Create(_repository.GetCourse(id, true));
            return Ok(modal);
        }

        [HttpPost]
        [HttpPost]
        public ActionResult Create([FromBody]CourseCreateModel model)
        {
            if (ModelState.IsValid)
            {
                Course course = new Course
                {
                    Created = DateTime.Now,
                    Description = model.Description,
                    Duration = model.Duration,
                    Price = model.Price,
                    Subject = _repository.GetSubject(model.SubjectId),
                    Title = model.Title


                };

                _repository.Add(course);
                if (_repository.SaveChanges())
                {

                    return Created($"api/course/{course.CourseId}", ModalFactory.Create(course));
                }
                else
                {
                    return BadRequest("Error while processing your request");
                }

            }
            else
            {
                return BadRequest("kindly provide valid data");
            }
        }

        [HttpPost("{id}")]
        public ActionResult Edit(int id, [FromBody]CourseEditModel model)
        {
            if (ModelState.IsValid)
            {
                var course = _repository.GetCourse(id);
                if (course == null)
                {
                    return NotFound($"Course with Course Id {id} does not exits.");
                }


                var subject = _repository.GetSubject(model.SubjectId);

                if (subject == null)
                {
                    return NotFound($"Subject with subject Id {model.SubjectId} does not exits.");
                }
                course.Description = model.Description;
                course.Duration = model.Duration;
                course.Price = model.Price;
                course.Title = model.Title;
                course.Subject = subject;

                _repository.Update(course);
                if (_repository.SaveChanges())
                {
                    return Ok("Record updated successfully.");
                }
                else
                {
                    return BadRequest("Error while processing your request.");
                }

            }
            else
            {
                return BadRequest("kindly provide valid data");
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {

            var course = _repository.GetCourse(id);
            if (course == null)
            {
                return NotFound($"Course with Course Id {id} does not exits.");

            }else
            {
                _repository.Delete(course);
                if (!_repository.SaveChanges())
                {
                    return BadRequest("Error while processing your request");
                }
                
            }
            return NoContent();

        }

    }
}