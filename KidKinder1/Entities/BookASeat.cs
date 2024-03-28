using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KidKinder1.Entities
{
    public class BookASeat
    {
        public int BookASeatId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int ClassroomId { get; set; }
        public virtual Classroom Classroom { get; set; }
    }
}