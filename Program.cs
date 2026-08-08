using System;
using System.Collections.Generic;
using System.Linq;

namespace SynergyWorkerCase
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("==========================================================");
            Console.WriteLine("  Отдел кадров: Московский университет «Синергия»");
            Console.WriteLine("==========================================================\n");

            // Используем стандартный список List<T> согласно заданию
            List<Worker> workers = new List<Worker>();

            Console.WriteLine("Введите данные сотрудников университета.\n");

            int count = ReadInt("Количество сотрудников для ввода: ");

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"\n--- Сотрудник № {i + 1} ---");

                string fio = ReadString("Фамилия и инициалы (например, Иванов И.И.): ");
                string pos = ReadString("Должность (преподаватель, проректор, методист и т.д.): ");
                decimal salary = ReadDecimal("Заработная плата (руб.): ");
                int year = ReadInt("Год поступления на работу: ");

                // Создаем объект через конструктор с параметрами
                Worker w = new Worker(fio, pos, salary, year);
                workers.Add(w);
            }

            Console.WriteLine("\n==========================================================");
            Console.WriteLine("Все введенные сотрудники:");
            Console.WriteLine("==========================================================");
            foreach (var w in workers)
            {
                w.Display();
            }

            Console.WriteLine("\n==========================================================");
            int requiredExperience = ReadInt("Введите минимальный стаж для поиска (лет): ");
            Console.WriteLine("==========================================================");

            // Поиск сотрудников со стажем больше введенного значения
            var experiencedWorkers = workers
                .Where(w => w.HasExperienceMoreThan(requiredExperience))
                .ToList();

            if (experiencedWorkers.Count > 0)
            {
                Console.WriteLine($"\nСотрудники со стажем более {requiredExperience} лет:");
                Console.WriteLine("----------------------------------------------------------");
                foreach (var w in experiencedWorkers)
                {
                    w.Display();
                }
            }
            else
            {
                Console.WriteLine($"\n[ВНИМАНИЕ] В университете нет сотрудников со стажем более {requiredExperience} лет.");
            }

            Console.WriteLine("\nНажмите Enter для завершения работы программы...");
            Console.ReadLine();
        }

        // ---------- Вспомогательные методы для безопасного ввода ----------

        static string ReadString(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        static int ReadInt(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out int result) && result >= 0)
                    return result;
                Console.WriteLine("Ошибка! Введите целое неотрицательное число.");
            }
        }

        static decimal ReadDecimal(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (decimal.TryParse(Console.ReadLine(), out decimal result) && result >= 0)
                    return result;
                Console.WriteLine("Ошибка! Введите корректную сумму.");
            }
        }
    }
}