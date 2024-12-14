using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lamp
{
    public class Lampadina
    {
        private int _cliks = 0;
        private int _maxClicks;
        private int MaxClicks
        {
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Il numero massimo di click deve essere positivo");
                }
            }
            get 
            {
                return _maxClicks;
            }
        }
        public bool _isBroken 
        { 
            get {
                if (_cliks >= _maxClicks)
                {
                    _isBroken = true;
                    _isOn = false;
                }
                return _isBroken; 
            }
            private set { if (_cliks >= _maxClicks) 
                { 
                    _isBroken = true;
                    _isOn=false;
                } 
            }
        }
        public bool _isOn
        {
            get { return _isOn; }
            private set
            {
                if (_isOn && !_isBroken) { 
                    throw new InvalidOperationException("La lampadina non può essere rotta e accesa allo stesso tempo");
                } else
                    _isOn = value;
            }
        }
        

        public Lampadina(bool isBroken, bool isOn ):this(isBroken,isOn,10) 
        { 
        }
        public Lampadina(bool isBroken, bool isOn, int maxClicks)
        {
            _isBroken = isBroken;
            _isOn = isOn;
            _maxClicks = maxClicks;
        }

        public void Click()
        {
            if (_isBroken)
            {
                throw new Exception("La lampadina è rotta");
            }
            else
            {
                _cliks++;
                if (_isOn)
                {
                    _isOn = false;
                }
                else
                {
                    _isOn = true;
                }
            }
        }
    }
}
