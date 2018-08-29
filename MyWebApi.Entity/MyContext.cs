using Microsoft.EntityFrameworkCore;
using System;

namespace MyWebApi.Entity
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Student> Students { get; set; }       
    }
}
