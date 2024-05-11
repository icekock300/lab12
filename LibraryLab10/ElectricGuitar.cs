using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryLab10
{
    public class ElectricGuitar : Guitar
    {
        protected string PowerSource { get; set; } //автосвойство для источника питания

        public ElectricGuitar() : base() //конструктор без параметров
        {
            PowerSource = "";
        }

        public ElectricGuitar(string instrumentName, IdNumber id, int numberOfGuitarStrings, string powerSource) : base(instrumentName, id, numberOfGuitarStrings) //конструктор с параметрами
        {
            NumberOfGuitarStrings = numberOfGuitarStrings;
            PowerSource = powerSource;
        }

        [ExcludeFromCodeCoverage]
        public override void ShowVirtual() //виртуальный метод вывода объекта
        {
            base.ShowVirtual();
            Console.WriteLine($"источник питания электрогитары: {PowerSource}");
        }

        [ExcludeFromCodeCoverage]
        public void Show() //невиртуальный метод вывода объекта
        {
            base.Show();
            Console.WriteLine($"источник питания электрогитары: {PowerSource}");
        }


        public override bool Equals(object obj) //метод для сравнивания объектов
        {
            if (obj == null) return false;
            if (obj is not ElectricGuitar) return false;
            return ((ElectricGuitar)obj).InstrumentName == this.InstrumentName && ((ElectricGuitar)obj).PowerSource == this.PowerSource;
        }

        public override void RandomInit() //инициализация объекта с помощью ДСЧ
        {
            base.RandomInit();
            InstrumentName = "электрогитара";
            string[] lines = {
                "батарейки",
                "аккумуляторы",
                "фиксированный источник питания",
                "USB"
            };

            Random rnd = new Random();

            PowerSource = lines[rnd.Next(lines.Length)];

            id.Id = rnd.Next(0, 100);
        }

        public string GetPowerSource() //метод, возвращающий источник питания
        {
            return PowerSource;
        }

        [ExcludeFromCodeCoverage]
        public override string ToString()
        {
            return base.ToString() + $" источник питания электрогитары: {PowerSource}";
        }

        [ExcludeFromCodeCoverage]
        public override void Init() //инициализация объекта с клавиатуры
        {
            InstrumentName = "электрогитара";
            Console.WriteLine("Введите количество струн электрогитары:");
            try
            {
                NumberOfGuitarStrings = int.Parse(Console.ReadLine());
            }
            catch
            {
                NumberOfGuitarStrings = 15;
            }
            Console.WriteLine("Введите источник питания электрогитары:");
            Console.ReadLine();

            Console.WriteLine("Введите id:");
            try
            {
                id.Id = int.Parse(Console.ReadLine());
            }
            catch
            {
                id.Id = 0;
            }
        }
    }
}
