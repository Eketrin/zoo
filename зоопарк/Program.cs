﻿using System;
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
        public int SumOfAnimalsNow { get; set; }
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
                Console.WriteLine($"Животное нельзя поместить в этот вольер, тут живёт {animal[0].NameOfAnimal}");
            }
            SumOfAnimalsNow = animal.Count;
        }
        public void DelAnimal(int ccc) //убрать животное из клетки
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
            if (innerCletka.animal.Count == 0)
            {
                Console.WriteLine($"{outCletka.animal[ccc - 1].NameOfAnimal} переведен/а в новый вольер");
                innerCletka.addAnimal(outCletka.animal[ccc - 1]);
                outCletka.DelAnimal(ccc);
            }
            else if (outCletka.animal[ccc - 1].NameOfAnimal == innerCletka.animal[0].NameOfAnimal)
            {
                Console.WriteLine($"{outCletka.animal[ccc - 1].NameOfAnimal} переведен/а в вольер к сородичам");
                innerCletka.addAnimal(outCletka.animal[ccc - 1]);
                outCletka.DelAnimal(ccc);
            }
            else
            {
                Console.WriteLine($"Животное нельзя поместить в этот вольер");
                Console.WriteLine($"{outCletka.animal[ccc - 1].NameOfAnimal} и {innerCletka.animal[0].NameOfAnimal} не могут жить вместе!");
            }
            /*
            innerCletka.addAnimal(outCletka.animal[ccc - 1]);
            outCletka.DelAnimal(ccc); */
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
            //создаём животных
            Bird bird1 = new Bird("Какаду", false, 20);
            Bird bird2 = new Bird("Какаду", false, 15);
            Fish fish1 = new Fish("Рыба-клоун", false, false);
            Fish fish2 = new Fish("Рыба-клоун", false, false);
            Fish fish3 = new Fish("Акула", true, false);
            Beast beast1 = new Beast("Олень", false, "Лес");
            Beast beast2 = new Beast("Лев", true, "Саванна");

            // создание зоопарка
            Zoo zoo = new Zoo("Московский");

            //информация о животных
            bird1.GenerateADescription();
            Console.WriteLine();
            fish2.GenerateADescription();
            Console.WriteLine();
            beast2.GenerateADescription();
            Console.WriteLine();

            //создаём клетки
            HouseOfAnimal cage1 = new HouseOfAnimal("птицы", 21, 55, 15); 
            HouseOfAnimal cage2 = new HouseOfAnimal("рыбы", 21, 55, 15);
            HouseOfAnimal cage3 = new HouseOfAnimal("хищные рыбы", 21, 55, 15);
            HouseOfAnimal cage4 = new HouseOfAnimal("олени", 21, 55, 15);
            HouseOfAnimal cage5 = new HouseOfAnimal("львы", 21, 55, 15);

            //добавляем клетки в зоопарк
            zoo.AddCage(cage1); 
            zoo.AddCage(cage2);
            zoo.AddCage(cage3);
            zoo.AddCage(cage4);
            zoo.AddCage(cage5);

            //добавляем в животных в клетки
            cage1.addAnimal(bird1);
            cage1.addAnimal(bird2);
            cage2.addAnimal(fish1);
            cage2.addAnimal(fish2);
            cage3.addAnimal(fish3);
            cage4.addAnimal(beast1);
            cage5.addAnimal(beast2);

            //пытаемся подселить какаду к рыбе и льва к оленю
            cage1.TransferAnimal(cage1, cage2, 1);
            Console.WriteLine();
            cage5.TransferAnimal(cage5, cage4, 1);
            Console.WriteLine();

            //создаём клетку с акулой и переносим акулу к её сородичам в другую клетку
            Fish fish4 = new Fish("Акула", true, false);
            HouseOfAnimal cage6 = new HouseOfAnimal("хищные рыбы", 21, 55, 15);
            cage6.addAnimal(fish4);
            cage6.TransferAnimal(cage6 , cage3, 1);
            Console.WriteLine();


            //создаём новый вольер и переводм туда оленя
            HouseOfAnimal cageolen = new HouseOfAnimal("олени", 21, 55, 15);
            cage4.TransferAnimal(cage4, cageolen, 1);
            Console.ReadLine();
        }
    }
}

