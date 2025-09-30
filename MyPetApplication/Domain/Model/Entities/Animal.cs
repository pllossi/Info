using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Entities
{
    public abstract class Animal
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("il nome non può essere nullo o vuoto");
                _name = value;
            }
        }

        private string? _favouriteGame;
        public string? FavouriteGame
        {
            get { return _favouriteGame; }
            set
            {
                if (value != null && string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Non può essere solo spazi bianchi");

                _favouriteGame = value;
            }
        }

        private string? _favouriteFood;
        public string? FavouriteFood
        {
            get { return _favouriteFood; }
            set
            {
                if (value != null && string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Non può essere solo spazi bianchi");

                _favouriteFood = value;
            }
        }

        /*
         * readonly protegge il riferimento alla lista, non il contenuto.
         * La mutabilità dei dati all’interno della lista è ancora
         * consentita.
         * Se fa parte dello stato mettiamo IReadOnlyList nella proprietà
         * Come il val in Kotlin sugli array
         */
        private readonly List<VeterinaryVisit> _visitList;
        public IReadOnlyList<VeterinaryVisit> VisitList => _visitList;


        // Costruttore che riceve la lista
        public Animal(string name, List<VeterinaryVisit> visits = null, string favouriteFood = null, string favouriteGame=null)
        {
            // qui è perfettamente valido assegnare il campo readonly perchè siamo nel costruttore
            _visitList = visits ?? new List<VeterinaryVisit>();
            FavouriteFood = favouriteFood;
            FavouriteGame = favouriteGame;
        }

        public void AddVisit(VeterinaryVisit visit)
        {
            if (visit == null) throw new ArgumentNullException(nameof(visit));
            if (visit.Animal.Equals(this))
                _visitList.Add(visit);
            else throw new ArgumentException("animal wrong");
        }

        /// <summary>
        /// consideriamo uguali due animali se hanno lo stesso nome
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object? obj)
        {
            if (obj == null || obj is not Animal) return false;
            Animal other = obj as Animal;

            return Name.Equals(other.Name);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}