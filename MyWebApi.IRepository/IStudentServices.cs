using MyWebApi.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyWebApi.IRepository
{
    public interface IStudentServices : IRepository<Student>
    {
        Student GetByName(string name);
    }
}
