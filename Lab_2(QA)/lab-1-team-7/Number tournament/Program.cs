using System;
using System.Text;

class Program
{
    static void Main()
    {
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
                    players[index] = Console.ReadLine() ?? "Гравець";
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
                            Console.WriteLine($"Вгадали! Серія: {repeats[i]}");
                        }
                        else
                        {
                            Console.WriteLine($"Не вгадали. Було число {randomNumber}");

                            int earned = round.CountPoints(repeats[i]);
                            points[i] += earned;

                            Console.WriteLine($"Отримано {earned} балів.");
                            repeats[i] = 0;
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
                            repeats[i] = 0;
                        }
                    }

                    for (int i = 0; i < index - 1; i++)
                    {
                        for (int j = 0; j < index - i - 1; j++)
                        {
                            if (points[j] < points[j + 1])
                            {
                                (points[j], points[j + 1]) = (points[j + 1], points[j]);
                                (players[j], players[j + 1]) = (players[j + 1], players[j]);
                            }
                        }
                    }

                    for (int i = 0; i < index; i++)
                    {
                        Console.WriteLine($"{i + 1}. {players[i]} — {points[i]} балів");
                    }

                    index = 0;
                    RoundBase.ResetRounds();
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

