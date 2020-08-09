using System;

namespace WorldTour
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string command;
            while ((command = Console.ReadLine()) != "Travel")
            {
                var cmdArg = command.Split(":");
                string toDo = cmdArg[0];

                if (toDo == "Add Stop")
                {
                    text = AddStop(text, cmdArg);
                }
                else if (toDo == "Remove Stop")
                {
                    text = RemoveStop(text, cmdArg);
                }
                else if (toDo == "Switch")
                {
                    text = Switch(text, cmdArg);
                }

                Console.WriteLine(text);
            }
            Console.WriteLine($"Ready for world tour! Planned stops: {text}");

        }

        private static string Switch(string text, string[] cmdArg)
        {
            string oldString = cmdArg[1];
            string newString = cmdArg[2];
            if (text.Contains(oldString))
            {
                text = text.Replace(oldString, newString);
            }

            return text;
        }

        private static string RemoveStop(string text, string[] cmdArg)
        {
            int startIndex = int.Parse(cmdArg[1]);
            int endIndex = int.Parse(cmdArg[2]);
            if (startIndex >= 0 && endIndex < text.Length && startIndex <= endIndex)
            {
                text = text.Remove(startIndex, endIndex - startIndex + 1);
            }

            return text;
        }

        private static string AddStop(string text, string[] cmdArg)
        {
            int index = int.Parse(cmdArg[1]);
            string stringToInsert = cmdArg[2];
            if (index >= 0 && index <= text.Length)
            {
                text = text.Insert(index, stringToInsert);
            }

            return text;
        }
    }
}
