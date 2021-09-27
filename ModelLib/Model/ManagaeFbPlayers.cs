using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLib.Model
{
    public class ManagaeFbPlayers
    {

        public bool Create(FootBallPlayers value)
        {
            _footBallPlayers.Add(value);
            return true;
        }

        public FootBallPlayers Delete(int id)
        {
            FootBallPlayers footBallPlayer = Get(id);
            _footBallPlayers.Remove(footBallPlayer);
            return footBallPlayer;
        }

        public IEnumerable<FootBallPlayers> Get()
        {
            return new List<FootBallPlayers>(_footBallPlayers);
        }

        public FootBallPlayers Get(int id)
        {
            return _footBallPlayers.Find(f => f.Id == id);
        }

        public bool Update(int id, FootBallPlayers value)
        {
            FootBallPlayers footBallPlayers = Get(id);
            if (footBallPlayers != null)
            {
                footBallPlayers.Id = value.Id;
                footBallPlayers.Name = value.Name;
                footBallPlayers.Price = value.Price;
                footBallPlayers.ShirtNumber = value.ShirtNumber;

                return true;
            }

            return false;
        }

        // Static list for objects
        private static List<FootBallPlayers> _footBallPlayers = new List<FootBallPlayers>()
        {
            new FootBallPlayers(1, "Mike Johnson", 10, 1),
            new FootBallPlayers(2, "John Doe", 7, 2),
            new FootBallPlayers(3, "Mike Wasowski", 24, 3),
            new FootBallPlayers(4, "Tom Brady", 1, 4)

        };
    }
}
