#region Header

// Copyright (c) 2012 Diego Frata
//
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software
// and associated documentation files (the "Software"), to deal in the Software without restriction,
// including without limitation the rights to use, copy, modif/ merge, publish, distribute, sublicense,
// and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do
// so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all copies or substantial
// portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT
// NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
// IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE
// SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

#endregion


#region Using Statements

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using RdioNet.Models;

#endregion

namespace RdioNet.Tests
{
	[TestClass]
	public class CoreMethodsTests
	{
		#region Public Methods

		[TestMethod]
		public void Get()
		{
			var client = ClientFactory.CreateClient();

			var album = client.Core.GetAsync<RdioAlbum>("a1", new Dictionary<string, string> { { "test", "test" } }, RdioAlbum.Extras.All).Result;

			Assert.IsNotNull(album);
			Assert.AreEqual("a1", album.Key);
			Assert.IsNotNull(album.Label);

			var artist = client.Core.GetAsync<RdioArtist>(album.ArtistKey, RdioArtist.Extras.All).Result;

			Assert.IsNotNull(artist);
			Assert.AreEqual(album.ArtistKey, artist.Key);
			Assert.IsTrue(artist.AlbumCount.HasValue);

			var label = client.Core.GetAsync<RdioLabel>(album.Label.Key).Result;

			Assert.IsNotNull(label);
			Assert.AreEqual(album.Label.Key, label.Key);
			Assert.AreEqual(album.Label.Name, label.Name);

			var tracks = client.Core.GetAsync<RdioTrack>(album.TrackKeys).Result;

			Assert.AreEqual(album.Length, tracks.Count);

			var playlist = client.Core.GetAsync<RdioPlaylist>("p1", RdioPlaylist.Extras.All).Result;

			Assert.IsNotNull(playlist);
			Assert.IsNotNull(playlist.TrackKeys);
			Assert.IsNotNull(playlist.Tracks);

			var user = client.Core.GetAsync<RdioUser>("s1", RdioUser.Extras.All).Result;

			Assert.IsNotNull(user);

			var collectionAlbum = client.Core.GetAsync<RdioCollectionAlbum>("al233072|100", RdioCollectionAlbum.Extras.All).Result;

			Assert.IsNotNull(collectionAlbum);

			var trash = client.Core.GetAsync<RdioObject>("asdasd").Result;

			Assert.IsNull(trash);

			Exception exception = null;

			try
			{
				 client.Core.GetAsync<RdioObject>("123asdasd").Wait();
			}
			catch (AggregateException ex)
			{
				exception = ex.Flatten().GetBaseException();
			}

			Assert.IsTrue(exception is RdioException);
		}

		[TestMethod]
		public void GetObjectFromShortCode()
		{
			var client = new RdioClient(ClientFactory.ConsumerKey, ClientFactory.ConsumerSecret, ClientFactory.AccessKey, ClientFactory.AccessSecret);

			var item = client.Core.GetObjectFromShortCodeAsync<RdioObject>("QitDAH7D").Result;

			Assert.IsNotNull(item);

			Exception exception = null;

			try
			{
				item = client.Core.GetObjectFromShortCodeAsync<RdioObject>("blablabla").Result;
			}
			catch (AggregateException ex)
			{
				exception = ex.Flatten().GetBaseException();
			}

			Assert.IsNotNull(exception);
		}

		[TestMethod]
		public void GetObjectFromUrl()
		{
			var client = new RdioClient(ClientFactory.ConsumerKey, ClientFactory.ConsumerSecret, ClientFactory.AccessKey, ClientFactory.AccessSecret);

			var item = client.Core.GetObjectFromUrlAsync<RdioObject>("/artist/Crystal_Castles/album/(III)/").Result;

			Assert.IsNotNull(item);
		}

		#endregion
	}
}