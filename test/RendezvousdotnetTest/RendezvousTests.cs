using Rendezvousdotnet;

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
            Rendezvous rendezvous = new Rendezvous(nodes);
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
            Rendezvous rendezvous = new Rendezvous(nodes);
            
            Assert.IsTrue(rendezvous.NodeCount==nodes.Count-1);
        }

        
        [Test]
        public void AddNode_Null_Exception()
        {
            Rendezvous rendezvous = new Rendezvous();
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
            Rendezvous rendezvous = new Rendezvous(nodes);

            var key = Guid.NewGuid().ToString();
            var node1 = rendezvous.GetNode(key);
            var node2 = rendezvous.GetNode(key);
            Assert.IsTrue(node1.Name == node2.Name);

        }

    }
}