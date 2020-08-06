using System;
using System.Collections.Generic;
using System.Linq;

namespace P06.SongsQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] songs = Console.ReadLine().Split(", ").ToArray();
            var queueOfSongs = new Queue<string>(songs);
            string input = Console.ReadLine();
            while(queueOfSongs.Any())
            {
                string[] command = input
                            .Split(" ", 2 , StringSplitOptions.RemoveEmptyEntries)
                                    .ToArray();
                string cmd = command[0];

                if(cmd == "Play")
                {
                    if(queueOfSongs.Any())
                    {
                        queueOfSongs.Dequeue();
                    }
                }
                else if(cmd == "Add")
                {
                    string nameOfSongToAdd = command[1];
                    if(queueOfSongs.Contains(nameOfSongToAdd))
                    {
                        Console.WriteLine($"{nameOfSongToAdd} is already contained!");
                    }
                    else
                    {
                        queueOfSongs.Enqueue(nameOfSongToAdd);
                    }
                }
                else if(cmd == "Show")
                {
                    Console.WriteLine(string.Join(", ",queueOfSongs));
                }
                input = Console.ReadLine();
            }
            Console.WriteLine("No more songs!");
        }
    }
}
