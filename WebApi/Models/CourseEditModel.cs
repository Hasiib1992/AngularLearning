using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class CourseEditModel
    {
        public int CourseId { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public decimal Price { get; set; }

        public int Duration { get; set; }

      
        public int SubjectId { get; set; }
    }
}
