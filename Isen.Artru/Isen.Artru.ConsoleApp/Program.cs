using System;
using Isen.Artru.Library;

namespace Isen.Artru.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var racine = new Node<string>("racine");
            var f1 = new Node<string>( "f1");
            var f2 = new Node<string>("f2");
            var f11= new Node<string>( "f11");
            var f12 = new Node<string>("f12");
            racine.AddChildNode(f1);
            racine.AddChildNode(f2);
            f1.AddChildNode(f11);
            f1.AddChildNode(f12);
            Console.WriteLine(racine.ToString());
        }
    }
} 
