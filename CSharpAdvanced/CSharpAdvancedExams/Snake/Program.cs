using System;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[][] matrix = new char[n][];
            FillTheMatrix(n, matrix);

            int foodEaten = 0;
            bool isOut = false;

            var snakePos = new int[2];
            FindSnakePosition(snakePos, n, matrix);

            while (foodEaten < 10 && isOut == false)
            {
                string command = Console.ReadLine();

                switch (command)
                {
                    case "up":
                        if (snakePos[0] == 0)
                        {
                            isOut = true;
                            matrix[snakePos[0]][snakePos[1]] = '.';
                        }
                        else
                        {
                            int newRow = snakePos[0] - 1;
                            int newCol = snakePos[1];
                            foodEaten = MoveSnake(n, matrix, foodEaten, snakePos, newRow, newCol);

                        }
                        break;
                    case "down":
                        if (snakePos[0] == n -1)
                        {
                            isOut = true;
                            matrix[snakePos[0]][snakePos[1]] = '.';
                        }
                        else
                        {
                            int newRow = snakePos[0] + 1;
                            int newCol = snakePos[1];
                            foodEaten = MoveSnake(n, matrix, foodEaten, snakePos, newRow, newCol);
                        }
                        break;

                    case "left":
                        if (snakePos[1] == 0)
                        {
                            isOut = true;
                            matrix[snakePos[0]][snakePos[1]] = '.';
                        }
                        else
                        {
                            int newRow = snakePos[0];
                            int newCol = snakePos[1] - 1;
                            foodEaten = MoveSnake(n, matrix, foodEaten, snakePos, newRow, newCol);
                        }
                        break;
                    case "right":
                        if (snakePos[1] == n -1)
                        {
                            isOut = true;
                            matrix[snakePos[0]][snakePos[1]] = '.';
                        }
                        else
                        {
                            int newRow = snakePos[0];
                            int newCol = snakePos[1] + 1;
                            foodEaten = MoveSnake(n, matrix, foodEaten, snakePos, newRow, newCol);
                        }

                        break;
                }
            }

            if(isOut)
            {
                Console.WriteLine("Game over!");
            }
            if(foodEaten == 10)
            {
                Console.WriteLine("You won! You fed the snake.");
            }
            Console.WriteLine($"Food eaten: {foodEaten}");
            for (int row = 0; row < n; row++)
            {
                Console.WriteLine(string.Join("",matrix[row]));
            }


        }

        private static int MoveSnake(int n, char[][] matrix, int foodEaten, int[] snakePos, int newRow, int newCol)
        {
            matrix[snakePos[0]][snakePos[1]] = '.';

            if (matrix[newRow][newCol] == '*')
            {
                foodEaten++;
                snakePos[0] = newRow;
                snakePos[1] = newCol;
                

            }
            else if (matrix[newRow][newCol] == 'B')
            {
                matrix[newRow][newCol] = '.';
                bool isFound = false;
                for (int row = 0; row < n; row++)
                {
                    for (int col = 0; col < n; col++)
                    {
                        if (matrix[row][col] == 'B')
                        {
                            snakePos[0] = row;
                            snakePos[1] = col;
                            isFound = true;
                            break;
                        }
                    }
                    if (isFound)
                    {
                        break;
                    }
                }
            }
            else
            {
                snakePos[0] = newRow;
                snakePos[1] = newCol;
            }
            matrix[snakePos[0]][snakePos[1]] = 'S';
            return foodEaten;
        }

        private static void FindSnakePosition(int[] snakePos, int n, char[][] matrix)
        {
            int snakePosRow = -1;
            int snakePosCol = -1;
            bool isFound = false;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row][col] == 'S')
                    {
                        snakePosRow = row;
                        snakePosCol = col;
                        break;
                    }
                }
                if (isFound)
                {
                    break;
                }
            }
            snakePos[0] = snakePosRow;
            snakePos[1] = snakePosCol;

        }

        private static void FillTheMatrix(int n, char[][] matrix)
        {
            for (int row = 0; row < n; row++)
            {
                var input = Console.ReadLine().ToCharArray();
                matrix[row] = input;
            }
        }
    }
}
