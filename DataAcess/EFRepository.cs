using eLearning.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAcess
{
    public class EFRepository : IEFRepository
    {
        private eLearningDbContext _context;

        public EFRepository(eLearningDbContext context)
        {
            _context = context;
        }

        #region Generic Methods

        public void Add(object entity)
        {
            _context.Add(entity);

        }
        public void Update(object entity)
        {
            _context.Update(entity);

        }
        public void Delete(object entity)
        {
            _context.Remove(entity);

        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }

        #endregion

        #region Subjects

        public IEnumerable<Subject> GetSubjects(bool detail)
        {
            if (detail)
            {
                return _context.Subjects.Include(p => p.Courses);
            }
            else
            {

                return _context.Subjects;
            }
        }
        #endregion

        public Subject GetSubject(int id, bool detail)
        {
            if (detail)
            {
                return _context.Subjects.Include(p => p.Courses).FirstOrDefault(p => p.SubjectId == id);
            }
            else
            {
                return _context.Subjects.FirstOrDefault(p => p.SubjectId == id);
            }
        }


        #region Courses

        public IEnumerable<Course> GetCourses(bool detail)
        {

            if (detail)
            {
                return _context.Courses.Include(p => p.Subject);
            }
            else
            {
                return _context.Courses;
            }
        }

        public Course GetCourse(int id, bool detail)
        {

            if (detail)
            {
                return _context.Courses.Include(p => p.Subject).FirstOrDefault(p => p.CourseId == id);
            }
            else
            {
                return _context.Courses.FirstOrDefault(p => p.CourseId == id);
            }
        }
        #endregion

    }
}

