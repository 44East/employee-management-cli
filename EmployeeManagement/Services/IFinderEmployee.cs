using EmployeeManagement.Entities;

namespace EmployeeManagement.Services
{
    internal interface IFinderEmployee
    {
        public List<Employee> GetEmployeeByName(string name, string surname, List<Employee> entities);
    }
}
