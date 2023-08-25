namespace EmployeeManagement.Resources
{
    internal static class TextData
    {
        public static string MainText { get; } = "=================================================\n" +
                                                 "|Доступные действия:                            |\n" +
                                                 "=================================================\n" +
                                                 "|1 - Внести нового сотрудника                   |\n" +
                                                 "|2 - Найти сотрудника по Имени и Фамилии        |\n" +
                                                 "|3 - Посмотреть весь список сотрудников         |\n" +
                                                 "|q - Выйти из программы                         |\n" +
                                                 "=================================================\n";
        public static string InsertEmployeeName { get; } = "Введите имя сотрудника:";
        public static string InsertEmployeeSurname { get; } = "Введите фамилию сотрудника:";
        public static string InsertEmployeeAge { get; } = "Введите возраст сотрудника:";
        public static string InsertAgeFailure { get; } = "Некорректный возраст. Возраст должен быть числом.";
        public static string InsertEmailEmployee { get;  } = "Введите email сотрудника:";
        public static string InsertEmployeePhone { get; } = "Введите номер телефона сотрудника:";
        public static string EmployeeAddedSuccess { get; } = "Сотрудник успешно добавлен.";
        public static string EmployeeSearchBar { get; } = "=================================================\n" +
                                                          "|Поиск сотрудника:                              |\n" +
                                                          "=================================================\n";
        public static string EmployeeFoundSuccess { get; } = "Список найденных сотрудников:";
        public static string EmployeeAllDataString { get; } = "Имя: {0}, Фамилия: {1}, Возраст: {2}, Email: {3}, Телефон: {4}";               
        public static string EmployeeSearchFailure { get; } = "Вы не ввели по крайней мере ожно из значений!";
        public static string EmployeeSearchNotFound { get; } = "Не найдено совпадений!";
        public static string GetReadyButton { get; } = "Для продолжения нажмите любую клавишу";
    }
}
