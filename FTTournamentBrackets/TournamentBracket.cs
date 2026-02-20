using System.Collections;

namespace Number_tournament.FTTournamentBrackets
{
    internal class TournamentBracket : IEnumerable
    {
        private string[] players;
        private int count;

        public TournamentBracket(string[] source, int length)
        {
            players = new string[length];
            for (int i = 0; i < length; i++)
            {
                players[i] = source[i];
            }

            count = length;
        }

        public int Count
        {
            get { return count; }
        }

        public string GetAt(int index)
        {
            return players[index];
        }

        public IEnumerator GetEnumerator()
        {
            return new TournamentBracketEnumerator(players, count);
        }
    }
}
