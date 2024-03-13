using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBexam.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public ICollection<Student> Students { get; set; } = new List<Student>();
        public ICollection<Lecture> Lectures { get; set; } = new List<Lecture>();
    }

}
