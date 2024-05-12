using LibraryLab10;
namespace lab12_4;

class Program
{
    static void Main(string[] args)
    {
        MyCollection<MusicalInstrument> collection = new MyCollection<MusicalInstrument>();
        int answer = 1;
        while (answer != 8)
        {
            try
            {
                PrintMenu();
                answer = IsInt(1, 8);
                switch (answer)
                {
                    case 1:
                        Console.WriteLine("Размер коллекции? (от 0 до 100)");
                        int size = IsInt(0, 100);
                        collection = new MyCollection<MusicalInstrument>(size);
                        Console.WriteLine("Список создан");
                        break;
                    case 2:
                        collection.PrintList();
                        break;
                    case 3:
                        Console.WriteLine("Введите 1, если хотите добавить один элемент в коллекцию" +
                            "\nВведите 2, если хотите добавить несколько элементов в коллекцию");
                        int choice = IsInt(1, 2);
                        if (choice == 1)
                        {
                            MusicalInstrument musicalForAdd = new MusicalInstrument();
                            musicalForAdd.RandomInit();
                            collection.Add(musicalForAdd);
                            Console.WriteLine("Элемент успешно добавлен");
                        }
                        else
                        {
                            Console.WriteLine("Введите число элементов, сколько вы хотите добавить (от 2 до 10)");
                            int forAdd = IsInt(1, 10);
                            List<MusicalInstrument> listForAdd = new List<MusicalInstrument>();
                            for (int i = 0; i < forAdd; i++)
                            {
                                MusicalInstrument musicalForAdd = new MusicalInstrument();
                                musicalForAdd.RandomInit();
                                listForAdd.Add(musicalForAdd);
                            }
                            collection.AddRange(listForAdd);
                            Console.WriteLine("Несколько элементов успешно добавлены");
                        }
                        break;
                    case 4:
                        Console.WriteLine("Введите 1, если хотите удалить один элемент из коллекции" +
                            "\nВведите 2, если хотите удалить несколько элементов из коллекции");
                        choice = IsInt(1, 2);
                        if (choice == 1)
                        {
                            MusicalInstrument musicalForRemove = new MusicalInstrument();
                            musicalForRemove.Init();
                            
                            if (collection.Contains(musicalForRemove))
                            {
                                collection.Remove(musicalForRemove);
                                Console.WriteLine("Элемент успешно удалён");
                            }
                            else
                                Console.WriteLine("Коллекция не содержит данного элемента");
                        }
                        else
                        {
                            Console.WriteLine($"Введите число элементов, сколько вы хотите удалить (от {2} до {collection.Count})");
                            int forRemove = IsInt(1, collection.Count);
                            List<MusicalInstrument> listForRemove = new List<MusicalInstrument>();
                            for (int i = 0; i < forRemove; i++)
                            {
                                MusicalInstrument musicalForAdd = new MusicalInstrument();
                                musicalForAdd.Init();
                                listForRemove.Add(musicalForAdd);
                            }
                            collection.RemoveRange(listForRemove);
                            Console.WriteLine("Несколько элементов успешно удалены");
                        }
                        break;
                    case 5:
                        Console.WriteLine("Введите элемент для поиска в коллекции");
                        MusicalInstrument musicalForFind = new MusicalInstrument();
                        musicalForFind.Init();
                        MusicalInstrument foundItem = collection.Find(item => item.Equals(musicalForFind));

                        if (foundItem != null)
                        {
                            Console.WriteLine("Элемент найден в коллекции"); 
                        }
                        else
                        {
                            Console.WriteLine("Элемент НЕ найден в коллекции");
                        }
                        break;
                    case 6:
                        MyCollection<MusicalInstrument> clonedCollection = collection.DeepCopy();
                        Console.WriteLine("Склонированная коллекция:");
                        clonedCollection.PrintList();
                        break;
                    case 7:
                        MyCollection<MusicalInstrument> copiedCollection = collection.ShallowCopy();
                        Console.WriteLine("Склонированная коллекция:");
                        copiedCollection.PrintList();
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
        Console.WriteLine("1. Создать коллекцию");
        Console.WriteLine("2. Напечатать коллекцию");
        Console.WriteLine("3. Добавить в коллекцию один или несколько элементов");
        Console.WriteLine("4. Удалить из коллекции один или несколько элементов");
        Console.WriteLine("5. Поиск элемента");
        Console.WriteLine("6. Глубокое копирование");
        Console.WriteLine("7. Поверхностное копирование");
        Console.WriteLine("8. Выход");
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
