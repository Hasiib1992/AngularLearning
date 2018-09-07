using System.Collections.Generic;
using eLearning.Domain;

namespace DataAcess
{
    public interface IEFRepository
    {
        void Add(object entity);
        void Delete(object entity);
        IEnumerable<Course> GetCourses(bool detail=false);
        Course GetCourse(int id, bool detail=false);
        Subject GetSubject(int id, bool detail=false);
        IEnumerable<Subject> GetSubjects(bool detail=false);
        bool SaveChanges();
        void Update(object entity);
    }
}