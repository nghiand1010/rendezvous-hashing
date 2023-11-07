using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace Rendezvousdotnet
{
    public class Rendezvous
    {
        private ConcurrentDictionary<string, Node> _nodes;

        public int NodeCount => _nodes == null ? 0 : _nodes.Count;
        
        public Rendezvous()
        {
            _nodes = new ConcurrentDictionary<string, Node>();
        }
        public Rendezvous(IEnumerable<Node> nodes)
        {
            _nodes = new ConcurrentDictionary<string, Node>();
            foreach (var node in nodes)
            {
                if (_nodes.ContainsKey(node.Name))
                {
                    continue;
                }

                _nodes.TryAdd(node.Name, node);
            }
        }

        /// <summary>
        /// Add Node to Collection
        /// </summary>
        /// <param name="node"></param>
        public void Add(Node node)
        {
            if (node==null)
            {
                throw new ArgumentNullException("node cannot be null");
            }
            _nodes.TryAdd(node.Name, node);
        }

        /// <summary>
        /// Add Node to Collection
        /// </summary>
        /// <param name="name"></param>
        /// <param name="weight"></param>
        /// 
        public void Add(string name,int weight=1)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name cannot be null");
            }
            _nodes.TryAdd(name,new Node(name,weight));
        }

        /// <summary>
        /// Remove Node from Collection
        /// </summary>
        /// <param name="node"></param>
        public void Remove(Node node)
        {
            _nodes.TryRemove(node.Name, out node);
        }

        /// <summary>
        /// Get Node with specify key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Node GetNode(string key)
        {
            double maxValue = double.MinValue;
            Node max = null;

            foreach (var node in _nodes)
            {
                var value = node.Value.Name + key;
                var score = value.GetHashCode();
                var logScrore = 1 / Math.Log(score);

                if (logScrore > maxValue)
                {
                    max = node.Value;
                    maxValue = logScrore;
                }
            }

            return max;
        }
    }


    public class Node
    {
        public Node(string name, int weight=1)
        {
            this.Name = name;
            this.Weight = weight;
        }
        public string Name { get; set; }
        public int Weight { get; set; }
    }
}