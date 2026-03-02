using System.Runtime.InteropServices.Marshalling;

namespace Number_tournament.Rounds
{
    internal class ThreePlayersRound : RoundBase
    {
        public static void Round1t(string[] names, int[] points)
        {
        }

        public static void Round3t(string[] names, int[] points)
        {
        }

        public static void Round5t(string[] names, int[] points)
        {
        }

        public override void PrintHeader()
        {
            Console.WriteLine($"\n=== Three players round #{number_of_round} ===\n");
        }
    }
}