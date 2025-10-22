namespace Domain.Entities
{
    public class Adoption
    {
        private Cat _cat;
        private Adopter _adopter;
        public Cat Cat
        {
            get => _cat;
            private set
            {
                _cat = value ?? throw new ArgumentNullException(nameof(value));
            }
        }

        public Adopter Adopter
        {
            get => _adopter;
            private set
            {
                _adopter = value ?? throw new ArgumentNullException(nameof(value));
            }
        }
        public DateTime AdoptionDate { get; private set; }

        public Adoption(Adopter adopter, Cat cat, DateTime adoptionDate)
        {
            Adopter = adopter;
            Cat = cat;
            AdoptionDate = adoptionDate;
        }
    }
}
