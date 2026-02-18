using System;
using System.Collections.Generic;

class Tournament
{
    private Random random = new Random();

    public string? RunTournament(string[] players, int count)
    {
        if (count < 2)
        {
            Console.WriteLine("Потрібно щонайменше 2 гравці для турніру!");
            return null;
        }

        List<string> remainingPlayers = new List<string>();
        for (int i = 0; i < count; i++)
        {
            remainingPlayers.Add(players[i]);
        }

        int roundNumber = 1;

        while (remainingPlayers.Count > 1)
        {
            Console.Clear();
            Console.WriteLine($"\n===== РАУНД #{roundNumber} =====\n");
            Console.WriteLine($"Кількість гравців: {remainingPlayers.Count}");
            Console.WriteLine("Нажміть Enter щоб почати раунд...");
            Console.ReadLine();

            List<string> nextRound = new List<string>();

            for (int i = 0; i < remainingPlayers.Count; i += 2)
            {
                if (i + 1 < remainingPlayers.Count)
                {
                    string winner = PlayMatch(remainingPlayers[i], remainingPlayers[i + 1]);
                    nextRound.Add(winner);
                }
                else
                {
                    Console.WriteLine($"\n{remainingPlayers[i]} отримує пропуск у наступний раунд (bye).");
                    nextRound.Add(remainingPlayers[i]);
                }
            }

            remainingPlayers = nextRound;
            roundNumber++;

            if (remainingPlayers.Count > 1)
            {
                Console.WriteLine("\nНатисніть Enter щоб перейти до наступного раунду...");
                Console.ReadLine();
            }
        }

        return remainingPlayers[0];
    }

    private string PlayMatch(string player1, string player2)
    {
        Console.WriteLine($"\n--- МАТЧ: {player1} vs {player2} ---\n");

        int player1Score = 0;
        int player2Score = 0;
        int bestOf = 3;

        for (int round = 1; round <= bestOf; round++)
        {
            Console.WriteLine($"Раунд {round}:");


            int randomNumber1 = random.Next(1, 11);
            Console.Write($"{player1}, виберіть число (1-10): ");
            string input1 = Console.ReadLine() ?? "";

            if (!int.TryParse(input1, out int guess1))
            {
                Console.WriteLine("Невірне значення!");
                round--;
                continue;
            }

            int randomNumber2 = random.Next(1, 11);
            Console.Write($"{player2}, виберіть число (1-10): ");
            string input2 = Console.ReadLine() ?? "";

            if (!int.TryParse(input2, out int guess2))
            {
                Console.WriteLine("Невірне значення!");
                round--;
                continue;
            }

            bool player1Correct = (guess1 == randomNumber1);
            bool player2Correct = (guess2 == randomNumber2);

            Console.WriteLine($"\n{player1} вибрав: {guess1} | Число було: {randomNumber1}");
            Console.WriteLine($"{player2} вибрав: {guess2} | Число було: {randomNumber2}\n");

            if (player1Correct && !player2Correct)
            {
                player1Score++;
                Console.WriteLine($"{player1} вгадав! {player2} не вгадав.");
                Console.WriteLine($"Рахунок: {player1} {player1Score}:{player2Score} {player2}\n");
            }
            else if (player2Correct && !player1Correct)
            {
                player2Score++;
                Console.WriteLine($"{player2} вгадав! {player1} не вгадав.");
                Console.WriteLine($"Рахунок: {player1} {player1Score}:{player2Score} {player2}\n");
            }
            else if (player1Correct && player2Correct)
            {
                Console.WriteLine("Обидва вгадали!");
                Console.WriteLine($"Рахунок: {player1} {player1Score}:{player2Score} {player2}\n");
            }
            else
            {
                Console.WriteLine($"Ніхто не вгадав.");
                Console.WriteLine($"Рахунок: {player1} {player1Score}:{player2Score} {player2}\n");
            }

            if (player1Score > bestOf / 2 || player2Score > bestOf / 2)
            {
                break;
            }
        }

        string matchWinner = player1Score > player2Score ? player1 : player2;
        Console.WriteLine($"\n★ ПЕРЕМОЖЕЦЬ МАТЧУ: {matchWinner} ★\n");
        Console.WriteLine("Нажміть Enter щоб продовжити...");
        Console.ReadLine();

        return matchWinner;
    }
}
