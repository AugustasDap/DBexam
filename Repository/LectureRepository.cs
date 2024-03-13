using DBexam.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBexam.Repository
{
    public class LectureRepository : ILectureRepository
    {
        private readonly StudentInfoSysContext _context;

        public LectureRepository(StudentInfoSysContext context)
        {
            _context = context;
        }
        public async Task<Lecture> CreateLectureAsync(Lecture lecture)
        {
            _context.Lectures.Add(lecture);
            await _context.SaveChangesAsync();
            return lecture;
        }
        public async Task AddStudentToLectureAsync(int lectureId, Student student)
        {
            var lecture = await _context.Departments.FindAsync(lectureId);
            if (lecture != null)
            {
                lecture.Students.Add(student);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<Lecture> CreateLectureToExistingDepartmentAsync(int departmentId, Lecture lecture)
        {
            var department = await _context.Departments.FindAsync(departmentId);
            if (department != null)
            {
                lecture.Departments.Add(department);
                _context.Lectures.Add(lecture);
                await _context.SaveChangesAsync();
            }
            return lecture;

        }
        public async Task<Lecture> GetLectureByIdAsync(int lectureId)
        {
            return await _context.Lectures.FindAsync(lectureId);
        }
        public async Task<Lecture> DeleteLectureByIdAsync(int lectureId)
        {
            var lecture = await _context.Lectures.FindAsync(lectureId);
            if (lecture == null)
            {
                throw new KeyNotFoundException($"Lecture with ID {lectureId} not found.");
            }
            _context.Lectures.Remove(lecture);
            await _context.SaveChangesAsync();
            return lecture;
        }
        public async Task DisplayAllLecturesInDepartmentAsync(int departmentId)
        {
            var lectures = await _context.Lectures
            .Where(l => l.Departments.Any(d => d.DepartmentId == departmentId))
            .ToListAsync(); //many-to-many

            if (!lectures.Any())
            {
                Console.WriteLine($"No lectures found in Department ID {departmentId}.");

            }

            Console.WriteLine($"Lectures in Department ID {departmentId}:");
            foreach (var lecture in lectures)
            {
                Console.WriteLine($"ID: {lecture.LectureId}, Name: {lecture.Title}");
            }

        }
    }
}
