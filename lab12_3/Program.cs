using lab12_3;
using LibraryLab10;
namespace lab12_3;

class Program
{
    static void Main(string[] args)
    {
        MyTree<MusicalInstrument> tree = null;
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
                        Console.WriteLine("Введите количество элементов в дереве:");
                        int length = IsInt(1, 100);
                        tree = new MyTree<MusicalInstrument>(length);
                        Console.WriteLine("Дерево успешно создано.");
                        break;
                    case 2:
                        tree.ShowTree();
                        break;
                    case 3:
                        MusicalInstrument minInstrument = tree.FindMin();
                        Console.WriteLine("Минимальный элемент:");
                        minInstrument.Show();
                        break;
                    case 4:
                        Console.WriteLine("Дерево до преобразования:");
                        tree.ShowTree();

                        tree.TransformToFindTree();

                        Console.WriteLine("\nДерево после преобразования в дерево поиска:");
                        tree.ShowTree();
                        break;
                    case 5:
                        
                        break;
                    case 6:
                        tree.RemoveTree();
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
        Console.WriteLine("1. Создать ИСД");
        Console.WriteLine("2. Напечатать дерево");
        Console.WriteLine("3. Поиск минимального элемента в ИСД");
        Console.WriteLine("4. Преобразовать ИСД в дерево поиска");
        Console.WriteLine("5. Удалить из дерева поиска элемент с заданным ключом");
        Console.WriteLine("6. Удалить дерево и выйти");
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

