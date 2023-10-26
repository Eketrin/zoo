using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace зоопарк
{
    class Zoo
    {
        public string Name { get; set; }
        public Zoo(string Name)
        {
            this.Name = Name;
        }

        public List<HouseOfAnimal> Cage = new List<HouseOfAnimal>(); //список клеток
        public void AddCage(HouseOfAnimal aaa) //добавляет клетку в зоопарк
        {
            Cage.Add(aaa);
        }
        public string WhichAnimalINCage(int chis) //вывод кто в клетке
        {
            if ((chis - 1) < Cage.Count)
            {
                return Cage[chis - 1].Name;
            }
            else
            {
                return "Такой клетки нет";
            }
        }
    }

    class HouseOfAnimal
    {
        public string Name { get; set; }
        public int Number { get; set; }
        public int Size { get; set; }
        public int MaxSumOfAnimals { get; set; }
        public int SumOfAnimalsNow {  get; set; }
        
        public HouseOfAnimal(string Name, int Number, int Size, int MaxSumOfAnimals)
        {
            this.Name = Name;
            this.Number = Number;
            this.Size = Size;
            this.MaxSumOfAnimals = MaxSumOfAnimals;
            

        }
        public List<Animal> animal = new List<Animal>();
        public void addAnimal(Animal bbb)
        {

            if (animal.Count==0)
            {
                animal.Add(bbb);
            }
            else if (bbb.NameOfAnimal == animal[0].NameOfAnimal)
            {
                animal.Add(bbb);
            }
            else 
            {
                Console.WriteLine("Животное нельзя поместить в этот вольер");
            }
            SumOfAnimalsNow = animal.Count;
        }
        public void DelAnimal(int ccc) //удалить животное
        {
            if ((ccc - 1) < animal.Count)
            {
                animal.RemoveAt(ccc-1);
            }
            else
            {
                Console.WriteLine("Такого животного нет");
            }
        }
        public void TransferAnimal( HouseOfAnimal outCletka, 
            HouseOfAnimal innerCletka, int ccc) //перенос животного в другую клетку
        {
            innerCletka.addAnimal(outCletka.animal[ccc - 1]);
            outCletka.DelAnimal(ccc);
        }
        public string WhichAnimal(int chis) //вывод кто в клетке
        {
            if ((chis -1) < animal.Count)
            {
                return animal[chis-1].NameOfAnimal;
            }
            else
            {
                return "Такой клетки нет";
            }
        }
    }
    abstract class Animal
    {
        public string NameOfAnimal { get; set; }
        public bool Hishnik { get; set; }
        public Animal(string NameOfAnimal, bool Hishnik)
        {
            this.NameOfAnimal = NameOfAnimal;
            this.Hishnik = Hishnik;
        }
        abstract public void GenerateADescription();
    }
    class Fish : Animal
    {
        public bool Deepwater { get; set; }

        public Fish(string NameOfAnimal, bool Hishnik, bool Deepwater) : base(NameOfAnimal, Hishnik)
        {
            this.Deepwater = Deepwater;
        }
        public override void GenerateADescription()
        {
            if (Deepwater)
            {
                Console.WriteLine($"Класс: глубоководная рыба");
            }
            else
            {
                Console.WriteLine($"Класс: не глубоководная рыба");
            }
            Console.WriteLine($"Название: {NameOfAnimal}");
            if (Hishnik)
            {
                Console.WriteLine($"Хищник: Да");
            }
            else
            {
                Console.WriteLine($"Хищник: Нет");
            }

        }
    }
    class Bird : Animal
    {
        public double FlightSpeed { get; set; }
        public Bird(string NameOfAnimal, bool Hishnik, double FlightSpeed) : base(NameOfAnimal, Hishnik)
        {
            this.FlightSpeed = FlightSpeed;
        }
        public override void GenerateADescription()
        {
            Console.WriteLine($"Класс: птица");
            Console.WriteLine($"Название: {NameOfAnimal}");
            if (Hishnik)
            {
                Console.WriteLine($"Хищник: Да");
            }
            else
            {
                Console.WriteLine($"Хищник: Нет");
            }
            Console.WriteLine($"Скорость полёта: {FlightSpeed} км/ч");
        }

    }

    class Beast : Animal
    {
        public string Area { get; set; }
        public Beast(string NameOfAnimal, bool Hishnik, string Area) : base(NameOfAnimal, Hishnik)
        {
            this.Area = Area;
        }
        public override void GenerateADescription()
        {
            Console.WriteLine($"Класс: зверь");
            Console.WriteLine($"Название: {NameOfAnimal}");
            if (Hishnik)
            {
                Console.WriteLine($"Хищник: Да");
            }
            else
            {
                Console.WriteLine($"Хищник: Нет");
            }
            Console.WriteLine($"Среда обитания: {Area}");

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Bird animal = new Bird("Какаду", false, 20);
            Bird animal2 = new Bird("Какаду", false, 15);
            animal.GenerateADescription();
            Zoo zoo = new Zoo("esdsad");
            HouseOfAnimal cage1 = new HouseOfAnimal("птицы", 21, 55, 15);
            zoo.AddCage(cage1);
            HouseOfAnimal cage2 = new HouseOfAnimal("птицы2", 21, 55, 15);
            zoo.AddCage(cage2);
            cage1.addAnimal(animal);
            cage1.addAnimal(animal2);
            //cage1.TransferAnimal(cage1, cage2, 1);
            //Console.WriteLine(cage2.animal[0].NameOfAnimal);
            Console.WriteLine(cage1.SumOfAnimalsNow);
            Console.WriteLine(cage1.WhichAnimal(1));

            Console.ReadLine();
        }
    }
}

