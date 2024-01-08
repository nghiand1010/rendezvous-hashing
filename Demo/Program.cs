using Rendezvous;

namespace Demo
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
            Rendezvous.RendezvousHash rendezvous = new Rendezvous.RendezvousHash(nodes);

            Dictionary<string, int> countItemInNode = new Dictionary<string, int>();

            for (int i = 0; i < 1000; i++)
            {
                var item = Guid.NewGuid().ToString();
                var nodeName=rendezvous.GetNode(item).Name;
                if (countItemInNode.ContainsKey(nodeName))
                {
                    countItemInNode[nodeName]++;
                }
                else
                {
                    countItemInNode[nodeName] = 1;
                }
            }

            foreach (var item in countItemInNode)
            {
                Console.WriteLine(item.Key + ":" + item.Value);
            }
        }
    }
}