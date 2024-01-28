using SchoolManagement.API.Models;

namespace SchoolManagement.XUnit
{
    public class StudentTests
    {
        [Fact]
        public void CreateNewStudent()
        {
            var studentName = "Rodrigo Fessore";
            var studentEmail = "rodrigo.fessore@gmail.com";
            var studentRA = "114678601";
            var studentCPF = "356.152.728-05";

            var student = new Student(studentName, studentEmail, studentRA, studentCPF);

            Assert.NotNull(student);
            Assert.Equal(studentName, student.Name);
            Assert.Equal(studentEmail, student.Email);
            Assert.Equal(studentRA, student.RA);
            Assert.Equal(studentCPF, student.CPF);

        }
    }
}