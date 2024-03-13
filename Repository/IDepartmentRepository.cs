using DBexam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBexam.Repository
{
    public interface IDepartmentRepository
    {
        Task<Department> CreateDepartmentAsync(Department department);
        Task AddStudentToDepartmentAsync(int departmentId, Student student);
        Task AddLectureToDepartmentAsync(int departmentId, Lecture lecture);
        Task<Department> GetDepartmentByIdAsync(int departmentId);
        Task<Department> DeleteDepartmentByIdAsync(int departmentId);

    }

}
