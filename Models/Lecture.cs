using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBexam.Models
{
    public class Lecture
    {
        public int LectureId { get; set; }
        public string Title { get; set; }
        public int DepartmentId { get; set; }
        public ICollection<Department> Departments { get; set; } = new List<Department>();
        public ICollection<Student> Students { get; set; } = new List<Student>();
    }

}
