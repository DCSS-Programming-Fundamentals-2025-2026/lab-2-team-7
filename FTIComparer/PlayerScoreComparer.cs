using System.Collections;
using Number_tournament.FTPlayers;

namespace Number_tournament.FTIComparer
{
    public class PlayerScoreComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            if (ReferenceEquals(x, y))
            {
                return 0;
            }

            if (x is null)
            {
                return 1;
            }

            if (y is null)
            {
                return -1;
            }

            Player p1 = (Player)x;
            Player p2 = (Player)y;

            return p2.Points.CompareTo(p1.Points);
        }
    }
}
