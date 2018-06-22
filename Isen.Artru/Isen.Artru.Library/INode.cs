using System;
using System.Collections.Generic;

namespace Isen.Artru.Library
{
    public interface INode<T>
    {
        T value { get; set; }
        Guid id { get; }
        Node<T> parent { get; set; }
        List<Node<T>> children { get; set; }
        int depth { get; }
        //Ajoute un enfant à un node.
        void AddChildNode(Node<T> node);
        //Ajoute une liste d'enfants à un node.
        void AddNodes(IEnumerable<Node<T>> nodeList);
        //Retire de la liste des enfants le node ayant l'id donné en paramètre
        void RemoveChildNotde(Guid id);
        //Retire un enfant à un Node
        void RemoveChildNode(Node<T> node);
        //Recherche un node selon son id en traversant l'arbre 
        Node<T> FindTraversing(Guid id);
        //Recherche le node passé en parametre dans l'arbre
        Node<T> FindTraversing(Node<T> node);

    }
}