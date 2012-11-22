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
using RdioNet.Models.Results;
using RdioNet.Serialization;
using RdioNet.Util;

#endregion

namespace RdioNet.Methods
{
	/// <summary>
	/// Playlists methods of the Rdio API.
	/// </summary>
	public class PlaylistsMethods : MethodsBase
	{
		#region Construction and Initialization

		public PlaylistsMethods(RdioClient client)
			: base(client)
		{
		}

		#endregion

		#region Public Methods

		/// <summary>
		/// Adds tracks to a playlist. Authentication is required.
		/// </summary>
		/// <param name="playlist">The playlist's key.</param>
		/// <param name="keys">A collection of tracks to add to the playlist.</param>
		/// <param name="extras">The extra fields to be included in the returned <seealso cref="RdioPlaylist"/>.</param>
		/// <returns>A <seealso cref="RdioPlaylist"/> object with the added tracks.</returns>
		public Task<RdioPlaylist> AddToPlaylistAsync(string playlist, IEnumerable<string> keys, params string[] extras)
		{
			if (string.IsNullOrEmpty(playlist))
				throw new ArgumentNullException("playlist");

			if (keys == null || !keys.Any())
				throw new ArgumentException("At least one key must be informed.", "keys");

			return PostAsync<RdioPlaylist>("addToPlaylist", new Dictionary<string, string>
			{
				{ "playlist", playlist },
				{ "keys", keys.ToCommaSeparatedList() },
				{ "extras", extras.ToCommaSeparatedList() }
			});
		}

		/// <summary>
		/// Creates a new playlist in the current user's collection. The new playlist will be returned
		/// if the creation is successful, otherwise null will be returned. Authentication is required.
		/// </summary>
		/// <param name="name">The playlist's name.</param>
		/// <param name="description">The playlist's description.</param>
		/// <param name="keys">The initial tracks of the playlist.</param>
		/// <param name="extras">The extra fields to be included in the returned <seealso cref="RdioPlaylist"/>.</param>
		/// <returns>Returns the new <seealso cref="RdioPlaylist"/>.</returns>
		public Task<RdioPlaylist> CreatePlaylistAsync(string name, string description, IEnumerable<string> keys, params string[] extras)
		{
			if (string.IsNullOrEmpty(name))
				throw new ArgumentNullException("name");

			if (string.IsNullOrEmpty(description))
				throw new ArgumentOutOfRangeException("description");

			if (keys == null || !keys.Any())
				throw new ArgumentException("At least one key must be informed.", "keys");

			return PostAsync<RdioPlaylist>("createPlaylist", new Dictionary<string, string>
			{
				{ "name", name },
				{ "description", description },
				{ "keys", keys.ToCommaSeparatedList() },
				{ "extras", extras.ToCommaSeparatedList() }
			});
		}

		/// <summary>
		/// Deletes a playlist. Authentication is required.
		/// </summary>
		/// <param name="playlist">The playlist's key.</param>
		/// <returns>Returns <value>true</value> on success but <value>false</value> on failure.</returns>
		public Task<bool> DeletePlaylistAsync(string playlist)
		{
			if (string.IsNullOrEmpty(playlist))
				throw new ArgumentNullException("playlist");

			return PostAsync<bool>("deletePlaylist", new Dictionary<string, string>
			{
				{ "playlist", playlist }
			});
		}

		/// <summary>
		/// Gets a user's playlists. If no user is specified then the current user will be used.
		/// </summary>
		/// <param name="user">The user's key or null to use the current authenticated user.</param>
		/// <param name="orderedList">True if the playlists should be returned as an ordered list.</param>	 
		/// <param name="extras">The extra fields to be included in the returned <seealso cref="RdioPlaylist"/>.</param>
		/// <returns>Returns an object containing three arrays of Playlist objects, owned (playlists created by the user), 
		/// collab (playlists that the user is a collaborator on), and subscribed (playlists that the user has subscribed to)</returns>
		public Task<RdioPlaylistsResult> GetPlaylistsAsync(string user = null, bool orderedList = false, params string[] extras)
		{
			return PostAsync<RdioPlaylistsResult>("getPlaylists", new Dictionary<string, string>
			{
				{ "user", user },
				{ "ordered_list", Serializer.Serialize(orderedList) },
				{ "extras", extras.ToCommaSeparatedList() }
			});
		}

		/// <summary>
		/// Gets a user's playlist.
		/// </summary>
		/// <param name="user">The user's key.</param>
		/// <param name="kind">The kind of playlists to be returned.</param>
		/// <param name="sort">The sorting direction of the results. Only Name and LastUpdated are supported.</param>
		/// <param name="start">The offset of the first result to return.</param>
		/// <param name="count">The maximum number of results to return.</param>
		/// <param name="extras">The extra fields to be included in the returned <seealso cref="RdioPlaylist"/>.</param>
		/// <returns>A list of <seealso cref="RdioPlaylist"/> objects matching the filter.</returns>
		public Task<IList<RdioPlaylist>> GetUserPlaylistsAsync(string user, RdioPlaylistKind kind = RdioPlaylistKind.Unknown, RdioSortingFields sort = RdioSortingFields.LastUpdated, int start = 0, int count = 0, params string[] extras)
		{
			if (string.IsNullOrEmpty(user))
				throw new ArgumentNullException("user");

			if (sort != RdioSortingFields.Name && sort != RdioSortingFields.LastUpdated)
				throw new ArgumentOutOfRangeException("sort", string.Format("The {0} sorting option is not supported.", sort));

			var parameters = new Dictionary<string, string>
			{
				{ "user", user },
				{ "sort", sort.ToPascalCase() },
				{ "extras", extras.ToCommaSeparatedList() }
			};

			if (kind != RdioPlaylistKind.Unknown)
				parameters["kind"] = kind.ToPascalCase();

			if (start > 0)
				parameters["start"] = start.ToString();

			if (count > 0)
				parameters["count"] = count.ToString();

			return PostAsync<IList<RdioPlaylist>>("getUserPlaylists", parameters);
		}

