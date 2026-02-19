using System.Collections;

namespace Number_tournament.FTTournamentBrackets
{
    internal class TournamentBracketEnumerator : IEnumerator
    {
        private string[] players;
        private int count;
        private int position;

        public TournamentBracketEnumerator(string[] players, int count)
        {
            this.players = players;
            this.count = count;
            position = -1;
        }

        public object Current
        {
            get { return players[position]; }
        }

        public bool MoveNext()
        {
            position++;
            return position < count;
        }

        public void Reset()
        {
            position = -1;
        }
    }
}
