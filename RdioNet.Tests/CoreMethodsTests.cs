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
		public async Task Get()
		{
			var client = new RdioClient(Constants.ConsumerKey, Constants.ConsumerSecret, Constants.AccessKey, Constants.AccessSecret);

			var album = await client.Core.GetAsync<RdioAlbum>("a1", new Dictionary<string, string> { { "test", "test" } }, RdioAlbum.Extras.All);

			Assert.IsNotNull(album);
			Assert.AreEqual("a1", album.Key);
			Assert.IsNotNull(album.Label);

			var artist = await client.Core.GetAsync<RdioArtist>(album.ArtistKey, RdioArtist.Extras.All);

			Assert.IsNotNull(artist);
			Assert.AreEqual(album.ArtistKey, artist.Key);
			Assert.IsTrue(artist.AlbumCount.HasValue);

			var label = await client.Core.GetAsync<RdioLabel>(album.Label.Key);

			Assert.IsNotNull(label);
			Assert.AreEqual(album.Label.Key, label.Key);
			Assert.AreEqual(album.Label.Name, label.Name);

			var tracks = await client.Core.GetAsync<RdioTrack>(album.TrackKeys);

			Assert.AreEqual(album.Length, tracks.Count);

			var playlist = await client.Core.GetAsync<RdioPlaylist>("p1", RdioPlaylist.Extras.All);

			Assert.IsNotNull(playlist);
			Assert.IsNotNull(playlist.TrackKeys);
			Assert.IsNotNull(playlist.Tracks);

			var user = await client.Core.GetAsync<RdioUser>("s1", RdioUser.Extras.All);

			Assert.IsNotNull(user);

			var collectionAlbum = await client.Core.GetAsync<RdioCollectionAlbum>("al233072|100", RdioCollectionAlbum.Extras.All);

			Assert.IsNotNull(collectionAlbum);

			var trash = await client.Core.GetAsync<RdioObject>("asdasd");

			Assert.IsNull(trash);

			Exception exception = null;

			try
			{
				await client.Core.GetAsync<RdioObject>("123asdasd");
			}
			catch (Exception ex)
			{
				exception = ex;
			}

			Assert.IsTrue(exception is RdioException);
		}

		[TestMethod]
		public async Task GetObjectFromShortCode()
		{
			var client = new RdioClient(Constants.ConsumerKey, Constants.ConsumerSecret, Constants.AccessKey, Constants.AccessSecret);

			var item = await client.Core.GetObjectFromShortCodeAsync<RdioObject>("QitDAH7D");

			Assert.IsNotNull(item);

			Exception exception = null;

			try
			{
				item = await client.Core.GetObjectFromShortCodeAsync<RdioObject>("blablabla");
			}
			catch (Exception ex)
			{
				exception = ex;
			}

			Assert.IsNotNull(exception);
		}

		[TestMethod]
		public async Task GetObjectFromUrl()
		{
			var client = new RdioClient(Constants.ConsumerKey, Constants.ConsumerSecret, Constants.AccessKey, Constants.AccessSecret);

			var item = await client.Core.GetObjectFromUrlAsync<RdioObject>("/artist/Crystal_Castles/album/(III)/");

			Assert.IsNotNull(item);
		}

		#endregion
	}
}