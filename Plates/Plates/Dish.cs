using System.Globalization;

namespace Plates
{
    public class Dish
    {
        private string dishName;
        public string DishName
        {
            get
            {
                return dishName;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("DishName has to have something, not empty");
                }
                dishName = value;
            }
        }

        private string resturantName;
        public string ResturantName
        {
            get
            {
                return resturantName;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("ResturantName has to have something, not empty");
                }
                resturantName = value;
            }
        }

        private int price;
        public int Price
        {
            get
            {
                return price;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new Exception("Price must be greater than zero");
                }
                price = value;
            }
        }

        public DishType TypeDish { get; private set; }

        public Dish(string name, string resturant, int price, DishType dish)
        {
            DishName = name;
            ResturantName = resturant;
            Price = price;
            TypeDish = dish;
        }
        public override bool Equals(object? obj)
        {
            if(obj is null)
            {
                return false;
            }
            if(obj is not Dish)
            {
                return false;
            }
            Dish objDish = obj as Dish;
            if (objDish.DishName == dishName)
            { 
                if(objDish.Price == price)
                {
                    if (objDish.ResturantName == resturantName)
                        return true;
                }
            }
            return false;
        }
    }
}
