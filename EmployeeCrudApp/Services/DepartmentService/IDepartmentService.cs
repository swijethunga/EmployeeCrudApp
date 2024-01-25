namespace EmployeeCrudApp.Services.DepartmentService
{
    public interface IDepartmentService
    {
        Task<List<Department>> GetAllDepartment();

        Task<Department?> GetSingleDepartment(int id);

        Task<List<Department>> AddDepartment(Department department);

        Task<List<Department>?> UpdateDepartment(int id, Department request);

        Task<List<Department>?> DeleteDepartment(int id);
    }
}
