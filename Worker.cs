using System;

namespace SynergyWorkerCase
{
    /// <summary>
    /// Класс работника университета «Синергия».
    /// Хранит информацию о сотруднике и его стаже работы в вузе.
    /// </summary>
    public class Worker
    {
        // ---------- Поля класса ----------

        /// <summary>Фамилия и инициалы работника</summary>
        private string _fullName;

        /// <summary>Название занимаемой должности в университете</summary>
        private string _position;

        /// <summary>Заработная плата (руб.)</summary>
        private decimal _salary;

        /// <summary>Год поступления на работу</summary>
        private int _startYear;

        // ---------- Конструкторы ----------

        /// <summary>
        /// Конструктор по умолчанию. Инициализирует поля значениями по умолчанию.
        /// </summary>
        public Worker()
        {
            _fullName = "Неизвестный сотрудник";
            _position = "Стажер";
            _salary = 0;
            _startYear = DateTime.Now.Year;
        }

        /// <summary>
        /// Конструктор с параметрами для быстрого создания объекта.
        /// </summary>
        public Worker(string fullName, string position, decimal salary, int startYear)
        {
            _fullName = fullName;
            _position = position;
            _salary = salary;
            _startYear = startYear;
        }

        /// <summary>
        /// Конструктор копирования.
        /// </summary>
        public Worker(Worker other)
        {
            _fullName = other._fullName;
            _position = other._position;
            _salary = other._salary;
            _startYear = other._startYear;
        }

        // ---------- Деструктор (финализатор) ----------

        /// <summary>
        /// Деструктор. Вызывается сборщиком мусора при удалении объекта.
        /// </summary>
        ~Worker()
        {
            Console.WriteLine($"[Деструктор] Объект сотрудника {_fullName} удален из памяти.");
        }

        // ---------- Методы изменения полей (сеттеры) ----------

        public void SetFullName(string fullName)
        {
            _fullName = fullName;
        }

        public void SetPosition(string position)
        {
            _position = position;
        }

        public void SetSalary(decimal salary)
        {
            _salary = salary < 0 ? 0 : salary;
        }

        public void SetStartYear(int startYear)
        {
            _startYear = startYear;
        }

        // ---------- Методы отображения полей (геттеры) ----------

        public string GetFullName() => _fullName;

        public string GetPosition() => _position;

        public decimal GetSalary() => _salary;

        public int GetStartYear() => _startYear;

        // ---------- Методы согласно заданию ----------

        /// <summary>
        /// Рассчитывает стаж работы в организации на текущий момент.
        /// </summary>
        public int GetExperienceYears()
        {
            return DateTime.Now.Year - _startYear;
        }

        /// <summary>
        /// Проверяет, превышает ли стаж заданное значение.
        /// </summary>
        public bool HasExperienceMoreThan(int years)
        {
            return GetExperienceYears() > years;
        }

        /// <summary>
        /// Полное отображение информации о работнике.
        /// </summary>
        public void Display()
        {
            Console.WriteLine($"Сотрудник: {_fullName,-25} | Должность: {_position,-20} | " +
                              $"Зарплата: {_salary,10:C2} | Стаж: {GetExperienceYears()} лет (с {_startYear} г.)");
        }
    }
}