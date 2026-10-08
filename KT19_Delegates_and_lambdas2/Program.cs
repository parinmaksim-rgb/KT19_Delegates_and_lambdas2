namespace KT19
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        private const string MenuProcess = "1";
        private const string MenuExit = "2";
        private const char Separator = ',';

        static void Main()
        {
            while (true)
            {
                Console.WriteLine("Меню:");
                Console.WriteLine("1 - Ввести список сообщений и запустить обработку");
                Console.WriteLine("2 - Выйти");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case MenuProcess:
                        ProcessMessages();
                        break;
                    case MenuExit:
                        return;
                    default:
                        Console.WriteLine("Неверный ввод, повторите попытку.\n");
                        break;
                }
            }
        }

        static void ProcessMessages()
        {
            MessageData data = new MessageData();
            MessageProcessor processor = new MessageProcessor(data.History);

            Console.WriteLine("Введите сообщения через запятую (например: hi, привет, ok, до свидания):");
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                return;
            }

            string[] parts = input.Split(new char[] { Separator }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string part in parts)
            {
                data.Messages.Add(part.Trim());
            }

            List<string> filtered = new List<string>();
            List<string> transformed = new List<string>();

            Console.WriteLine("\nЗапуск конвейера (объединённое действие: вывод на экран):");
            foreach (string msg in data.Messages)
            {
                if (processor.IsLongEnough(msg))
                {
                    filtered.Add($"\"{msg}\"");
                    string trans = processor.Transform(msg);
                    transformed.Add($"\"{trans}\"");

                    processor.CombinedAction(trans);
                }
            }
            Console.WriteLine("\n");

            Console.WriteLine("Действие: отфильтрованные (длиннее 3 символов)");
            Console.WriteLine($"Ожидаемый результат: {string.Join(", ", filtered)}\n");

            Console.WriteLine("Действие: после преобразования");
            Console.WriteLine($"Ожидаемый результат: {string.Join(", ", transformed)}\n");

            Console.WriteLine("Действие: объединённое действие");
            Console.WriteLine($"Ожидаемый результат: значения выведены на экран И сохранены в списке ({data.History.Count} элемента)\n");

            Console.WriteLine(new string('-', 50) + "\n");
        }
    }
}