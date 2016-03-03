Rdio for .NET
=============

*Rdio was discontinued and this library has no use anymore. RIP Rdio!*

Rdio for .NET is an Rdio API web service implentation. It features a full object oriented design and async-await support. It's based on .NET 4 and Async Targeting Pack.

---

To start using Rdio for .NET, create a new instance of `RdioClient` with your Rdion consumer credentials and, optionally, the OAuth access token and secret.

```c#
var client = new RdioClient("consumerKey", "consumerSecret", "accessToken", "accessSecret");
```

The API methods are grouped according to the Rdio API documentation. For example, to call the Get method, you must first access the Core property of the client, where all the Core methods are implemented.

```c#
var track = await client.Core.GetAsync<RdioTrack>("t2537455", RdioTrack.Extras.All);
Console.WriteLine("I love {0} by {1}!", track.Name, track.Artist);
```

UPDATE
---
This lib was written few years ago, on what I would call a "crazy night" for a demo. I had hopes I'd mantain it and get some REAL tests written (proper test cases, etc.), but never did. I'm just keeping this code here in case anyone finds it useful -- I don't even know how much outdated it is in comparison with Rdio's current APIs.
