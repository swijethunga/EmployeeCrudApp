
namespace EmployeeCrudApp.Services
{
    public class EmployeeService : IEmployeeService
    { 
        /* private static List<Employee> employees = new List<Employee>
       {
            new Employee { Id = 1,
                           firstName = "sinera",
                           lastName = "wijethunga",
                           email = "sinera@gmail.com",
                           dob = new DateTime(2000,10,10),
                           age = 23,
                           salary = 23000,
                           department = "It"

            },

            new Employee { Id = 2,
                           firstName = "kamal",
                           lastName = "perera",
                           email = "kamal@gmail.com",
                           dob = new DateTime(1999,10,10),
                           age = 25,
                           salary = 53000,
                           department = "Hr"
            }
        };*/
        private readonly DataContext _context;

        public EmployeeService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Employee>> AddEmployee(Employee employee)
        {
            if(employee.dob >= DateTime.Now || employee.salary < 0)
            {
                return null;
            }

            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return await _context.Employees.ToListAsync();
        }

        public async Task<List<Employee>?> DeleteEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return null;
            }
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return await _context.Employees.ToListAsync();
        }

        public async Task<List<Employee>> GetAllEmployee()
        {
            var employees = await _context.Employees.ToListAsync();
            return employees;
        }

        public async Task<Employee?> GetSingleEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return null;
            }
            return employee;
        }

        public async Task<List<Employee>?> UpdateEmployee(int id, Employee request)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return null;
            }

            employee.firstName = request.firstName;
            employee.lastName = request.lastName;
            employee.email = request.email;
            employee.dob = request.dob;
            employee.age = request.age;
            employee.salary = request.salary;
            employee.department = request.department;

            await _context.SaveChangesAsync();

            return await _context.Employees.ToListAsync();
        }
    }
}
