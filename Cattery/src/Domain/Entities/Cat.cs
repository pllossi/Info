using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
    public class Cat
    {
        private static HashSet<string> GeneratedCodes = new HashSet<string>();

        public Cat(string name = "", string breed = "", bool male = true, string? description = null, DateTime? exitDate = null, DateTime? birthDate = null)
        {
            Name = name;
            Breed = breed;
            Male = male;
            Description = description;
            ExitDate = exitDate;
            BirthDate = birthDate;
            CodeId = CreateCodeId();
        }

        public string Name
        {
            get => _name;
            private set
            {
                if (value == "" || value == " ") { throw new ArgumentException(); }
                _name = value;
            }
        }

        public DateTime ShelterArrivalDate
        {
            get => _shelterArrivalDate;
            set
            {
                if (ExitDate.HasValue && value > ExitDate.Value)
                {
                    throw new ArgumentException("The arrival date cannot be later than the exit date.");
                }
                _shelterArrivalDate = value;
            }
        }

        private DateTime _shelterArrivalDate = DateTime.Now;

        public string Breed
        {
            get => _breed;
            private set
            {
                if (value == "" || value == " ") { throw new ArgumentException(); }
                _breed = value;
            }
        }

        public bool Male
        {
            get;
            private set;
        }

        private string _name = string.Empty;

        private string _breed = string.Empty;

        private string? _description = "";

        public string? Description
        {
            get => _description;
            set
            {
                if (value == "" || value == " ") { throw new ArgumentException(); }
                _description = value;
            }
        }
        private DateTime? _exitDate = null;
        public DateTime? ExitDate
        {
            get => _exitDate;
            set
            {
                if (value.HasValue && value > ShelterArrivalDate)
                {
                    throw new ArgumentException("The exit date cannot be earlier than the arrival date.");
                }
                _exitDate = value;
            }
        }
        private DateTime? _birthDate = null;
        public DateTime? BirthDate
        {
            get => _birthDate;
            set => _birthDate = value;
        }

        public string CodeId = "";

        private string CreateCodeId()
        {
            var rnd = new Random();
            string code;
            do
            {
                int number = rnd.Next(10000, 99999);
                char firstLetterOfMonth = ShelterArrivalDate.ToString("MMM")[0];
                string year = ShelterArrivalDate.Year.ToString();
                string randomLetters = new string(Enumerable.Range(0, 3)
                    .Select(_ => (char)rnd.Next(65, 91)).ToArray());
                code = $"{number}{firstLetterOfMonth}{year}{randomLetters}";
            } while (!GeneratedCodes.Add(code));

            return code;
        }
    }
}
