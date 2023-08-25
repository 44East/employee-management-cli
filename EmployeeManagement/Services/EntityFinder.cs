using EmployeeManagement.Entities;

namespace EmployeeManagement.Services
{
    internal class EntityFinder : IFinderEmployee
    {
        public List<Employee> GetEmployeeByName(string name, string surname, List<Employee> entities)
        {
           
            if (name == null || surname == null)
            {
                throw new NullReferenceException("All the fields must be contain data!");
            }  
            if(entities == null || entities.Count() == 0)
            {
                throw new ArgumentOutOfRangeException("The Employees collection is empty or null!");
            }
            return entities.Where(e => e.Name == name && e.Surname == surname).ToList();      
        }
    }
}
