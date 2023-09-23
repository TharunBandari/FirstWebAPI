using FirstWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;



namespace FirstWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private RepositoryEmployee _repositoryEmployee;
        public EmployeeController(RepositoryEmployee repository)
        {
            _repositoryEmployee = repository;
        }
        [HttpGet("/ListAllEmployees")]
        public IEnumerable<EmpViewModel> ListAllEmployees()
        {
            List<Employee> employees = _repositoryEmployee.AllEmployees();
            IEnumerable<EmpViewModel> empList = _repositoryEmployee.Lister(employees);
            return empList;
        }
        [HttpGet("/FindEmployee")]
        public EmpViewModel FindEmployee(int id)
        {
            Employee employeeById = _repositoryEmployee.FindEmpoyeeById(id);
            EmpViewModel empList = _repositoryEmployee.Viewer(employeeById);
            return empList;
        }
        [HttpPost("/AddEmployee")]
        public string AddEmployee(EmpViewModel newEmployeeView)
        {
            Employee newEmployee = _repositoryEmployee.ViewToEmp(newEmployeeView);
            newEmployee.EmployeeId = 0;/**/
            int employeestatus = _repositoryEmployee.AddEmployee(newEmployee);
            if (employeestatus == 0)
            {
                return "Employee Not Added To Database Since it already exist";
            }
            else
            {
                return "Employee Added To Database";
            }
        }
        [HttpPut("/ModifyEmployee")]
        public Employee ModifyEmployee(int id, [FromBody] EmpViewModel newEmployeeView)
        {
            Employee newEmployee = _repositoryEmployee.FindEmpoyeeById(id);
            newEmployee = _repositoryEmployee.ViewToEmp(newEmployeeView);
            _repositoryEmployee.UpdateEmployee(newEmployee);
            return newEmployee;
        }
        [HttpDelete("/DeleteEmployee")]
        public string DeleteEmployee(int id)
        {
            int employeestatus = _repositoryEmployee.DeleteEmployee(id);
            if (employeestatus == 0)
            {
                return "Employee does not exist in the Database";
            }
            else
            {
                return "Employee Successfully Deleted";
            }
        }
    }
}