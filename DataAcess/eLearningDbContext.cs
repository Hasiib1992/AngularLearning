using eLearning.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAcess
{
    public class eLearningDbContext : DbContext
    {
        private IConfigurationRoot _config;

        public eLearningDbContext(DbContextOptions<eLearningDbContext> options, IConfigurationRoot config) : base(options)
        {
            _config = config;
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config["ConnectionStrings:eLearningDbConnectionString"]);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
