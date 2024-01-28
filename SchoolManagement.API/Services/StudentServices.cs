using Microsoft.EntityFrameworkCore.Diagnostics;
using SchoolManagement.API.Models;
using SchoolManagement.API.Repository;

namespace SchoolManagement.API.Services
{
    public class StudentServices : IService<Student>
    {
        private readonly IRepository studentRepository;

        public StudentServices(IRepository _studentRepository) 
        {
            studentRepository = _studentRepository; 
        }

        public bool Add(Student register)
        {
            if(register == null) throw new ArgumentNullException("Registro nulo");

            studentRepository.AddStudent(register);
            return studentRepository.SaveChanges();
        }

        public bool Delete(int id)
        {
            if (id == 0 || id == null) throw new ArgumentNullException("Id não válido");
            studentRepository.DeleteStudent(id);
            return studentRepository.SaveChanges();
        }

        public IEnumerable<Student> List()
        {
            return studentRepository.GetAllStudents();
        }

        public bool Update(Student register)
        {
            if (register == null) throw new ArgumentNullException("Registro nulo");
            if (register.Id == 0 || register.Id == null) throw new ArgumentNullException("Id não válido");
            studentRepository.UpdateStudent(register);
            return studentRepository.SaveChanges();

        }
    }
}
