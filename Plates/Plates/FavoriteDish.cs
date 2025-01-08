using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plates
{
    public class FavoriteDish
    {
        private Dish[] _dishes;
        public FavoriteDish(int platesToMem = 1)
        {
            _dishes = new Dish[platesToMem];
        }
        public void insertDish(Dish dish)
        {
            for (int i = 0; i < _dishes.Length; i++)
            {
                if (_dishes[i] == null)
                {
                    foreach(Dish realDish in _dishes)
                    {
                        if (realDish.Equals(dish)) 
                            throw new Exception("Plate already saved");
                        else
                        {
                            _dishes[i] = dish;
                            return;
                        }
                    }
                }
            }
            throw new Exception("No more space for dishes");
        }
        public void insertDish(string name, string resturant, int price, DishType dish)
        {
            insertDish(new Dish(name, resturant, price, dish));
        }
        public Dish[] lessExpensiveForType()
        {
            int cost = int.MaxValue;
            int pos = 0;
            Dish[] lessExpensive = new Dish[5];
            for (int i = 0; i < _dishes.Length; i++)
            {
                if (_dishes[i].TypeDish == DishType.Appetizer)
                {
                    if (_dishes[i].Price < cost)
                    {
                        cost = _dishes[i].Price;
                        pos = i;
                    }
                }
            }
            lessExpensive[0] = _dishes[pos];
            cost = int.MaxValue;
            for (int i = 0; i < _dishes.Length; i++)
            {
                if (_dishes[i].TypeDish == DishType.MainCourse)
                {
                    if (_dishes[i].Price < cost)
                    {
                        cost = _dishes[i].Price;
                        pos = i;
                    }
                }
            }
            lessExpensive[1] = _dishes[pos];
            cost = int.MaxValue;
            for (int i = 0; i < _dishes.Length; i++)
            {
                if (_dishes[i].TypeDish == DishType.SecondCourse)
                {
                    if (_dishes[i].Price < cost)
                    {
                        cost = _dishes[i].Price;
                        pos = i;
                    }
                }
            }
            lessExpensive[2] = _dishes[pos];
            cost = int.MaxValue;
            for (int i = 0; i < _dishes.Length; i++)
            {
                if (_dishes[i].TypeDish == DishType.SideCourse)
                {
                    if (_dishes[i].Price < cost)
                    {
                        cost = _dishes[i].Price;
                        pos = i;
                    }
                }
            }
            lessExpensive[3] = _dishes[pos];
            cost = int.MaxValue;
            for (int i = 0; i < _dishes.Length; i++)
            {
                if (_dishes[i].TypeDish == DishType.Dessert)
                {
                    if (_dishes[i].Price < cost)
                    {
                        cost = _dishes[i].Price;
                        pos = i;
                    }
                }
            }
            lessExpensive[4] = _dishes[pos];
            return lessExpensive;
        }
        public int resturantsMoreThan1World()
        {
            int count = 0;
            for (int i = 0; i < _dishes.Length; i++)
            {
                if (_dishes[i].ResturantName.Split(' ').Length > 1)
                {
                    count++;
                }
            }
            return count;
        }
        public Dish LongestName()
        {
            int lMax = int.MinValue;
            int pos = -1;
            for (int i = 0; i < _dishes.Length; i++)
            {
                if (_dishes[i].DishName.Length > lMax)
                {
                    lMax = _dishes[i].DishName.Length;
                    pos = i;
                }
            }
            return _dishes[pos];
        }
        public Dish?[] DishesResturant(string resturant)
        {
            bool resturantFound = false;
            if (resturant == null || resturant == " " || resturant == "")
            {
                throw new Exception("Resturant name can't be null or blank");7
            }
            Dish[] dishes = new Dish[_dishes.Length];
            for (int i = 0; i < _dishes.Length; i++)
            {
                if (_dishes[i].ResturantName == resturant)
                {
                    resturantFound = true;
                    dishes[i] = _dishes[i];
                }
            }
            if (resturantFound)
            {
                return dishes;
            }
            else
            {
                return null;
            }
        }
    }
}
