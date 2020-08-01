using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace P03.MessagesManager_Aug2019G1
{
    class Program
    {
        static void Main(string[] args)
        {
            int capacity = int.Parse(Console.ReadLine());

            Dictionary<string, Message> users = new Dictionary<string, Message>();
            string cmd; 
            while((cmd =Console.ReadLine())!= "Statistics")
            {
                string[] cmdArg = cmd.Split("=");
                string command = cmdArg[0];

                if(command == "Add")
                {
                    AddUsers(users, cmdArg);
                }
                else if(command == "Message")
                {
                    string sender = cmdArg[1];
                    string receiver = cmdArg[2];
                    if(users.ContainsKey(sender) && users.ContainsKey(receiver))
                    {
                        
                        users[sender].Sent += 1;
                        users[receiver].Received += 1;
                        int total = Message.
                        SendReceiveMsg(capacity, users, sender);
                        SendReceiveMsg(capacity, users, receiver);
                    }
                }
                else if(command == "Empty")
                {
                    users = EmptyRecords(users, cmdArg);
                }


            }
            users = users.OrderByDescending(x => x.Value.Received).ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine($"Users count: {users.Count}");
            foreach (var kvp in users)
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value.Total}");
            }


        }

        private static void AddUsers(Dictionary<string, Message> users, string[] cmdArg)
        {
            string userName = cmdArg[1];
            if (!users.ContainsKey(userName))
            {
                int sent = int.Parse(cmdArg[2]);
                int received = int.Parse(cmdArg[3]);
                Message msg = new Message(sent, received, userName);
                users[userName] = msg;
            }
        }

        private static Dictionary<string, Message> EmptyRecords(Dictionary<string, Message> users, string[] cmdArg)
        {
            string userName = cmdArg[1];
            if (userName == "All")
            {
                users = new Dictionary<string, Message>();
            }
            else
            {
                users.Remove(userName);
            }

            return users;
        }

        private static void SendReceiveMsg(int capacity, Dictionary<string, Message> users, string user)
        {

            users[user].Total += 1;
            if (users[user].Total == capacity)
            {
                users.Remove(user);
                Console.WriteLine($"{user} reached the capacity!");
            }
            
        }
    }
    public class Message
    {
        public int Sent { get; set; }
        public int Received { get; set; }
        public int Total { get; set; }
        public string UserName { get; set; }
        public Message(int sent, int recived, string userName)
        {
            this.Sent = sent;
            this.Received = recived;
            //this.Total = sent + recived;
            this.UserName = userName;
            this.Total = 0;


        }
          public int CalcTotal( int sent , int recived )
        {
            Total = sent + recived;
            return Total;

        }
    }
}
