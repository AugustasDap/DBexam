using DBexam.Repository;
using Microsoft.Identity.Client;

namespace DBexam
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //Create Student, Department, Lecture
            StudentISEngine engine = new StudentISEngine();
            engine.CreateDepartmentWithStudentsAndLectures().Wait();

            //Create Lecture
            //StudentISEngine addLecture = new StudentISEngine();
            //addLecture.AddLecture().Wait();

            //create lecture to existing department
            //StudentISEngine addLectureToDepartment = new StudentISEngine();
            //addLectureToDepartment.CreateLectureToExistingDepartment().Wait();

            //delete Lecture
            //StudentISEngine deleteLecture = new StudentISEngine();
            //deleteLecture.DeleteLecture().Wait();

            //Create student+department
            //StudentISEngine addStudentDepart = new StudentISEngine();
            //addStudentDepart.AddStudentWithDepartment().Wait();

            //Create student to existing department
            //StudentISEngine addStudentoToDepartment = new StudentISEngine();
            //addStudentoToDepartment.CreateStudentToExistingDepartment().Wait();

            //move existing student to existing department
            //StudentISEngine moveStudent = new StudentISEngine();
            //moveStudent.MoveStudentToExistingDepartment().Wait();

            //Create Department
            //StudentISEngine addDepartment = new StudentISEngine();
            //addDepartment.AddDepartment().Wait();

            //Delete Department
            //StudentISEngine deleteDepart = new StudentISEngine();
            //deleteDepart.DeleteDepartment().Wait();

            //Display students by department
            //StudentISEngine displayStudents = new StudentISEngine();
            //displayStudents.DisplayStudentsByDepartment().Wait();

            //not working!!
            //Display students by department
            //StudentISEngine displayLectures = new StudentISEngine();
            //displayLectures.DisplayLecturesByDepartment().Wait();
        }

    }
}
