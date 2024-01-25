namespace EmployeeCrudApp.Services
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetAllEmployee();

        Task<Employee?> GetSingleEmployee(int id);

        Task<List<Employee>> AddEmployee(Employee employee);

        Task<List<Employee>?> UpdateEmployee(int id, Employee request);

        Task<List<Employee>?> DeleteEmployee(int id);


    }
}
