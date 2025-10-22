using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
    public class Adottante
    {
        private string _name;
        private string _surname;
        private PhoneNumber _telefono;
        private Email _email;
        private TaxId _codiceFiscale;
        private string _cap;
        private string _città;
        public string Name 
        { 
            get=> _name;
            private set {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Il nome non può essere vuoto.");
                _name = value;
            }
        }
        public string Surname 
        { 
            get => _surname;
            private set {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Il cognome non può essere vuoto.");
                _surname = value;
            }
        }
        public PhoneNumber Telefono 
        { 
            get => _telefono;
            private set {
                if (value == null)
                    throw new ArgumentNullException("Il numero di telefono non può essere nullo.");
                _telefono = value;
            }
        }
        public Email Email 
        { 
            get=> _email;
            private set {
                if (value == null)
                    throw new ArgumentNullException("L'email non può essere nulla.");
                _email = value;
            }
        }
        public TaxId CodiceFiscale 
        { 
            get => _codiceFiscale;
            private set {
                if (value == null)
                    throw new ArgumentNullException("Il codice fiscale non può essere nullo.");
                _codiceFiscale = value;
            }
        }

        public Adottante(string name,string surname,PhoneNumber? number, Email? email, TaxId codiceFiscale) {
            Name = name;
            Surname = surname;
            if(number == null&&email==null) throw new ArgumentNullException("Il numero di telefono e l'email non possono essere nulle.");
            Telefono = number;
            Email = email;
            CodiceFiscale = codiceFiscale;
        }


        public override string ToString() => $"{Name} {Surname}";
    }
}