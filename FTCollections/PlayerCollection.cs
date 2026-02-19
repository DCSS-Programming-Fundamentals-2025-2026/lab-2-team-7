using System.Collections;
using Number_tournament.FTPlayers;

namespace Number_tournament.FTCollections
{
    internal class PlayerCollection : IEnumerable
    {
        private Player[] items;
        private int count;

        public PlayerCollection(int capacity)
        {
            items = new Player[capacity];
            count = 0;
        }

        public int Count
        {
            get { return count; }
        }

        public void Add(Player player)
        {
            if (count == items.Length)
            {
                Array.Resize(ref items, items.Length * 2);
            }

            items[count] = player;
            count++;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            for (int i = index; i < count - 1; i++)
            {
                items[i] = items[i + 1];
            }

            count--;
            items[count] = default;
        }

        public Player GetAt(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            return items[index];
        }

        public void SetAt(int index, Player player)
        {
            if (index < 0 || index >= count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            items[index] = player;
        }

        public IEnumerator GetEnumerator()
        {
            return new PlayerEnumerator(items, count);
        }
    }
}
