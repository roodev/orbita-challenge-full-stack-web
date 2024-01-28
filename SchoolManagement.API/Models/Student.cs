using Microsoft.Extensions.Primitives;

namespace SchoolManagement.API.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string RA { get;  set; }
        public string CPF { get; set; }

        public Student()
        {
        }

        public Student(string name, string email, string ra, string cpf) 
        {
            Name = name;
            Email = email;
            RA = ra;
            CPF = cpf;
        }

    }

   
}
