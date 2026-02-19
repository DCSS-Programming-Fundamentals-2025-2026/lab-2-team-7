using Number_tournament.FTIComparer;
using Number_tournament.FTPlayers;
using System.Text;

class Program
{
    static void Main()
    {
        Player[] playersList = new Player[20];
        string[] players = new string[20];
        int[] points = new int[20];
        int[] repeats = new int[20];

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
                    playersList[index] = new Player(name, 0, 0);
                    players[index] = name;
                    points[index] = 0;
                    repeats[index] = 0;
                    index++;

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
                        Console.WriteLine($"{i + 1}. {players[i]} — {points[i]} балів (серія: {repeats[i]})");
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
                        int randomNumber = random.Next(1, 11);

                        Console.Write($"{players[i]}, виберіть число (1-10): ");
                        string inputNumber = Console.ReadLine() ?? "";

                        if (!int.TryParse(inputNumber, out int playerNumber))
                        {
                            Console.WriteLine("Невірне значення!");
                            i--;
                            continue;
                        }

                        if (playerNumber == randomNumber)
                        {
                            repeats[i]++;
                            playersList[i].Repeats++;
                            Console.WriteLine($"Вгадали! Серія: {repeats[i]}");
                        }
                        else
                        {
                            Console.WriteLine($"Не вгадали. Було число {randomNumber}");

                            int earned = round.CountPoints(repeats[i]);
                            earned = round.CountPoints(playersList[i].Repeats);
                            points[i] += earned;
                            playersList[i].Points += earned;

                            Console.WriteLine($"Отримано {earned} балів.");
                            repeats[i] = 0;
                            playersList[i].Repeats = 0;
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
                        if (repeats[i] > 0)
                        {
                            points[i] += round.CountPoints(repeats[i]);
                            playersList[i].Points += round.CountPoints(playersList[i].Repeats);
                            repeats[i] = 0;
                            playersList[i].Repeats = 0;
                        }
                    }

                    Array.Sort(playersList, 0, index, new PlayerScoreComparer());
                    for (int i = 0; i < index; i++)
                    {
                        Player p = playersList[i];
                        Console.WriteLine($"{i + 1}. {p.NickName} - {p.Points} балів");
                    }

                    index = 0;
                    RoundBase.ResetRounds();
                    Array.Clear(playersList, 0, playersList.Length);
                    Console.WriteLine("\nГру завершено. Дані та рахунок раундів скинуто.");
                    break;

                case "5":
                    if (index < 2)
                    {
                        Console.WriteLine("Потрібно щонайменше 2 гравці для турніру!");
                        break;
                    }

                    Tournament tournament = new Tournament();
                    string? champion = tournament.RunTournament(players, index);

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
                    Array.Clear(playersList, 0, playersList.Length);
                    Console.WriteLine("Дані скинуто. Нажміть Enter...");
                    Console.ReadLine();
                    break;

                case "6":
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

