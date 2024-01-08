using Rendezvous;

namespace TestRealApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Node> nodes = new List<Node>();
            for (int i = 0; i < 10; i++)
            {
                nodes.Add(new Node("node" + i, 1));
            }
            nodes.Add(new Node("node1", 1));
            RendezvousHash rendezvous = new RendezvousHash(nodes);
            Dictionary<string, int> nodeDistribute = new Dictionary<string, int>();
            for (int i = 0; i < 1000; i++)
            {
               var node= rendezvous.GetNode(Guid.NewGuid().ToString());
                if (nodeDistribute.ContainsKey(node.Name))
                {
                    nodeDistribute[node.Name]++;
                }
                else
                {
                    nodeDistribute[node.Name] = 1;
                }
            }

            foreach (var item in nodeDistribute)
            {
                Console.WriteLine(item.Key + ":" + item.Value);
            }
        }
    }
}