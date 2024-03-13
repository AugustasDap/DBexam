using DBexam.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBexam.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly StudentInfoSysContext _context;

        public DepartmentRepository(StudentInfoSysContext context)
        {
            _context = context;
        }

        public async Task<Department> CreateDepartmentAsync(Department department)
        {
            _context.Departments.Add(department);
            await _context.SaveChangesAsync();
            return department;
        }

        public async Task AddStudentToDepartmentAsync(int departmentId, Student student)
        {
            var department = await _context.Departments.FindAsync(departmentId);
            if (department != null)
            {
                department.Students.Add(student);
                await _context.SaveChangesAsync();
            }
        }

        public async Task AddLectureToDepartmentAsync(int departmentId, Lecture lecture)
        {
            var department = await _context.Departments.FindAsync(departmentId);
            if (department != null)
            {
                // Check if the lecture exists; if so, add the existing instance
                var existingLecture = await _context.Lectures.FindAsync(lecture.LectureId);
                if (existingLecture != null)
                {
                    department.Lectures.Add(existingLecture);
                }
                else
                {
                    department.Lectures.Add(lecture);
                }
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Department> GetDepartmentByIdAsync(int departmentId)
        {
            return await _context.Departments.FindAsync(departmentId);
        }

        public async Task<Department> DeleteDepartmentByIdAsync(int departmentId)
        {
            var department = await _context.Departments
           .FirstOrDefaultAsync(d => d.DepartmentId == departmentId);
            if (department == null)
            {
                throw new KeyNotFoundException($"Department with ID {departmentId} not found.");
            }
            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();
            return department;
        }
    }

}
