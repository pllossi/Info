using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NumberClasses
{
    public class Game
    {
        private int _numToGuess;
        private bool _isOnlyEven;
        private bool _isLower;
        private int _numMax;
        private Computer computer;
        private Player player;

        public Game()
        {            
            computer = new Computer();
        }

        public int NumToGuess
        {
            get
            {
                return _numToGuess;
            }
            private set
            {
                _numToGuess = value;
            }
        }

        public bool isOnlyEven
        {
            get
            {
                return _isOnlyEven;
            }
            private set
            {
                _isOnlyEven = value;
            }
        }

        public bool isLower
        {
            get
            {
                return _isLower;
            }
            private set
            {
            }
        }

        private void GetNumToGuess()
        {
            if (isOnlyEven)
            {
                NumToGuess = computer.NumEven(_numMax);
            }
            else
            {
                NumToGuess = computer.NumRand(_numMax);
            }
        }

        public bool Guess(int guess)
        {
            player.IncrementTentatives();
            if (guess == _numToGuess)
            {
                return true;
            }
            return false;
        }

        public void StartGame(string name,bool isEven,int numberMaximum=100)
        {
            if (numberMaximum <= 0)
            {
                throw new ArgumentOutOfRangeException("numMax must be greater than 0");
            }
            player = new Player(name);
            _numMax = numberMaximum;
            isOnlyEven = iseven;
        }
    }
}