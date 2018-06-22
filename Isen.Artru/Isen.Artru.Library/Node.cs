using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace Isen.Artru.Library
{
    public class Node<T> : INode<T>, IEquatable<Node<T>>
    {
        public T value { get; set; }
        public Guid id { get; }
        public Node<T> parent { get; set; }
        public List<Node<T>> children { get; set; }
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

        public Node()
        {
            value = default(T);
            id = new Guid();
            children = new List<Node<T>>();
            parent = null;
        }

        public Node(T value)
        {
            this.value = value;
            id = new Guid();
            children = new List<Node<T>>();
            parent = null;
        }

        public void AddChildNode(Node<T> node)
        {
            node.parent = this;
            children.Add(node);
        }

        public void AddNodes(IEnumerable<Node<T>> nodeList)
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

        public void RemoveChildNode(Node<T> node)
        {
            foreach (var n in children.ToList())
            {
                if (n.Equals(node))
                    children.Remove(n);
            }
        }

        public Node<T> FindTraversing(Guid id)
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

        public Node<T> FindTraversing(Node<T> node)
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
        
        public JObject SerializeJSon()
        {    
            var jObject = new JObject();
            
            if (value != null) ;
                jObject.Add(new JProperty("value", value));

            if (children == null || children.Count == 0) return jObject;
           
            var jArray = new JArray();
            children?.ForEach(node => { jArray.Add(node.SerializeJSon()); });
            jObject.Add(new JProperty("children", jArray));
            
            return jObject;
        }
        
        
        public void UnserializeJson(JToken jToken)
        {    
            if(jToken["value"] != null)
                value = jToken["value"].ToObject<T>();

            List<JToken>  jTokenChildren;
            if (jToken["children"] != null)
            {
                jTokenChildren = jToken["children"].Children().ToList();
            }
            else
                return;
            foreach (var child in jTokenChildren)
            {
                var node = new Node<T>();
                node.UnserializeJson(child);
                AddChildNode(node);
            }
        }

        public bool Equals(Node<T> other)
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
            return Equals((Node<T>) obj);
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