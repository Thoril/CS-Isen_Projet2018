using System;
using Isen.Artru.Library;

namespace Isen.Artru.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Node racine = new Node("racine");
            Node f1 = new Node( "f1");
            racine.AddChildNode(f1);
            Console.WriteLine(racine.id);
            Console.WriteLine(f1.depth);
            //racine.ToString();
        }
    }
}
