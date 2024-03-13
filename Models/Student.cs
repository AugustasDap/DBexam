using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBexam.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public ICollection<Lecture> Lectures { get; set; } = new List<Lecture>();
    }

}
