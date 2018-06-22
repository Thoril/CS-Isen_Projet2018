using System;
using System.Collections.Generic;
using System.Linq;

namespace Isen.Artru.Library
{
    public class Node : INode, IEquatable<Node>
    {
        public string value { get; set; }
        public Guid id { get; }
        public Node parent { get; set; }
        public List<Node> children { get; set; }
        public int depth => parent?.depth + 1 ?? 0;
        
        public override string ToString()
        {
            var toString = "";
            for (var i = 0; i < depth; i++)
                toString += "|=";
            toString += $"{value} {id}";
            foreach (var node in children)
                toString += $"{Environment.NewLine}{node}";
            return toString;
        }

        public Node(string value)
        {
            this.value = value;
            id = new Guid();
            children = new List<Node>();
            parent = null;
        }

        public void AddChildNode(Node node)
        {
            node.parent = this;
            children.Add(node);
        }

        public void AddNodes(IEnumerable<Node> nodeList)
        {
            foreach (var node in nodeList)
            {
                AddChildNode(node);
            }
        }

        public void RemoveChildNotde(Guid id)
        {
            foreach (var node in children.ToList())
            {
                if (node.id == id)
                    children.Remove(node);
            }
        }

        public void RemoveChildNode(Node node)
        {
            foreach (var n in children.ToList())
            {
                if (n.Equals(node))
                    children.Remove(n);
            }
        }

        public Node FindTraversing(Guid id)
        {
            if (children == null)
                return null;
            foreach (var node in children)
            {
                if (node.id == id)
                    return  node;
                var retour = node.FindTraversing(id);
                if (retour != null)
                    return retour;
            }
            return null;
        }

        public Node FindTraversing(Node node)
        {
            if (children == null)
                return null;
            foreach (var n in children)
            {
                if (n.Equals(node))
                    return  n;
                var retour = n.FindTraversing(node);
                if (retour != null)
                    return retour;
            }
            return null;
        }


        public bool Equals(Node other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(value, other.value) && id.Equals(other.id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Node) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((value != null ? value.GetHashCode() : 0) * 397) ^ id.GetHashCode();
            }
        }
    }
}