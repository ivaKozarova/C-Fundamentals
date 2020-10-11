using System;


namespace DoublyLinkedList
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var node = new DoublyLinkedList<Cat>();
            node.AddFirst(new Cat ("Maca", 7 , "Maria"));
            node.AddFirst(new Cat("Myro", 2, "Qvor"));
            node.AddFirst(new Cat("Liva", 3 ,"Katq"));
            node.AddFirst(new Cat("Maq", 2, "Stevi"));
            node.AddFirst(new Cat("Klara", 3 , "Qna"));
            node.ForEach(x => Console.WriteLine(x));

            var array = node.ToArray();
            
            Console.WriteLine(node.Count);

            Console.WriteLine(node.RemoveFirst());
            Console.WriteLine(node.RemoveLast());
            Console.WriteLine("After removing:");

            node.ForEach(x => Console.WriteLine(x.Name));

            Console.WriteLine("Cats names: ");
            foreach (var cat in node)
            {
                Console.WriteLine(cat.Name);
            }
            Console.WriteLine(new string('-',20));
            //foreach (var cat in array)
            //{
            //    Console.WriteLine(cat);
            //}
           
          //  Console.WriteLine(string.Join(", ",node.ToArray()));

        }
    }
}
