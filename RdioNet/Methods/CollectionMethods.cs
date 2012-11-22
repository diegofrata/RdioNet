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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RdioNet.Models;
using RdioNet.Serialization;
using RdioNet.Util;

#endregion

namespace RdioNet.Methods
{
	/// <summary>
	/// Collection methods of the Rdio API.
	/// </summary>
	public class CollectionMethods : MethodsBase
	{
		#region Construction and Initialization

		public CollectionMethods(RdioClient client)
			: base(client)
		{
		}

		#endregion

		#region Public Methods

		/// <summary>
		/// Add tracks or playlists to the current user's collection. Authentication is required.
		/// </summary>
		/// <param name="keys">The tracks and playlists to add to the collection.</param>
		/// <returns>Always returns <value>true</value>.</returns>
		public Task<bool> AddToCollectionAsync(params string[] keys)
		{
			return AddToCollectionAsync(keys.AsEnumerable());
		}

		/// <summary>
		/// Add tracks or playlists to the current user's collection. Authentication is required.
		/// </summary>
		/// <param name="keys">The tracks and playlists to add to the collection.</param>
		/// <returns>Always returns <value>true</value>.</returns>
		public Task<bool> AddToCollectionAsync(IEnumerable<string> keys)
		{
			if (keys == null || !keys.Any())
				throw new ArgumentException("At least one key must be informed.", "keys");

			return PostAsync<bool>("addToCollection", new Dictionary<string, string>
			{
				{ "keys", keys.ToCommaSeparatedList() }
			});
		}

		/// <summary>
		/// Get the albums in the user's collection by a particular artist.
		/// </summary>
		/// <param name="artist">The artist's key.</param>
		/// <param name="user">The user's key or null to use the current authenticated user.</param>
		/// <param name="sort">The sorting direction of the results. Only Name and ReleaseDate are supported.</param>
		/// <param name="extras">The extra fields to be included in the object.</param>
		/// <returns>Returns a list of <seealso cref="RdioCollectionAlbum"/> objects.</returns>
		public Task<IList<RdioCollectionAlbum>> GetAlbumsForArtistInCollectionAsync(string artist, string user = null, RdioSortingFields sort = RdioSortingFields.ReleaseDate, params string[] extras)
		{
			if (string.IsNullOrEmpty(artist))
				throw new ArgumentNullException("artist");

			if (sort != RdioSortingFields.Name && sort != RdioSortingFields.ReleaseDate)
				throw new ArgumentOutOfRangeException("sort", string.Format("The {0} sorting option is not supported.", sort));

			return PostAsync<IList<RdioCollectionAlbum>>("addToCollection", new Dictionary<string, string>
			{
				{ "artist", artist },
				{ "user", user },
				{ "sort", sort.ToPascalCase() },
				{ "extras", extras.ToCommaSeparatedList() }
			});
		}

		/// <summary>
		/// Get all of the albums in the user's collection.
		/// </summary>
		/// <param name="user">The user's key or null to use the current authenticated user.</param>
		/// <param name="query">Filter collection's albums by the query.</param>
		/// <param name="start">The offset of the first result to return.</param>
		/// <param name="count">The maximum number of results to return.</param>
		/// <param name="sort">The sorting direction of the results. Only DateAdded, PlayCount, Artist and Name supported.</param>
		/// <param name="extras">The extra fields to be included in the object.</param>
		/// <returns>Returns a list of <seealso cref="RdioCollectionAlbum"/> objects.</returns>
		public Task<IList<RdioCollectionAlbum>> GetAlbumsInCollectionAsync(string user = null, string query = null, int start = 0, int count = 0, RdioSortingFields sort = RdioSortingFields.Name, params string[] extras)
		{
			if (sort != RdioSortingFields.DateAdded && sort != RdioSortingFields.PlayCount && sort != RdioSortingFields.Artist && sort != RdioSortingFields.Name)
				throw new ArgumentOutOfRangeException("sort", string.Format("The {0} sorting option is not supported.", sort));

			var parameters = new Dictionary<string, string>
			{
				{ "user", user },
				{ "query", query },
				{ "sort", sort.ToPascalCase() },
				{ "extras", extras.ToCommaSeparatedList() }
			};

			if (start > 0)
				parameters["start"] = start.ToString();

			if (count > 0)
				parameters["count"] = count.ToString();

			return PostAsync<IList<RdioCollectionAlbum>>("getAlbumsInCollection", parameters);
		}

		/// <summary>
		/// Gets all the artists in a user's collection.
		/// </summary>
		/// <param name="user">The user's key or null to use the current authenticated user.</param>
		/// <param name="query">Filter collection's artists by the query.</param>
		/// <param name="start">The offset of the first result to return.</param>
		/// <param name="count">The maximum number of results to return.</param>
		/// <param name="sort">The sorting direction of the results. Only Name and PlayCount are supported.</param>
		/// <param name="extras">The extra fields to be included in the object.</param>
		/// <returns>Returns a list of <seealso cref="RdioCollectionArtist"/> objects.</returns>
		public Task<IList<RdioCollectionArtist>> GetArtistsInCollectionAsync(string user = null, string query = null, int start = 0, int count = 0, RdioSortingFields sort = RdioSortingFields.Name, params string[] extras)
		{
			if (sort != RdioSortingFields.Name && sort != RdioSortingFields.PlayCount)
				throw new ArgumentOutOfRangeException("sort", string.Format("The {0} sorting option is not supported.", sort));

			var parameters = new Dictionary<string, string>
			{
				{ "user", user },
				{ "query", query },
				{ "sort", sort.ToPascalCase() },
				{ "extras", extras.ToCommaSeparatedList() }
			};

			if (start > 0)
				parameters["start"] = start.ToString();

			if (count > 0)
				parameters["count"] = count.ToString();

			return PostAsync<IList<RdioCollectionArtist>>("getArtistsInCollection", parameters);
		}

