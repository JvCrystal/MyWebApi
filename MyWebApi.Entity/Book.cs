using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyWebApi.Entity
{
    public class Book : BaseEntity
    {

        public string Name { get; set; }

        public string Author { get; set; }
    }
}
