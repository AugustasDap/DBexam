using DBexam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBexam.Repository
{
    public interface ILectureRepository
    {
        Task<Lecture> CreateLectureAsync(Lecture lecture);
        Task<Lecture> GetLectureByIdAsync(int lectureId);
        Task<Lecture> DeleteLectureByIdAsync(int lectureId);
        Task<Lecture> CreateLectureToExistingDepartmentAsync(int departmentId, Lecture lecture);
        Task DisplayAllLecturesInDepartmentAsync(int departmentID);
    }
}
