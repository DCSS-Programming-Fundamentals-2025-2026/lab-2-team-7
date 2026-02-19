namespace Number_tournament.FTPlayers
{
    public class PlayerBase
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
    }
}
