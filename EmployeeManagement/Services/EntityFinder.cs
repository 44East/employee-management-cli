using EmployeeManagement.Entities;

namespace EmployeeManagement.Services
{
    /// <summary>
    /// Universal class for searching entities in collections
    /// </summary>
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
            return entities.Where(e => e.Name.ToLowerInvariant().Equals(name) && e.Surname.ToLowerInvariant().Equals(surname)).ToList();      
        }
    }
}
