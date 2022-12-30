using ApiEmployee.Models;

namespace ApiEmployee.Interfaces
{
    public interface IDataEmployee
    {
        Task<List<Employee>> GetAllEmployees();
        Task<List<Employee>> GetEmployee(int id);
        Task<int> InsertEmployee(Employee employee);
        Task<int> UpdateEmployee(int id, Employee employee);
        Task<int> DeleteEmployee(int id);
    }
}
