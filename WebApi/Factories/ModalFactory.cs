using eLearning.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Factories
{
    public class ModalFactory
    {
        public static CourseModel Create(Course entity)
        {
            return new CourseModel
            {
                CourseId = entity.CourseId,
                Created = entity.Created,
                Description = entity.Description,
                Duration = entity.Duration,
                Price = entity.Price,
                Subject = Create(entity.Subject),
                Title = entity.Title

            };
        }


        public static SubjectModel Create(Subject entity)
        {
            return new SubjectModel
            {
                SubjectId = entity.SubjectId,
                Code = entity.Code,
                Name = entity.Name,
                Description = entity.Description

            };
        }
    }
}
