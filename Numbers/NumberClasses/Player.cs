using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NumberClasses
{
    public class Player
    {
        private string _name;

        public Player(string name)
        {
            Name = name;
            Tentatives = 0;
        }

        /// <summary></summary>
        public string Name
        {
            get 
            {
                return _name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or empty");
                }
                _name = value;
            }
        }

        
        
        public int Tentatives
        {
            get => default;
            private set
            {
            }
        }

        public void IncrementTentatives()
        {
            Tentatives++;
        }
    }
}