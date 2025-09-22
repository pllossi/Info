namespace Plates
{
    public class Dish : IComparable<Dish>
    {
        public enum COURSE
        {
            Appetizer,
            First,
            Second,
            Side,
            Dessert
        }
        public string Name { get; private set; }
        public COURSE Course { get; private set; }
        public double Price { get; private set; }
        public Restaurant Restaurant { get; private set; }
        public Dish(string name, COURSE course, double price, Restaurant restaurant)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name), "name cant be null or empty.");
            }

            if (price < 0.0)
            {
                throw new ArgumentOutOfRangeException(nameof(price), "price cant be negative.");
            }

            if (string.IsNullOrEmpty(restaurant.Name))
            {
                throw new ArgumentNullException(nameof(restaurant.Name), "restaurant cant be null.");
            }

            if (!Enum.IsDefined(typeof(COURSE), course))
            {
                throw new ArgumentException("Invalid type of course", nameof(course));
            }

            Name = name;
            Course = course;
            Price = price;
            Restaurant = restaurant;
        }

        public int CompareTo(Dish? Other)
        {
            if (Other == null)
            {
                return 1;
            }

            if (Course.CompareTo(Other.Course) != 0)
            {
                return Course.CompareTo(Other.Course);
            }
            else
            {
                return Name.CompareTo(Other.Name) != 0 ? Name.CompareTo(Other.Name) : Name.CompareTo(Other.Price);
            }
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Dish)
            {
                return false;
            }

            if (obj == null)
            {
                return false;
            }

            Dish other = (Dish)obj;
            return Name.Equals(other.Name) &&
                   Restaurant.Name.CompareTo(other.Restaurant.Name) == 0;
        }
        public override int GetHashCode() => throw new NotImplementedException();
    }
}
