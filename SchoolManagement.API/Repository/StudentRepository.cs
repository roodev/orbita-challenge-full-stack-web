using SchoolManagement.API.Models;
using System.Transactions;

namespace SchoolManagement.API.Repository
{
    public class StudentRepository : IRepository
    {
        private readonly SchoolManagementContext _context;

        public StudentRepository(SchoolManagementContext context)
        {
            _context = context;
        }

        public void AddStudent(Student entity)
        {
            _context.Add(entity);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);
        }

        public IEnumerable<Student> GetAllStudents() 
        {
            IQueryable<Student> query = _context.Students;
            return query.ToList();
        }

        public void DeleteStudent(int id) 
        {
            IQueryable<Student> query = _context.Students;
            if (id == null) throw new ArgumentNullException("Id nulo");

            Student student = query.Where(s =>  s.Id == id).FirstOrDefault();
            if (student == null) throw new ArgumentNullException("Aluno não encontrado");
            _context.Remove(student);
        }

        public void UpdateStudent(Student entity)
        {
            //Fazer tratativa dados nulos
            IQueryable<Student> query = _context.Students;
            if(entity.Id == null) throw new ArgumentNullException("Id nulo");
            Student student = query.Where(s => s.Id == entity.Id).FirstOrDefault();
            student.Name = entity.Name;
            student.Email = entity.Email;
            _context.Update(student);
        }
    }
}
