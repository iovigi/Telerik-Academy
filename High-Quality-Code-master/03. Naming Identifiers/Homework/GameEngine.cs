using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweeper
{
    public class GameEngine
    {
        static void Main(string[] аргументи)
        {
            string command = string.Empty;
            char[,] board = CreateBoard();
            char[,] bombs = PlaceBombs();
            int counter = 0;
            bool isDetonate = false;
            List<PlayerStatistic> playerStatistics = new List<PlayerStatistic>(6);
            int row = 0;
            int column = 0;
            bool isOnMenu = true;
            const int nonMineFieldCount = 35;
            bool isSuccessGame = false;

            do
            {
                if (isOnMenu)
                {
                    Console.WriteLine("Hajde da igraem na “Mini4KI”. Probvaj si kasmeta da otkriesh poleteta bez mini4ki." +
                    " Komanda 'top' pokazva klasiraneto, 'restart' po4va nova igra, 'exit' izliza i hajde 4ao!");
                    PrintBoard(board);
                    isOnMenu = false;
                }

                Console.Write("Daj red i kolona : ");

                command = Console.ReadLine().Trim();

                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) &&
                    int.TryParse(command[2].ToString(), out column) &&
                        row <= board.GetLength(0) && column <= board.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        PrintStatistic(playerStatistics);
                        break;
                    case "restart":
                        board = CreateBoard();
                        bombs = PlaceBombs();
                        PrintBoard(board);
                        isDetonate = false;
                        isOnMenu = false;
                        break;
                    case "exit":
                        Console.WriteLine("4a0, 4a0, 4a0!");
                        break;
                    case "turn":
                        if (bombs[row, column] != '*')
                        {
                            if (bombs[row, column] == '-')
                            {
                                MakeMove(board, bombs, row, column);
                                counter++;
                            }
                            if (nonMineFieldCount == counter)
                            {
                                isSuccessGame = true;
                            }
                            else
                            {
                                PrintBoard(board);
                            }
                        }
                        else
                        {
                            isDetonate = true;
                        }
                        break;
                    default:
                        Console.WriteLine("\nGreshka! nevalidna Komanda\n");
                        break;
                }

                if (isDetonate)
                {
                    PrintBoard(bombs);
                    Console.Write("\nHrrrrrr! Umria gerojski s {0} to4ki. " +
                        "Daj si niknejm: ", counter);
                    string name = Console.ReadLine();
                    PlayerStatistic playerStatistic = new PlayerStatistic(name, counter);

                    if (playerStatistics.Count < 5)
                    {
                        playerStatistics.Add(playerStatistic);
                    }
                    else
                    {
                        for (int i = 0; i < playerStatistics.Count; i++)
                        {
                            if (playerStatistics[i].Score < playerStatistic.Score)
                            {
                                playerStatistics.Insert(i, playerStatistic);
                                playerStatistics.RemoveAt(playerStatistics.Count - 1);
                                break;
                            }
                        }
                    }

                    playerStatistics.Sort((PlayerStatistic firstPlayerStatistic, PlayerStatistic secondPlayerStatistic) => secondPlayerStatistic.Name.CompareTo(firstPlayerStatistic.Name));
                    playerStatistics.Sort((PlayerStatistic firstPlayerStatistic, PlayerStatistic secondPlayerStatistic) => secondPlayerStatistic.Score.CompareTo(firstPlayerStatistic.Score));
                    PrintStatistic(playerStatistics);

                    board = CreateBoard();
                    bombs = PlaceBombs();
                    counter = 0;
                    isDetonate = false;
                    isOnMenu = true;
                }

                if (isSuccessGame)
                {
                    Console.WriteLine("\nBRAVOOOS! Otvri 35 kletki bez kapka kryv.");
                    PrintBoard(bombs);
                    Console.WriteLine("Daj si imeto, batka: ");
                    string name = Console.ReadLine();
                    PlayerStatistic playerStatistic = new PlayerStatistic(name, counter);
                    playerStatistics.Add(playerStatistic);
                    PrintStatistic(playerStatistics);
                    board = CreateBoard();
                    bombs = PlaceBombs();
                    counter = 0;
                    isSuccessGame = false;
                    isOnMenu = true;
                }
            }
            while (command != "exit");

            Console.WriteLine("Made in Bulgaria - Uauahahahahaha!");
            Console.WriteLine("AREEEEEEeeeeeee.");
            Console.Read();
        }

        private static void PrintStatistic(List<PlayerStatistic> statistic)
        {
            Console.WriteLine("\nTo4KI:");

            if (statistic.Count > 0)
            {
                for (int i = 0; i < statistic.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} kutii",
                        i + 1, statistic[i].Name, statistic[i].Score);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("prazna klasaciq!\n");
            }
        }

        private static void MakeMove(char[,] board, char[,] bombs, int row, int column)
        {
            char bombCount = CalculateCountOfBombAround(bombs, row, column);
            bombs[row, column] = bombCount;
            board[row, column] = bombCount;
        }

        private static void PrintBoard(char[,] board)
        {
            int boardRows = board.GetLength(0);
            int boardColumns = board.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int i = 0; i < boardRows; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < boardColumns; j++)
                {
                    Console.Write(string.Format("{0} ", board[i, j]));
                }
                Console.Write("|");
                Console.WriteLine();
            }
            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] CreateBoard()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] board = new char[boardRows, boardColumns];

            for (int i = 0; i < boardRows; i++)
            {
                for (int j = 0; j < boardColumns; j++)
                {
                    board[i, j] = '?';
                }
            }

            return board;
        }

        private static char[,] PlaceBombs()
        {
            int rows = 5;
            int columns = 10;
            char[,] board = new char[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    board[i, j] = '-';
                }
            }

            List<int> mineCoordinates = new List<int>();
            while (mineCoordinates.Count < 15)
            {
                Random random = new Random();
                int generatedCoordinate = random.Next(50);

                if (!mineCoordinates.Contains(generatedCoordinate))
                {
                    mineCoordinates.Add(generatedCoordinate);
                }
            }

            foreach (int mineCoordinate in mineCoordinates)
            {
                int column = (mineCoordinate / columns);
                int row = (mineCoordinate % columns);
                if (row == 0 && mineCoordinate != 0)
                {
                    column--;
                    row = columns;
                }
                else
                {
                    row++;
                }
                board[column, row - 1] = '*';
            }

            return board;
        }

        private static void CalculateCountOfBombNearEveryField(char[,] board)
        {
            int columnCount = board.GetLength(0);
            int rowCount = board.GetLength(1);

            for (int i = 0; i < columnCount; i++)
            {
                for (int j = 0; j < rowCount; j++)
                {
                    if (board[i, j] != '*')
                    {
                        char bombCount = CalculateCountOfBombAround(board, i, j);
                        board[i, j] = bombCount;
                    }
                }
            }
        }

        private static char CalculateCountOfBombAround(char[,] bombs, int row, int column)
        {
            int counter = 0;
            int rowCount = bombs.GetLength(0);
            int columnCount = bombs.GetLength(1);

            if (row - 1 >= 0)
            {
                if (bombs[row - 1, column] == '*')
                {
                    counter++;
                }
            }
            if (row + 1 < rowCount)
            {
                if (bombs[row + 1, column] == '*')
                {
                    counter++;
                }
            }
            if (column - 1 >= 0)
            {
                if (bombs[row, column - 1] == '*')
                {
                    counter++;
                }
            }
            if (column + 1 < columnCount)
            {
                if (bombs[row, column + 1] == '*')
                {
                    counter++;
                }
            }
            if ((row - 1 >= 0) && (column - 1 >= 0))
            {
                if (bombs[row - 1, column - 1] == '*')
                {
                    counter++;
                }
            }
            if ((row - 1 >= 0) && (column + 1 < columnCount))
            {
                if (bombs[row - 1, column + 1] == '*')
                {
                    counter++;
                }
            }
            if ((row + 1 < rowCount) && (column - 1 >= 0))
            {
                if (bombs[row + 1, column - 1] == '*')
                {
                    counter++;
                }
            }
            if ((row + 1 < rowCount) && (column + 1 < columnCount))
            {
                if (bombs[row + 1, column + 1] == '*')
                {
                    counter++;
                }
            }

            return char.Parse(counter.ToString());
        }
    }
}
