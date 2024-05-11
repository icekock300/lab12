using LibraryLab10;
namespace lab12;

class Program
{
    static void Main(string[] args)
    {
        MyList<MusicalInstrument> list = new MyList<MusicalInstrument>();
        int answer = 1;
        while (answer != 7)
        {
            try
            {
                PrintMenu();
                answer = IsInt(1, 7);
                switch (answer)
                {
                    case 1:
                        Console.WriteLine("Размер списка? (от 0 до 100)");
                        int size = IsInt(0, 100);
                        list = new MyList<MusicalInstrument>(size);
                        Console.WriteLine("Список создан");
                        break;
                    case 2:
                        list.PrintList();
                        break;
                    case 3:
                        Console.WriteLine("Введите '1', если хотите найти элемент по id");
                        Console.WriteLine("Введите '2', если хотите найти элемент по названию инструмента");
                        int choice = IsInt(1, 2);
                        if (choice == 1)
                        {
                            int idChoice = IsInt(0, 100);
                            IdNumber idNumberToDelete = new IdNumber(idChoice);
                            list.RemoveLastItemWithSpecifiedData(x => (x as MusicalInstrument)?.Id, idNumberToDelete);

                        }

                        else
                        {
                            string nameChoice = Console.ReadLine();
                            list.RemoveLastItemWithSpecifiedData(x => (x as MusicalInstrument)?.InstrumentName, nameChoice);

                        }
                        break;
                    case 4:
                        Console.WriteLine("Введите '1', если хотите найти элемент по id");
                        Console.WriteLine("Введите '2', если хотите найти элемент по названию инструмента");
                        int choiceForAdd = IsInt(1, 2);
                        if (choiceForAdd == 1)
                        {
                            int idChoice = IsInt(0, 100);
                            IdNumber idNumberToDelete = new IdNumber(idChoice);
                            MusicalInstrument musicalForAdd = new MusicalInstrument();
                            musicalForAdd.RandomInit();
                            list.AddLastItemWithSpecifiedData(x => (x as MusicalInstrument)?.Id, idNumberToDelete);

                        }

                        else
                        {
                            string nameChoice = Console.ReadLine();
                            MusicalInstrument musicalForAdd = new MusicalInstrument();
                            musicalForAdd.RandomInit();
                            list.AddLastItemWithSpecifiedData(x => (x as MusicalInstrument)?.InstrumentName, nameChoice);


                        }
                        break;
                    case 5:
                        MyList<MusicalInstrument> clonedList = list.Clone(); // создание глубокой копии списка
                        clonedList.PrintList();
                        break;
                    case 6:
                        list.Clear();
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
        Console.WriteLine("1. Создать список");
        Console.WriteLine("2. Напечатать список");
        Console.WriteLine("3. Удалить из списка последний элемент с заданным инф. полем");
        Console.WriteLine("4. Добавить в список элемент после элемента с заданным инф. полем");
        Console.WriteLine("5. Склонировать список");
        Console.WriteLine("6. Удалить список");
        Console.WriteLine("7. Выход");
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
}

