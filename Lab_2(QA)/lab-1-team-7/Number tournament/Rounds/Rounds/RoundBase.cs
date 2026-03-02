public abstract class RoundBase
{
    protected static int globalRoundCounter = 0;

    public int number_of_round { get; }

    public RoundBase()
    {
        number_of_round = ++globalRoundCounter;
    }

    public static void ResetRounds()
    {
        globalRoundCounter = 0;
    }

    public abstract void PrintHeader();
}
