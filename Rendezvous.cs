using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace Rendezvousdotnet
{
    public class Rendezvous
    {
        private ConcurrentDictionary<string, Node> _nodes;

        public Rendezvous(ConcurrentDictionary<string, Node> nodes)
        {
            _nodes = nodes;
        }
        
        public Rendezvous(IEnumerable<Node> nodes)
        {
            var _nodes = new ConcurrentDictionary<string, Node>
                (nodes.ToDictionary(node => node.Name));
        }

        /// <summary>
        /// Add Node to Collection
        /// </summary>
        /// <param name="node"></param>
        public void Add(Node node)
        {
            _nodes.TryAdd(node.Name, node);
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
        public string Name { get; set; }
        public int Weight { get; set; }
    }
}