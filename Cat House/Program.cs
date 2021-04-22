using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cat_House
{
    class Cats
    {
        public string NickName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public int Energy { get; set; } = 100;
        public double Price { get; set; }
        public int mealQuantity { get; set; }

        public void Eat()
        {
            Energy += 50;
            Price += 50;
        }
        public void Sleep()
        {
            Energy += 50;
        }
        public void Play()
        {
            if (Energy == 0)
            {
                Sleep();
            }
            else
            {
                Energy -= 50;
            }
            if (Energy < 0)
            {
                Energy = 0;
            }
        }
        public void Show()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine();
            Console.WriteLine("======Cats Info=======");
            Console.WriteLine($"NickName: {NickName}");
            Console.WriteLine($"Age: {Age}");
            Console.WriteLine($"Gender: {Gender}");
            Console.WriteLine($"Energy: {Energy}");
            Console.WriteLine($"Price: {Price}");
            Console.WriteLine($"Meal Quantity: {mealQuantity}");
            Console.WriteLine();
        }
    }
    class CatHouse
    {
        public string Name { get; set; }
        public Cats[] cats { get; set; }
        public int CatCount { get; set; }
        public void AddCat(ref Cats cat)
        {
            Cats[] temp = new Cats[++CatCount];
            if (cats != null)
            {
                cats.CopyTo(temp, 0);
            }
            temp[temp.Length - 1] = cat;
            cats = temp;
        }
        public void RemoveByNickName(string name)
        {
            Cats[] deletedCats = new Cats[--CatCount];
            for (int i = 0; i < CatCount; i++)
            {
                if (name != cats[i].NickName)
                {
                    deletedCats[i] = cats[i];
                }
                else
                {
                    for (int k = i, k2 = i + 1; k < CatCount; k++, k2++)
                    {
                        deletedCats[k] = cats[k2];
                    }
                }
            }
            cats = deletedCats;


        }
        public decimal CalCulateMealQuantity()
        {
            decimal sum = 0;
            foreach (var item in cats)
            {
                sum += item.mealQuantity;
            }
            return sum;
        }
        public double CalculateCatPrice()
        {
            double sum = 0;
            foreach (var item in cats)
            {
                sum += item.Price;
            }
            Console.WriteLine($"Total Price : {sum}");
            return sum;

        }


        public void ShowCats()
        {
            Console.WriteLine("========Cat House Info======");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Cat House Name : {Name}");
            Console.WriteLine($"Cat Count: {CatCount}");
            if (cats != null)
            {
                foreach (var item in cats)
                {
                    item.Show();
                }
            }
        }


    }
    class PetShop
    {
        public CatHouse[] catHouses { get; set; }
        public int CatHouseCount { get; set; }

        public void ShowCatHouse()
        {
            foreach (var item in catHouses)
            {
                item.ShowCats();
            }
            Console.WriteLine($"Cat House Count: {CatHouseCount}");
        }
        public void addHouse(ref CatHouse catHouse)
        {
            CatHouse[] newCatHouse = new CatHouse[++CatHouseCount];
            if (catHouses != null)
            {
                catHouses.CopyTo(newCatHouse, 0);
            }
            newCatHouse[newCatHouse.Length - 1] = catHouse;
            catHouses = newCatHouse;

        }
        public void CalculateMealQuntity()
        {
            decimal sum = 0;
            foreach (var item in catHouses)
            {
                sum += item.CalCulateMealQuantity();
            }
            Console.WriteLine($"Total PetShop Quantity : {sum}");
        }
        public void CalcualtePrice()
        {
            double sum1 = 0;
            foreach (var item in catHouses)
            {
                sum1 += item.CalculateCatPrice();
            }
            Console.WriteLine($"Total PetShop Price :{sum1} ");

        }


    }
    class Program
    {
        static void Main(string[] args)
        {
            Cats cats = new Cats
            {
                NickName = "Tom",
                Age = 3,
                Gender = "Male",
                Price = 300,
                mealQuantity = 100

            };
            Cats cats2 = new Cats
            {
                NickName = "Garfield",
                Age = 10,
                Gender = "Male",
                Price = 500,
                mealQuantity = 200

            };
            Cats cats3 = new Cats
            {
                NickName = "Leo",
                Age = 10,
                Gender = "Male",
                Price = 500,
                mealQuantity = 200

            };
            Cats cats4 = new Cats
            {
                NickName = "Bella",
                Age = 10,
                Gender = "FeMale",
                Price = 500,
                mealQuantity = 200

            };
            Console.WriteLine();
            CatHouse catHouse = new CatHouse() { Name = "Prewdy House" };
            CatHouse catHouse1 = new CatHouse() { Name = "Nice House" };
            catHouse.AddCat(ref cats);
            catHouse.AddCat(ref cats2);
            catHouse1.AddCat(ref cats3);
            catHouse1.AddCat(ref cats4);
            Console.WriteLine();
            //Console.WriteLine("===========After Remove=============");
            PetShop petShop = new PetShop();
            petShop.addHouse(ref catHouse);
            petShop.addHouse(ref catHouse1);
            petShop.ShowCatHouse();
            petShop.CalcualtePrice();
            petShop.CalculateMealQuntity();
            //catHouse.RemoveByNickName("Tom");
            //catHouse.ShowCats();









        }
    }
}
