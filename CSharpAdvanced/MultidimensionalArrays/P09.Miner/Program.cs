using System;
using System.Linq;

namespace P09.Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            var size = int.Parse(Console.ReadLine());

            var command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);


            var field = new char[size][];
            CreateField(size, field);

            var startPos = new int[2];
            var countOfcoals = FindCoalsAndStartPoint(size, field, startPos);
            var totalCoalsCollected = 0;

            bool isEnd = false;
            while (true)
            {

                for (int i = 0; i < command.Length; i++)
                {
                    var currCmd = command[i];
                     var nextPosRow = startPos[0];
                    var nextPosCol = startPos[1];
                    var isNextStepIn = true;

                    if (currCmd == "left")
                    {
                        nextPosCol -= 1;
                        isNextStepIn = CheckNextStepIsIn(nextPosRow, nextPosCol, size);

                    }
                    else if (currCmd == "right")
                    {
                        nextPosCol += 1;
                        isNextStepIn = CheckNextStepIsIn(nextPosRow, nextPosCol, size);
                    }
                    else if (currCmd == "up")
                    {
                        nextPosRow -= 1;
                        isNextStepIn = CheckNextStepIsIn(nextPosRow, nextPosCol, size);
                    }
                    else if (currCmd == "down")
                    {
                        nextPosRow += 1;
                        isNextStepIn = CheckNextStepIsIn(nextPosRow, nextPosCol, size);
                    }
                    if (isNextStepIn)
                    {
                        field[startPos[0]][startPos[1]] = '*';
                        startPos[0] = nextPosRow;
                        startPos[1] = nextPosCol;

                        if (field[startPos[0]][startPos[1]] == 'c')
                        {
                            totalCoalsCollected++;
                            countOfcoals--;
                            if (countOfcoals == 0)
                            {
                                isEnd = true;
                                Console.WriteLine($"You collected all coals! ({startPos[0]}, {startPos[1]})");
                            }
                        }
                        else if (field[startPos[0]][startPos[1]] == 'e')
                        {
                            isEnd = true;
                            Console.WriteLine($"Game over! ({startPos[0]}, {startPos[1]})");
                        }
                        if (isEnd)
                        {
                            break;
                        }
                    }
                    if(i == command.Length -1)
                    {
                        Console.WriteLine($"{countOfcoals} coals left. ({startPos[0]}, {startPos[1]})");
                        isEnd = true;
                    }
                    if (isEnd)
                    {
                        break;
                    }

                }
                if (isEnd)
                {
                    break;
                }

            }

        }

        private static bool CheckNextStepIsIn(int nextPosRow, int nextPosCol, int size)
        {

            if (nextPosRow >= 0 && nextPosRow < size
                && nextPosCol >= 0 && nextPosCol < size)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static int FindCoalsAndStartPoint(int size, char[][] field, int[] startPos)
        {
            int countOfcoals = 0;
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (field[row][col] == 'c')
                    {
                        countOfcoals++;
                    }
                    else if (field[row][col] == 's')
                    {
                        startPos[0] = row;
                        startPos[1] = col;
                    }
                }
            }

            return countOfcoals;
        }

        private static void CreateField(int size, char[][] field)
        {
            for (int row = 0; row < size; row++)
            {
                var fillFields = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse).ToArray();

                field[row] = fillFields;
            }
        }
    }
}
