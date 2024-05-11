using lab12_2;
using LibraryLab10;
namespace lab12_2;

class Program
{
    static void Main(string[] args)
    {
        MyHashTable<MusicalInstrument> table = new MyHashTable<MusicalInstrument>();
        int answer = 1;
        while (answer != 6)
        {
            try
            {
                PrintMenu();
                answer = IsInt(1, 6);
                switch (answer)
                {
                    case 1:
                        Console.WriteLine("Размер таблицы? (от 10 до 100)");
                        int size = IsInt(10, 100);
                        CreateTable(size, table);
                        break;
                    case 2:
                        table.PrintTable();
                        break;
                    case 3:
                        MusicalInstrument musicalForSearch = new MusicalInstrument();
                        Console.WriteLine("Введите объект для поиска");
                        musicalForSearch.Init();
                        Console.WriteLine("Таблица содержит данный объект объект: " + table.ContainsKey(musicalForSearch));
                        break;
                    case 4:
                        MusicalInstrument musicalForRemove = new MusicalInstrument();
                        Console.WriteLine("Введите объект для удаления");
                        musicalForRemove.Init();
                        if (table.RemoveByKey(musicalForRemove) == false)
                            Console.WriteLine("Элемент не найден в таблице");
                        else
                            Console.WriteLine("Удаление прошло успешно");
                        break;
                    case 5:
                        Console.WriteLine("Добавим в таблицу случайный элемент");
                        MusicalInstrument musicalForAdd = new MusicalInstrument();
                        musicalForAdd.RandomInit();
                        table.AddPoint(musicalForAdd);
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }

    static void PrintMenu()
    {
        Console.WriteLine("1. Создать таблицу");
        Console.WriteLine("2. Напечатать таблицу");
        Console.WriteLine("3. Поиск в таблице");
        Console.WriteLine("4. Удаление в таблице");
        Console.WriteLine("5. Добавление в таблицу");
        Console.WriteLine("6. Выход");
    }

    static int IsInt(int min, int max) //функция для проверки на Int (параметры - минимальное и максимальное значение)
    {
        bool isConvert;
        int number;
        do
        {
            string buf = Console.ReadLine();
            isConvert = int.TryParse(buf, out number);
            if (!isConvert || number < min || number > max)
            {
                Console.WriteLine($"Неправильно введено число. Введите значение от {min} до {max}");
            }
        } while (!isConvert || number < min || number > max);
        return number;
    }

    static void CreateTable(int size, MyHashTable<MusicalInstrument> table)
    {
        Console.WriteLine("Введите 1, чтобы заполнить таблицу случайным образом" +
            "\nВведите 2, чтобы заполнить таблицу вручную");
        int choice = IsInt(1, 2);
        if (choice == 1)
        {
            for (int i = 0; i < size; i++)
            {
                MusicalInstrument musicalForAdd = new MusicalInstrument();
                musicalForAdd.RandomInit();
                table.AddPoint(musicalForAdd);
            }
            table = new MyHashTable<MusicalInstrument>(size);
        }
        else
        {
            for (int i = 0; i < size; i++)
            {
                MusicalInstrument musicalForAdd = new MusicalInstrument();
                musicalForAdd.Init();
                table.AddPoint(musicalForAdd);
            }
        }
        Console.WriteLine("Таблица создана");
    }
}

