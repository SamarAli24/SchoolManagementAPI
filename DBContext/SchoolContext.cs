using Microsoft.EntityFrameworkCore;
using SchoolManagement.DBContext.Dto;
using SchoolManagement.Entities;

namespace SchoolManagement.DBContext
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options) { }

        public DbSet<StudentEntity>? Student { get; set; }
        public DbSet<TeacherEntity>? Teacher { get; set; }
        public DbSet<StudentTeacherEntity>? StudentAndTeacher { get; set; }

        public DbSet<ParentEntity>? Parent { get; set; }
        public DbSet<ClassroomEntity>? Class { get; set; }
        public DbSet<SchoolEntity>? School { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder
        .UseLazyLoadingProxies().UseSqlServer("SchoolDB");


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

           // base.OnModelCreating(modelBuilder);

        }

    }
}
