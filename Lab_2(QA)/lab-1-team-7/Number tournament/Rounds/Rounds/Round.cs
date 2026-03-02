public class Round : RoundBase, IScoreRule
{
    public int CountPoints(int repeats)
    {
        return repeats * repeats;
    }

    public override void PrintHeader()
    {
        Console.WriteLine($"\n===== РАУНД №{number_of_round} =====\n");
    }
}
