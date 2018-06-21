using System;
using System.Collections.Generic;

namespace Isen.Artru.Library
{
    public interface INode
    {
        string value { get; set; }
        Guid id { get; }
        Node parent { get; set; }
        List<Node> children { get; set; }
        int depth { get; }
        //Ajoute un enfant à un node.
        void AddChildNode(Node node);
        //Ajoute une liste d'enfants à un node.
        void AddNodes(IEnumerable<Node> nodeList);
        //Retire de la liste des enfants le node ayant l'id donné en paramètre
        void RemoveChildNotde(Guid id);
        //Retire un enfant à un Node
        void RemoveChildNode(Node node);

    }
}