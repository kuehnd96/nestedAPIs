namespace FrontApi.Interfaces
{
    // NOTE: Ideally these would be made available through a versioned API client Nuget package

    /// <summary>
    /// Wrapper for making calls to API3.
    /// </summary>
    public interface IApi3Client
    {
        Task<Employee> GetEmployee(int id);
    }

    public record Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
    }
}
