using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLib.Model
{
         public class FootBallPlayers
        {
        private string _name;
        private int _price;
        private int _shirtNumber;
        public int Count { get; set; }

        public int Id { get; set; }

        public string Name
        {
            get => _name;
            set
            {
                if (value.Length < 4) throw new ArgumentOutOfRangeException();
                _name = value;
            }
        }
        public int Price
        {
            get => _price;
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException();
                _price = value;
            }
        }

        public int ShirtNumber
        {
            get => _shirtNumber;
            set
            {
                if (value < 1 || value > 100) throw new ArgumentOutOfRangeException();
                _shirtNumber = value;
            }
        }

        public FootBallPlayers(int id, string name, int price, int shirtNumber)
        {
            Count = id++;
            Id = Count;
            Name = name;
            Price = price;
            ShirtNumber = shirtNumber;
        }

        public FootBallPlayers()
        {

        }

        public override string ToString()
        {
            return $"Id: {Id} Name: {Name} Price: {Price} ShirtNumber: {ShirtNumber}";
        }
        }
}
