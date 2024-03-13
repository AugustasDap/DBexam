using DBexam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBexam.Repository
{
    public interface IStudentRepository
    {
        Task<Student> CreateStudentAsync(Student student);
        Task<Student> GetStudentByIdAsync(int studentId);
        Task<Student> CreateStudentToExistingDepartmentAsync(int departmentId, Student student);
        //Task<Student> DeleteStudentByIdAsync(int studentId);
        Task<Student> MoveExistingStudentToExistingDepartmentAsync(int newDepartmentId, int studentId);

        Task DisplayAllStudentsByDepartmentAsync(int departmentID);
    }
}
