namespace FirstWebAPI.Models
{
    public class RepositoryEmployee
    {
        private List<Employee> _employees; // Simulate in-memory storage
        public RepositoryEmployee()
        {
            // Initialize the list of employees (you can load this from a database or another source)
            _employees = new List<Employee>
            {
                new Employee { Id = 1, FirstName = "John", LastName = "Doe" },
                new Employee { Id = 2, FirstName = "Jane", LastName = "Smith" }
                // Add more employees as needed
            };
        }
        public List<Employee> GetAllEmployees()
        {
            return _employees;
        }
        public Employee GetEmployeeById(int id)
        {
            return _employees.FirstOrDefault(e => e.Id == id);
        }
        public void AddEmployee(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee));
            }
            employee.Id = GetNextEmployeeId();
            _employees.Add(employee);
        }
        public void UpdateEmployee(Employee updatedEmployee)
        {
            if (updatedEmployee == null)
            {
                throw new ArgumentNullException(nameof(updatedEmployee));
            }
            var existingEmployee = GetEmployeeById(updatedEmployee.Id);
            if (existingEmployee == null)
            {
                throw new InvalidOperationException($"Employee with ID {updatedEmployee.Id} not found.");
            }
            // Update the existing employee data
            existingEmployee.FirstName = updatedEmployee.FirstName;
            existingEmployee.LastName = updatedEmployee.LastName;
            // Update other properties as needed
        }
        public void DeleteEmployee(int id)
        {
            var employeeToRemove = GetEmployeeById(id);
            if (employeeToRemove != null)
            {
                _employees.Remove(employeeToRemove);
            }
        }
        private int GetNextEmployeeId()
        {
            return _employees.Max(e => e.Id) + 1;
        }
    }
}