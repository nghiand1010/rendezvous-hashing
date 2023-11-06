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
                nodes.Add(new Node
                {
                    Name = "node" + i,
                    Weight = 1
                });
            }
            Rendezvous rendezvous = new Rendezvous(nodes);
            var node = rendezvous.GetNode("test");
            Assert.IsNotNull(node);
            Assert.Pass();
        }
    }
}