# rendezvous-hashing
This Library to use rendezvous-hashing [rendezvous-hashing](https://en.wikipedia.org/wiki/Rendezvous_hashing) with C#

[!["Buy Me A Coffee"](https://www.buymeacoffee.com/assets/img/custom_images/orange_img.png)](https://www.buymeacoffee.com/adamnguyen)


# Install 
```
dotnet add package RendezvousSharp
```

You can init as follows
# 1. Init with List Node

```CSharp
  List<Node> nodes = new List<Node>();
    for (int i = 0; i < 10; i++)
    {
        nodes.Add(new Node("node" + i, 1)); // You can add node here
    }
  Rendezvous.RendezvousHash rendezvous = new Rendezvous.RendezvousHash(nodes);
```

# 2. Get node with key

```CSharp
  var key = Guid.NewGuid().ToString();
  var node1 = rendezvous.GetNode(key);
```

# 3. Add more node

```CSharp
      List<Node> nodes = new List<Node>();
      nodes.Add(new Node("node1", 1));
      nodes.Add(new Node("node2", 2));
      Rendezvous.RendezvousHash rendezvous = new Rendezvous.RendezvousHash(nodes);
      rendezvous.Add(new Node("node3"));
```
# 4. Remove Node

```CSharp
     List<Node> nodes = new List<Node>();
      nodes.Add(new Node("node1", 1));
      nodes.Add(new Node("node2", 2));
      Rendezvous.RendezvousHash rendezvous = new Rendezvous.RendezvousHash(nodes);
      var key = Guid.NewGuid().ToString();
      var nodeBeforeRemove = rendezvous.GetNode(key);
      var beforeNodeName = nodeBeforeRemove.Name;
      rendezvous.Remove(nodeBeforeRemove);

```
