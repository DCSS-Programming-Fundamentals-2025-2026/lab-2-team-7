using Number_tournament.Comparers;
using Number_tournament.FTCollections;
using Number_tournament.FTPlayers;
using System.Text;

class Program
{
    static void Main()
    {
        PlayerCollection playersCollection = new PlayerCollection(20);

        int index = 0;
        Random random = new Random();

        while (true)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            Console.Clear();
            Menu.PrintMenu();
            string input = Console.ReadLine() ?? "";

            switch (input)
            {
                case "1":
                    if (index >= 20)
                    {
                        Console.WriteLine("Досягнуто максимуму (20 гравців).");
                        break;
                    }

                    Console.Write("Введіть ім'я гравця: ");
                    string name = Console.ReadLine() ?? "Гравець";
                    playersCollection.Add(new Player(name, 0, 0));
                    index = playersCollection.Count;

                    Console.WriteLine("Гравця додано!");
                    break;

                case "2":
                    if (index == 0)
                    {
                        Console.WriteLine("Гравців ще не додано.");
                        break;
                    }

                    Console.WriteLine("\n--- Список гравців ---");
                    for (int i = 0; i < index; i++)
                    {
                        Player p = playersCollection.GetAt(i);
                        Console.WriteLine($"{i + 1}. {p.NickName} — {p.Points} балів (серія: {p.Repeats})");
                    }

                    Console.WriteLine("\n--- Перебір через enumerator ---");
                    var it = playersCollection.GetEnumerator();
                    int enumIndex = 1;
                    while (it.MoveNext())
                    {
                        Player p = (Player)it.Current;
                        Console.WriteLine($"{enumIndex}. {p.NickName} — {p.Points} балів (серія: {p.Repeats})");
                        enumIndex++;
                    }
                    break;

                case "3":
                    if (index == 0)
                    {
                        Console.WriteLine("Гравців ще не додано.");
                        break;
                    }

                    Round round = new Round();
                    round.PrintHeader();

                    for (int i = 0; i < index; i++)
                    {
                        Player current = playersCollection.GetAt(i);
                        int randomNumber = random.Next(1, 11);

                        Console.Write($"{current.NickName}, виберіть число (1-10): ");
                        string inputNumber = Console.ReadLine() ?? "";

                        if (!int.TryParse(inputNumber, out int playerNumber))
                        {
                            Console.WriteLine("Невірне значення!");
                            i--;
                            continue;
                        }

                        if (playerNumber == randomNumber)
                        {
                            current.Repeats++;
                            Console.WriteLine($"Вгадали! Серія: {current.Repeats}");
                        }
                        else
                        {
                            Console.WriteLine($"Не вгадали. Було число {randomNumber}");

                            int earned = round.CountPoints(current.Repeats);
                            current.Points += earned;

                            Console.WriteLine($"Отримано {earned} балів.");
                            current.Repeats = 0;
                        }

                        Console.WriteLine();
                    }

                    break;

                case "4":
                    if (index == 0)
                    {
                        Console.WriteLine("Гравців ще не додано.");
                        break;
                    }

                    Console.WriteLine("\n=== ЛІДЕРБОРД ===");

                    round = new Round();
                    for (int i = 0; i < index; i++)
                    {
                        Player p = playersCollection.GetAt(i);
                        if (p.Repeats > 0)
                        {
                            p.Points += round.CountPoints(p.Repeats);
                            p.Repeats = 0;
                        }
                    }

                    Player[] sortedByScore = new Player[index];
                    for (int i = 0; i < index; i++)
                    {
                        sortedByScore[i] = playersCollection.GetAt(i);
                    }

                    Array.Sort(sortedByScore, 0, index, new PlayerScoreComparer());
                    for (int i = 0; i < index; i++)
                    {
                        Player p = sortedByScore[i];
                        Console.WriteLine($"{i + 1}. {p.NickName} - {p.Points} балів");
                    }

                    index = 0;
                    RoundBase.ResetRounds();
                    playersCollection = new PlayerCollection(20);
                    Console.WriteLine("\nГру завершено. Дані та рахунок раундів скинуто.");
                    break;

                case "5":
                    if (index < 2)
                    {
                        Console.WriteLine("Потрібно щонайменше 2 гравці для турніру!");
                        break;
                    }

                    string[] tournamentPlayers = new string[index];
                    for (int i = 0; i < index; i++)
                    {
                        tournamentPlayers[i] = playersCollection.GetAt(i).NickName;
                    }

                    Tournament tournament = new Tournament();
                    string? champion = tournament.RunTournament(tournamentPlayers, index);

                    if (champion != null)
                    {
                        Console.Clear();
                        Console.WriteLine("\n╔════════════════════════════════════╗");
                        Console.WriteLine("║         ТУРНІР ЗАВЕРШЕНО!          ║");
                        Console.WriteLine("╚════════════════════════════════════╝");
                        Console.WriteLine($"\n       ПЕРЕМОЖЕЦЬ: {champion}\n");
                        Console.WriteLine("╔════════════════════════════════════╗\n");
                    }

                    index = 0;
                    RoundBase.ResetRounds();
                    playersCollection = new PlayerCollection(20);
                    Console.WriteLine("Дані скинуто. Нажміть Enter...");
                    Console.ReadLine();
                    break;

                case "6":
                    if (index == 0)
                    {
                        Console.WriteLine("Гравців ще не додано.");
                        break;
                    }

                    Console.WriteLine("\n=== СТАТИСТИКА ===");

                    int totalPoints = 0;
                    Player first = playersCollection.GetAt(0);
                    int maxPoints = first.Points;
                    string maxName = first.NickName;

                    for (int i = 0; i < index; i++)
                    {
                        Player p = playersCollection.GetAt(i);
                        totalPoints += p.Points;

                        if (p.Points > maxPoints)
                        {
                            maxPoints = p.Points;
                            maxName = p.NickName;
                        }
                    }

                    double average = (double)totalPoints / index;
                    Console.WriteLine($"Гравців: {index}");
                    Console.WriteLine($"Сума балів: {totalPoints}");
                    Console.WriteLine($"Середній бал: {average:F2}");
                    Console.WriteLine($"Максимум: {maxName} — {maxPoints} балів");

                    Player[] sortedByName = new Player[index];
                    for (int i = 0; i < index; i++)
                    {
                        sortedByName[i] = playersCollection.GetAt(i);
                    }

                    Array.Sort(sortedByName, 0, index);
                    Console.WriteLine("\nСортування за ім'ям (IComparable):");
                    for (int i = 0; i < index; i++)
                    {
                        Player p = sortedByName[i];
                        Console.WriteLine($"{i + 1}. {p.NickName} — {p.Points} балів");
                    }
                    break;

                case "7":
                    return;

                default:
                    Console.WriteLine("Невірний вибір.");
                    break;
            }

            Console.WriteLine("\nНатисніть Enter, щоб продовжити...");
            Console.ReadLine();
        }
    }
}

