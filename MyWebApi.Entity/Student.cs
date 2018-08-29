using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyWebApi.Entity
{
    public class Student
    {

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }
    }
}
