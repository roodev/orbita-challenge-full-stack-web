using SchoolManagement.API.Models;

namespace SchoolManagement.API.Repository
{
    public interface IRepository
    {
        void AddStudent(Student entity);
        bool SaveChanges();
        void DeleteStudent(int id);
        void UpdateStudent(Student student);
        Student GetStudentById(int id);

        IEnumerable<Student> GetAllStudents();
    }
}
