using System;

namespace Number_tournament.FTPlayers
{
    public class PlayerBase : IComparable
    {
        public string NickName;
        public int Points;
        public int Repeats;
        
        public PlayerBase(string nickName, int points, int repeats)
        {
            NickName = nickName;
            Points = points;
            Repeats = repeats;
        }

        public int CompareTo(object obj)
        {
            if (ReferenceEquals(obj, null))
            {
                return 1;
            }

            if (obj is not PlayerBase other)
            {
                throw new ArgumentException("Object is not a PlayerBase", nameof(obj));
            }

            int nameResult = string.Compare(NickName, other.NickName, StringComparison.OrdinalIgnoreCase);
            if (nameResult != 0)
            {
                return nameResult;
            }

            return other.Points.CompareTo(Points);
        }
    }
}
