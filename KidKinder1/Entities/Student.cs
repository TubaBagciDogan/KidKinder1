using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KidKinder1.Entities
{
    public class Student
    {
        public int StudentId { get; set; }

        public string NameSurname { get; set; }
        public string Age { get; set; }
       
        public int ClassroomId { get; set; }
        public virtual Classroom Classroom { get; set; }
        public List<Parent> Parents { get; set; }




    }
}