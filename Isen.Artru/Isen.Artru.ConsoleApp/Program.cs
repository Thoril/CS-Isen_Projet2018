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
            Node f2 = new Node("f2");
            Node f11= new Node( "f11");
            Node f12 = new Node("f12");
            racine.AddChildNode(f1);
            racine.AddChildNode(f2);
            f1.AddChildNode(f11);
            f1.AddChildNode(f12);
            Console.WriteLine(racine.ToString());
        }
    }
}
