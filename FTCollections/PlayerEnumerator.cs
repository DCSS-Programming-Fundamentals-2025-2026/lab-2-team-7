using System.Collections;
using Number_tournament.FTPlayers;

namespace Number_tournament.FTCollections
{
    internal class PlayerEnumerator : IEnumerator
    {
        private Player[] items;
        private int count;
        private int position;

        public PlayerEnumerator(Player[] items, int count)
        {
            this.items = items;
            this.count = count;
            position = -1;
        }

        public object Current
        {
            get { return items[position]; }
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
