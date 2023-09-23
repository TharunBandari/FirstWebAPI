using FirstWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Numerics;



namespace FirstWebAPI.Models
{
    public class RepositoryEmployee
    {
        private NorthwindContext _context;
        public RepositoryEmployee(NorthwindContext context)
        {
            _context = context;
        }
        public List<Employee> AllEmployees()
        {
            return _context.Employees.ToList();
        }
        public Employee FindEmpoyeeById(int id)
        {
            return _context.Employees.Find(id);
        }
        public int AddEmployee(Employee newEmployee)
        {
            _context.Employees.Add(newEmployee);
            return _context.SaveChanges();
        }
        public int UpdateEmployee(Employee emp)
        {
            _context.Employees.Update(emp);
            return _context.SaveChanges();
        }
        public int DeleteEmployee(int id)
        {
             Employee employeetodelete = _context.Employees.FirstOrDefault(e=> e.EmployeeId == id);
            if(employeetodelete != null)
            {
                _context.Employees.Remove(employeetodelete);
                _context.SaveChanges();
                
            }
            else
            {
                return 0;
            }
            return 1;

        }
        public IEnumerable<EmpViewModel> Lister(List<Employee> employees)
        {
            List<EmpViewModel> empList = (
                from emp in employees
                select new EmpViewModel()
                {
                    EmpId = emp.EmployeeId,
                    FirstName = emp.FirstName,
                    LastName = emp.LastName,
                    BirthDate = emp.BirthDate,
                    HireDate = emp.HireDate,
                    Title = emp.Title,
                    City = emp.City,
                    ReportsTo = emp.ReportsTo
                }
                ).ToList();
            return empList;
        }
        public EmpViewModel Viewer(Employee employee)
        {
            EmpViewModel employeeView = new EmpViewModel();
            employeeView.EmpId = employee.EmployeeId;
            employeeView.FirstName = employee.FirstName;
            employeeView.LastName = employee.LastName;
            employeeView.BirthDate = employee.BirthDate;
            employeeView.HireDate = employee.HireDate;
            employeeView.Title = employee.Title;
            employeeView.City = employee.City;
            employeeView.ReportsTo = employee.ReportsTo;
            return employeeView;
        }
        public Employee ViewToEmp(EmpViewModel newEmployeeView)
        {
            Employee newEmployee = new Employee();
            newEmployee.FirstName = newEmployeeView.FirstName;
            newEmployee.LastName = newEmployeeView.LastName;
            newEmployee.BirthDate = newEmployeeView.BirthDate;
            newEmployee.HireDate = newEmployeeView.HireDate;
            newEmployee.Title = newEmployeeView.Title;
            newEmployee.City = newEmployeeView.City;
            newEmployee.ReportsTo = newEmployeeView.ReportsTo;
            return newEmployee;
        }
    }
}