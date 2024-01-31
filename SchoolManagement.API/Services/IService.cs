namespace SchoolManagement.API.Services
{
    public interface IService<T>
    {
        bool Add(T register);
        bool Delete(int id);
        bool Update(T register);
        T GetStudentById(int id);
        IEnumerable<T> List();
    }
}
