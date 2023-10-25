namespace AssessmentBackendDeveloperXsis_Sukrian.Services
{
    public interface IService<T> where T : class
    {
        IEnumerable<T> SelectAll();
        T? Select(int Id);
        T Add(T entity);
        T? Update(T entity);
        T? Delete(int Id);
    }
}
