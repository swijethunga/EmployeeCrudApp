using EmployeeCrudApp.Models;

namespace EmployeeCrudApp.Services.DepartmentService
{
    public class DepartmentService : IDepartmentService
    {
        private static List<Department> departments = new List<Department>
 {
     new Department
     {
         Id = 1,
         departmentCode = "HR" ,
         departmentName = "Human Resource"
     },

     new Department
     {
         Id = 2,
         departmentCode = "IT",
         departmentName = "Information Technology"
     }
 };
        private readonly DataContext _dataContext;

        public DepartmentService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<List<Department>> AddDepartment(Department department)
        {   
            
            _dataContext.Departments.Add(department);
            await _dataContext.SaveChangesAsync();

            return await _dataContext.Departments.ToListAsync();
        }

        public async Task<List<Department>>? DeleteDepartment(int id)
        {
            var department = await _dataContext.Departments.FindAsync(id);
            if (department == null)
            {
                return null;
            }

            _dataContext.Departments.Remove(department);
            await _dataContext.SaveChangesAsync();

            return await _dataContext.Departments.ToListAsync();
        }

        public async Task<List<Department>> GetAllDepartment()
        {
            var departments = await _dataContext.Departments.ToListAsync();
            return departments;
        }

        public async Task<Department>? GetSingleDepartment(int id)
        {
            var department = await _dataContext.Departments.FindAsync(id);
            if (department == null)
            {
                return null;
            }
            return department;
        }

        public async Task<List<Department>>? UpdateDepartment(int id, Department request)
        {
            var department = await _dataContext.Departments.FindAsync(id);
            if (department == null)
            {
                return null;
            }

            department.departmentCode = request.departmentCode;
            department.departmentName = request.departmentName;

            await _dataContext.SaveChangesAsync();
            return await _dataContext.Departments.ToListAsync();
        }
    }
}