		/// <summary>
		/// Removes items from a playlist by range (index and count). All track keys to remove must 
		/// be in the tracks list too. This is to prevent accidental overwriting of playlist changes.
		/// Authentication is required.
		/// </summary>
		/// <param name="playlist">The playlist's key.</param>
		/// <param name="index">The index of the first item to remove.</param>
		/// <param name="count">The number of tracks to remove from the playlist.</param>
		/// <param name="tracks">The keys of tracks to remove.</param>
		/// <param name="extras">The extra fields to be included in the returned <seealso cref="RdioPlaylist"/>.</param>
		/// <returns>Returns the <seealso cref="RdioPlaylist"/> object on success or null on failure.</returns>
		public Task<RdioPlaylist> RemoveFromPlaylistAsync(string playlist, int index, int count, IEnumerable<string> tracks, params string[] extras)
		{
			if (string.IsNullOrEmpty(playlist))
				throw new ArgumentNullException("playlist");

			if (index < 0)
				throw new ArgumentOutOfRangeException("index");

			if (count <= 0)
				throw new ArgumentOutOfRangeException("count");

			if (tracks == null || !tracks.Any())
				throw new ArgumentException("At least one track must be informed.", "tracks");

			return PostAsync<RdioPlaylist>("removeFromPlaylist", new Dictionary<string, string>
			{
				{ "playlist", playlist },
				{ "index", index.ToString() },
				{ "count", count.ToString() },
				{ "tracks", tracks.ToCommaSeparatedList() },
				{ "extras", extras.ToCommaSeparatedList() }
			});
		}

		/// <summary>
		/// Start or stop collaborating on this playlist. Authentication is required.
		/// </summary>
		/// <param name="playlist">The playlist's key.</param>
		/// <param name="collaborating">Set the user collaboration status for this playlist.</param>
		/// <returns>Returns <value>true</value> on success or <value>false</value> on failure.</returns>
		public Task<bool> SetPlaylistCollaboratingAsync(string playlist, bool collaborating)
		{
			if (string.IsNullOrEmpty(playlist))
				throw new ArgumentNullException("playlist");

			return PostAsync<bool>("setPlaylistCollaborating", new Dictionary<string, string>
			{
				{ "playlist", playlist },
				{ "collaborating", Serializer.Serialize(collaborating) },
			});
		}

		/// <summary>
		/// Set the playlist collaboration mode. Authentication is required.
		/// </summary>
		/// <param name="playlist">The playlist's key.</param>
		/// <param name="mode">The new collaboration mode for the playlist.</param>
		/// <returns>Returns <value>true</value> on success or <value>false</value> on failure.</returns>
		public Task<bool> SetPlaylistCollaborationModeAsync(string playlist, RdioPlaylistCollaborationMode mode)
		{
			if (string.IsNullOrEmpty(playlist))
				throw new ArgumentNullException("playlist");

			return PostAsync<bool>("setPlaylistCollaborating", new Dictionary<string, string>
			{
				{ "playlist", playlist },
				{ "mode", ((int) mode).ToString() },
			});
		}

		/// <summary>
		/// Sets the name and description for a playlist. Authentication is required.
		/// </summary>
		/// <param name="playlist">The playlist's key.</param>
		/// <param name="name">The new name for the playlist.</param>
		/// <param name="description">The new description for the playlist.</param>
		/// <returns>Returns <value>true</value> on success or <value>false</value> on failure.</returns>
		public Task<bool> SetPlaylistFieldsAsync(string playlist, string name, string description)
		{
			if (string.IsNullOrEmpty(playlist))
				throw new ArgumentNullException("playlist");

			if (string.IsNullOrEmpty(name))
				throw new ArgumentNullException("name");

			if (string.IsNullOrEmpty(description))
				throw new ArgumentNullException("description");

			return PostAsync<bool>("setPlaylistFields", new Dictionary<string, string>
			{
				{ "playlist", playlist },
				{ "name", name },
				{ "description", description }
			});
		}

		/// <summary>
		/// Saves the given order of tracks in a given playlist. The new order must have the same tracks 
		/// as the previous order (this method may not be used to add/remove tracks). Authentication is required.
		/// </summary>
		/// <param name="playlist">The playlist's key.</param>
		/// <param name="tracks">The list of the reordered tracks' keys.</param>
		/// <param name="extras">The extra fields to be included in the returned <seealso cref="RdioPlaylist"/>.</param>
		/// <returns>Returns the <seealso cref="RdioPlaylist"/> object on success or null on failure.</returns>
		public Task<RdioPlaylist> SetPlaylistOrderAsync(string playlist, IEnumerable<string> tracks, params string[] extras)
		{
			if (string.IsNullOrEmpty(playlist))
				throw new ArgumentNullException("playlist");

			if (tracks == null || !tracks.Any())
				throw new ArgumentException("At least one track must be informed.", "tracks");

			return PostAsync<RdioPlaylist>("setPlaylistOrder", new Dictionary<string, string>
			{
				{ "playlist", playlist },
				{ "tracks", tracks.ToCommaSeparatedList() },
				{ "extras", extras.ToCommaSeparatedList() }
			});
		}

		#endregion
	}
}