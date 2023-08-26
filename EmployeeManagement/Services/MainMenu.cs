using EmployeeManagement.Entities;
using EmployeeManagement.Resources;
using System.Threading.Channels;

namespace EmployeeManagement.Services
{
    internal class MainMenu
    {
        private readonly DataWorker<Employee> _dataWorker;
        private readonly EntityFinder _finder;

        public MainMenu()
        {
            _finder = new EntityFinder();
            _dataWorker = new DataWorker<Employee>();
        }
        public void Run()
        {
            Console.Clear();
            bool runner = true;
            while (runner)
            {
                Console.WriteLine(TextData.MainText);
                var userSelect = Console.ReadLine()?.Trim();
                switch (userSelect)
                {
                    case "1":
                        runner = false;
                        InsertEmployee();
                        break;
                    case "2":
                        runner = false;
                        FindTheEmployee();
                        break;
                    case "3":
                        runner = false;
                        GetTheAllEmployeeList();
                        break;
                    case "q":
                        runner = false;
                        break;
                    default:
                        Console.WriteLine("Try again!");
                        break;

                }
            }
        }
        private void InsertEmployee()
        {
            Console.WriteLine(TextData.InsertEmployeeName);
            string name = Console.ReadLine();

            Console.WriteLine(TextData.InsertEmployeeSurname);
            string surname = Console.ReadLine();

            Console.WriteLine(TextData.InsertEmployeeAge);
            int age;
            while (!int.TryParse(Console.ReadLine(), out age))
            {
                Console.WriteLine(TextData.InsertAgeFailure);
            }

            Console.WriteLine(TextData.InsertEmailEmployee);
            string email = Console.ReadLine();

            Console.WriteLine(TextData.InsertEmployeePhone);
            string phoneNumber = Console.ReadLine();
            try
            {
                _dataWorker.SaveTheEntity(new Employee
                {
                    Name = name,
                    Surname = surname,
                    Age = age,
                    Email = email,
                    PhoneNumber = phoneNumber
                });
                Console.WriteLine(TextData.EmployeeAddedSuccess);
                Task.Delay(1000).Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Run();
        }
        private void FindTheEmployee()
        {            
            bool runner = true;
            while (runner)
            {
                Console.Clear();
                Console.WriteLine(TextData.EmployeeSearchBar);
                Console.WriteLine(TextData.InsertEmployeeName);
                var employeeName = Console.ReadLine().Trim().ToLowerInvariant();

                Console.WriteLine(TextData.InsertEmployeeSurname);
                var employeeSurname = Console.ReadLine().Trim().ToLowerInvariant();

                if (!string.IsNullOrEmpty(employeeName) && !string.IsNullOrEmpty(employeeSurname))
                {
                    var foundEmployeeCollection = _finder.GetEmployeeByName(employeeName, employeeSurname, _dataWorker.GetTheEntityList());
                    if (foundEmployeeCollection.Count() > 0)
                    {
                        Console.WriteLine(TextData.EmployeeFoundSuccess);
                        foreach (var employee in foundEmployeeCollection)
                        {
                            Console.WriteLine(string.Format(TextData.EmployeeAllDataString,
                                                            employee.Name,
                                                            employee.Surname,
                                                            employee.Age,
                                                            employee.Email,
                                                            employee.PhoneNumber));
                        }
                        Console.WriteLine(TextData.GetReadyButton);
                        Console.ReadKey();
                        Run();
                    }
                    break;
                }
                Console.WriteLine(TextData.EmployeeSearchFailure);
            }
            Console.WriteLine(TextData.EmployeeSearchNotFound);
            Task.Delay(1000).Wait();
            Run();
        }
        private void GetTheAllEmployeeList()
        {
            Console.WriteLine(TextData.EmployeeFoundSuccess);
            foreach (var employee in _dataWorker.GetTheEntityList())
            {
                Console.WriteLine(string.Format(TextData.EmployeeAllDataString,
                                                employee.Name,
                                                employee.Surname,
                                                employee.Age,
                                                employee.Email,
                                                employee.PhoneNumber));
            }
            Console.WriteLine(TextData.GetReadyButton);
            Console.ReadKey();
            Run();
        }

    }
}
