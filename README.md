Rdio for .NET
=============

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

Check out the `RdioNet.Tests` project for more examples. The tests projects will be improved over the time and more coverage will be added.