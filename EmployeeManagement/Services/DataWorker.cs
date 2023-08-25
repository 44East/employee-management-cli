using EmployeeManagement.Entities;
using System.Linq;

namespace EmployeeManagement.Services
{
    internal class DataWorker<T>  where T : class
    { 
        private readonly FileWorker<T> _fileWorker;
        private List<T> _entities;
        public DataWorker()
        {
            _fileWorker = new FileWorker<T>();
            _entities = _fileWorker.ReadFileFromLocalDisk();
        }

        public List<T> GetTheEntityList() => _entities;
        public void SaveTheEntity(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Entity can't be null!");
            }
            _entities.Add(entity);
            _fileWorker.SaveEntityToLocalDrive(_entities);
        }
       

    }
}