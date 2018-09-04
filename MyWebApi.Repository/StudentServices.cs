using MyWebApi.Entity;
using MyWebApi.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyWebApi.Repository
{
    public class StudentServices : RepositoryBase<Student>, IStudentServices
    {
        public Student GetByName(string name)
        {
            return base.Get(it => it.Name == name);
        }
    }
}
