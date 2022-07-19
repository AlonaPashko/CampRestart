using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task9
{
    internal class Menu
    {
        private List<Dish> dishes;

        public List<Dish> Dishes;

        public Dish this[int index]
        {
            get { return Dishes[index]; }
        }
        public int Length
        {
            get { return Dishes.Count; }
        }

        public Menu()
        {
            Dishes = new List<Dish>();
        }
        public Menu(List<Dish> dishes)
        {
            Dishes = dishes;
        }
        public Menu(string path)
        {
            if (File.Exists(path))
            {
                Dishes = SetDishes(path);
            }
            else
            {
                Dishes = new();
            }
        }
        public override string ToString()
        {
            return PrintMenu();
        }
        public string PrintMenu()
        {
            string line = "";
            for (int i = 0; i < Length; i++)
            {
                line += Dishes[i].Name + '\n';
            }
            return line;
        }
        private string ReadFromFile(string path)
        {
            StreamReader reader = new StreamReader(path);
            string line = "";
            while (!reader.EndOfStream)
            {
                line += reader.ReadLine() + "\n";
            }
            reader.Close();
            return line;
        }
        private string ReadOnlyDishesFromFile(string path)
        {
            string line = ReadFromFile(path);
            string[] array = line.Split('\n');

            string onlyDishes = array[0] + "\n";

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i - 1] == "")
                {
                    onlyDishes += array[i] + "\n";
                }
            }
            return onlyDishes;
        }
        private List<Dish> SetDishes(string path)
        {
            string line = ReadOnlyDishesFromFile(path);
            string[] array = line.Split("\n");
            
            List<Dish> dishesList = new List<Dish>();
            for (int i = 0; i < array.Length; i++)
            {
                Dish dish = new Dish();
                dish.Name = array[i];
                dishesList.Add(dish);
            }
            return dishesList;
        }

    }
}
