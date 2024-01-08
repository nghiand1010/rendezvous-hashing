using Rendezvous;

namespace RendezvousdotnetTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        
        }

        [Test]
        public void Rendezvous_IEnumarable_Init_NotEmpty()
        {
            List<Node> nodes = new List<Node>();
            for (int i = 0; i < 10; i++)
            {
                nodes.Add(new Node("node" + i, 1));
            }
            Rendezvous.RendezvousHash rendezvous = new Rendezvous.RendezvousHash(nodes);
            Assert.IsTrue(rendezvous.NodeCount==nodes.Count);
        }
        
        [Test]
        public void Rendezvous_IEnumarable_Init_Duplicate_NotEmpty()
        {
            List<Node> nodes = new List<Node>();
            for (int i = 0; i < 10; i++)
            {
                nodes.Add(new Node("node" + i, 1));
            }
            nodes.Add(new Node("node1",1));
            Rendezvous.RendezvousHash rendezvous = new Rendezvous.RendezvousHash(nodes);
            
            Assert.IsTrue(rendezvous.NodeCount==nodes.Count-1);
        }

        
        [Test]
        public void AddNode_Null_Exception()
        {
            Rendezvous.RendezvousHash rendezvous = new RendezvousHash();
            Assert.Throws<ArgumentNullException>(() => 
                rendezvous.Add(null));

        }
        
        [Test]
        public void GetNode_SameKey_SameNode()
        {
            List<Node> nodes = new List<Node>();
            for (int i = 0; i < 10; i++)
            {
                nodes.Add(new Node("node" + i, 1));
            }
            Rendezvous.RendezvousHash rendezvous = new Rendezvous.RendezvousHash(nodes);

            var key = Guid.NewGuid().ToString();
            var node1 = rendezvous.GetNode(key);
            var node2 = rendezvous.GetNode(key);
            Assert.IsTrue(node1.Name == node2.Name);

        }
        
        [Test]
        public void AddNodeWithWeight_ReturnByWeight()
        {
            List<Node> nodes = new List<Node>();
            nodes.Add(new Node("node1", 1));
            nodes.Add(new Node("node2", 2));
            Rendezvous.RendezvousHash rendezvous = new Rendezvous.RendezvousHash(nodes);

            int count1=0, count2=0;
            for (int i = 0; i < 1000; i++)
            {
                var key = Guid.NewGuid().ToString();
                var node1 = rendezvous.GetNode(key);
                if (node1.Name == "node1")
                {
                    count1++;
                }
                var node2 = rendezvous.GetNode(key);

                if (node2.Name=="node2")
                {
                    count2++;
                }
            }
            
            Assert.IsTrue(count1*1.5<count2);
        }

        [Test]
        public void RemoveNode_Success()
        {
            List<Node> nodes = new List<Node>();
            nodes.Add(new Node("node1", 1));
            nodes.Add(new Node("node2", 2));
            Rendezvous.RendezvousHash rendezvous = new Rendezvous.RendezvousHash(nodes);
            var key = Guid.NewGuid().ToString();
            var nodeBeforeRemove = rendezvous.GetNode(key);
            var beforeNodeName = nodeBeforeRemove.Name;
            rendezvous.Remove(nodeBeforeRemove);

            var nodeAfterRemove = rendezvous.GetNode(key);

            Assert.IsTrue(beforeNodeName != nodeAfterRemove.Name);
            
        }

        [Test]
        public void AddNode_Success()
        {
            List<Node> nodes = new List<Node>();
            nodes.Add(new Node("node1", 1));
            nodes.Add(new Node("node2", 2));
            Rendezvous.RendezvousHash rendezvous = new Rendezvous.RendezvousHash(nodes);
            rendezvous.Add(new Node("node3"));
       
            Assert.IsTrue(rendezvous.NodeCount == 3);

        }

    }
}