		/// <summary>
		/// Gets which tracks on the given album are in the user's collection.
		/// </summary>
		/// <param name="album">The album's key.</param>
		/// <param name="user">The user's key or null to use the current authenticated user.</param>
		/// <param name="extras">The extra fields to be included in the object.</param>
		/// <returns>A list of tracks on the given album.</returns>
		public Task<IList<RdioTrack>> GetTracksForAlbumInCollectionAsync(string album, string user = null, params string[] extras)
		{
			if (string.IsNullOrEmpty(album))
				throw new ArgumentNullException("album");

			return PostAsync<IList<RdioTrack>>("getTracksForAlbumInCollection", new Dictionary<string, string>
			{
				{ "album", album },
				{ "user", user},
				{ "extras", extras.ToCommaSeparatedList() }
			});
		}

		/// <summary>
		/// Gets which tracks from the given artist are in the user's collection.
		/// </summary>
		/// <param name="artist">The artist's key.</param>
		/// <param name="user">The user's key or null to use the current authenticated user.</param>
		/// <param name="extras">The extra fields to be included in the object.</param>
		/// <returns>A list of tracks on the given album.</returns>
		public Task<IList<RdioTrack>> GetTracksForArtistInCollectionAsync(string artist, string user = null, params string[] extras)
		{
			if (string.IsNullOrEmpty(artist))
				throw new ArgumentNullException("artist");

			return PostAsync<IList<RdioTrack>>("getTracksForArtistInCollection", new Dictionary<string, string>
			{
				{ "artist", artist },
				{ "user", user},
				{ "extras", extras.ToCommaSeparatedList() }
			});
		}

		/// <summary>
		/// Gets all the tracks in the user's collection..
		/// </summary>
		/// <param name="user">The user's key or null to use the current authenticated user.</param>
		/// <param name="query">Filter collection's albums by the query.</param>
		/// <param name="start">The offset of the first result to return.</param>
		/// <param name="count">The maximum number of results to return.</param>
		/// <param name="sort">The sorting direction of the results. Only DateAdded, PlayCount, Artist, Album and Name supported.</param>
		/// <param name="extras">The extra fields to be included in the object.</param>
		/// <returns>Returns a list of <seealso cref="RdioCollectionAlbum"/> objects.</returns>
		public Task<IList<RdioTrack>> GetTracksInCollectionAsync(string user = null, string query = null, int start = 0, int count = 0, RdioSortingFields sort = RdioSortingFields.Name, params string[] extras)
		{
			if (sort != RdioSortingFields.DateAdded && sort != RdioSortingFields.PlayCount && sort != RdioSortingFields.Artist && sort != RdioSortingFields.Name && sort != RdioSortingFields.Album)
				throw new ArgumentOutOfRangeException("sort", string.Format("The {0} sorting option is not supported.", sort));

			var parameters = new Dictionary<string, string>
			{
				{ "user", user },
				{ "query", query },
				{ "sort", sort.ToPascalCase() },
				{ "extras", extras.ToCommaSeparatedList() }
			};

			if (start > 0)
				parameters["start"] = start.ToString();

			if (count > 0)
				parameters["count"] = count.ToString();

			return PostAsync<IList<RdioTrack>>("getTracksInCollection", parameters);
		}

		/// <summary>
		/// Removes tracks or playlists to the current user's collection. Authentication is required.
		/// </summary>
		/// <param name="keys">The tracks and playlists to remove from the collection.</param>
		/// <returns>Returns <value>true</value> if the remove succeeds or <value>false</value> if the remove fails.</returns>
		public Task<bool> RemoveFromCollectionAsync(params string[] keys)
		{
			return RemoveFromCollectionAsync(keys.AsEnumerable());
		}

		/// <summary>
		/// Removes tracks or playlists to the current user's collection. Authentication is required.
		/// </summary>
		/// <param name="keys">The tracks and playlists to remove from the collection.</param>
		/// <returns>Returns <value>true</value> if the remove succeeds or <value>false</value> if the remove fails.</returns>
		public Task<bool> RemoveFromCollectionAsync(IEnumerable<string> keys)
		{
			if (keys == null || !keys.Any())
				throw new ArgumentException("At least one key must be informed.", "keys");

			return PostAsync<bool>("removeFromCollection", new Dictionary<string, string>
			{
				{ "keys", keys.ToCommaSeparatedList() }
			});
		}

		/// <summary>
		/// Mark tracks or playlists for offline syncing. Authentication is required.
		/// </summary>
		/// <param name="keys">The tracks and playlists to be marked.</param>
		/// <returns>Returns <value>true</value> if the remove succeeds or <value>false</value> if the remove fails.</returns>
		public Task<bool> SetAvailableOfflineAsync(bool offline, params string[] keys)
		{
			return SetAvailableOfflineAsync(offline, keys.AsEnumerable());
		}

		/// <summary>
		/// Mark tracks or playlists for offline syncing. Authentication is required.
		/// </summary>
		/// <param name="keys">The tracks and playlists to be marked.</param>
		/// <returns>Returns <value>true</value> if the remove succeeds or <value>false</value> if the remove fails.</returns>
		public Task<bool> SetAvailableOfflineAsync(bool offline, IEnumerable<string> keys)
		{
			if (keys == null || !keys.Any())
				throw new ArgumentException("At least one key must be informed.", "keys");

			return PostAsync<bool>("setAvailableOffline", new Dictionary<string, string>
			{
				{ "offline", Serializer.Serialize(offline) },
				{ "keys", keys.ToCommaSeparatedList() }
			});
		}

		#endregion
	}
}