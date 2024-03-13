using DBexam.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBexam.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentInfoSysContext _context;

        public StudentRepository(StudentInfoSysContext context)
        {
            _context = context;
        }

        public async Task<Student> CreateStudentAsync(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return student;
        }
        public async Task<Student> CreateStudentToExistingDepartmentAsync(int departmentId, Student student)
        {
            var department = await _context.Departments.FindAsync(departmentId);
            if (department != null)
            {
                student.DepartmentId = department.DepartmentId;
                _context.Students.Add(student);
                await _context.SaveChangesAsync();
            }
            return student;

        }

        public async Task<Student> MoveExistingStudentToExistingDepartmentAsync(int newDepartmentId, int studentId)
        {
            var department = _context.Departments.FirstOrDefault(d => d.DepartmentId == newDepartmentId);

            var student = _context.Students.FirstOrDefault(s => s.StudentId == studentId);
            //if (department != null && student != null)
            //{
            student.DepartmentId = newDepartmentId;

            await _context.SaveChangesAsync();
            //}
            return student;

        }
        public async Task<Student> GetStudentByIdAsync(int studentId)
        {
            return await _context.Students.FindAsync(studentId);
        }

        public async Task DisplayAllStudentsByDepartmentAsync(int departmentId)
        {
            var students = await _context.Students
                .Where(s => s.DepartmentId == departmentId)
                .ToListAsync();

            if (!students.Any())
            {
                Console.WriteLine("No students found in the specified department.");

            }

            Console.WriteLine($"Students in Department ID {departmentId}:");
            foreach (var student in students)
            {
                Console.WriteLine($"ID: {student.StudentId}, Name: {student.Name}");
            }

        }
    }
}
