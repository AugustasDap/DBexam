using DBexam.Models;
using DBexam.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBexam
{
    public class StudentISEngine
    {

        public async Task CreateDepartmentWithStudentsAndLectures()
        {
            //var optionsBuilder = new DbContextOptionsBuilder<StudentInfoSysContext>();
            var context = new StudentInfoSysContext();
            var departmentRepository = new DepartmentRepository(context);

            // Create a new department
            var department = new Department { Name = "" };
            await departmentRepository.CreateDepartmentAsync(department);

            // Add a new student to the department
            var student = new Student { Name = "Jonas Jonaitis", DepartmentId = department.DepartmentId };
            await departmentRepository.AddStudentToDepartmentAsync(department.DepartmentId, student);

            // Add a new lecture to the department
            var lecture = new Lecture { Title = "C#" };
            await departmentRepository.AddLectureToDepartmentAsync(department.DepartmentId, lecture);

        }



        public async Task AddLecture()
        {
            var context = new StudentInfoSysContext();
            var lectureRepository = new LectureRepository(context);
            var lecture = new Lecture { Title = "Bridges" };
            await lectureRepository.CreateLectureAsync(lecture);
        }

        public async Task DeleteLecture()
        {
            var context = new StudentInfoSysContext();
            var lectureRepository = new LectureRepository(context);
            int lectureIdToDelete = 4; // Example ID
            try
            {
                var deletedLecture = await lectureRepository.DeleteLectureByIdAsync(lectureIdToDelete);
                Console.WriteLine($"Lecture '{deletedLecture.Title}' deleted successfully.");
            }
            catch (KeyNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public async Task AddDepartment()
        {
            var context = new StudentInfoSysContext();
            var departmentRepository = new DepartmentRepository(context);
            var department = new Department { Name = "Economics" };
            await departmentRepository.CreateDepartmentAsync(department);
        }

        public async Task DeleteDepartment()
        {
            var context = new StudentInfoSysContext();
            var departmentRepository = new DepartmentRepository(context);
            var departmentIdToDelete = 4; // Example department ID
            try
            {
                var deletedDepartment = await departmentRepository.DeleteDepartmentByIdAsync(departmentIdToDelete);
                Console.WriteLine($"Department {deletedDepartment.Name} deleted successfully.");
            }
            catch (KeyNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public async Task AddStudentWithDepartment()
        {
            var context = new StudentInfoSysContext();
            var departmentRepository = new DepartmentRepository(context);

            var department = new Department { Name = "Architecture" };
            await departmentRepository.CreateDepartmentAsync(department);

            var student = new Student { Name = "Povilas Povylius", DepartmentId = department.DepartmentId };
            await departmentRepository.AddStudentToDepartmentAsync(department.DepartmentId, student);
            /*Computer Science
             * Architecture
             * Robotics
             * 
             */

        }
        public async Task CreateStudentToExistingDepartment()
        {
            var context = new StudentInfoSysContext();
            var studentRepository = new StudentRepository(context);
            int departmentId = 3; // Example department ID
            var student = new Student
            {
                Name = "Parkas Parkinsonas",
                DepartmentId = departmentId
            };
            await studentRepository.CreateStudentToExistingDepartmentAsync(departmentId, student);

        }

        public async Task CreateLectureToExistingDepartment()
        {
            var context = new StudentInfoSysContext();
            var lectureRepository = new LectureRepository(context);
            int departmentId = 2; // Example department ID
            var lecture = new Lecture
            {
                Title = "Roads"
            };
            await lectureRepository.CreateLectureToExistingDepartmentAsync(departmentId, lecture);

        }
        public async Task MoveStudentToExistingDepartment()
        {
            var context = new StudentInfoSysContext();
            int newDepartmentId = 3; // new department ID
            int studentId = 5;
            try
            {
                var studentRepository = new StudentRepository(context);
                var updatedStudent = await studentRepository.MoveExistingStudentToExistingDepartmentAsync(newDepartmentId, studentId);
            }
            catch (KeyNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }


        }
        public async Task DisplayStudentsByDepartment()
        {
            var context = new StudentInfoSysContext();
            var studentRepository = new StudentRepository(context);
            int departmentId = 1; // Example department ID
            await studentRepository.DisplayAllStudentsByDepartmentAsync(departmentId);
        }

        public async Task DisplayLecturesByDepartment()
        {
            var context = new StudentInfoSysContext();
            var lectureRepository = new LectureRepository(context);
            int departmentId = 1; // Example department ID
            await lectureRepository.DisplayAllLecturesInDepartmentAsync(departmentId);
        }
    }
}
