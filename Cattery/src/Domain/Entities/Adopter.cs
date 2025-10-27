using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Adopter
    {
        private string _name;
        private string _surname;
        private PhoneNumber _phone;
        private Email _email;
        private TaxId _taxId;
        private string _postalCode;
        private string _city;

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public string Surname
        {
            get => _surname;
            set => _surname = value;
        }

        public PhoneNumber Phone
        {
            get => _phone;
            set => _phone = value;
        }

        public Email Email
        {
            get => _email;
            set => _email = value;
        }

        public TaxId TaxId
        {
            get => _taxId;
            set => _taxId = value;
        }

        public string PostalCode
        {
            get => _postalCode;
            set => _postalCode = value;
        }

        public string City
        {
            get => _city;
            set => _city = value;
        }

        public Adopter(string name, string surname, PhoneNumber? phone, Email? email, TaxId taxId)
        {
            Name = name;
            Surname = surname;
            Phone = phone ?? throw new ArgumentNullException(nameof(phone));
            Email = email ?? throw new ArgumentNullException(nameof(email));
            TaxId = taxId ?? throw new ArgumentNullException(nameof(taxId));
        }

        public override string ToString()
        {
            return $"{Name} {Surname}, Phone: {Phone}, Email: {Email}, TaxId: {TaxId}, PostalCode: {PostalCode}, City: {City}";
        }
    }
}
