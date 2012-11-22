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
	/// Activity and Statistics methods of the Rdio API.
	/// </summary>
	public class ActivityMethods : MethodsBase
	{
		#region Construction and Initialization

		public ActivityMethods(RdioClient client)
			: base(client)
		{
		}

		#endregion

		#region Public Methods

		/// <summary>
		/// Get the activity events for a user, a user's friends, or everyone on Rdio.
		/// </summary>
		/// <param name="user">The user to retrieve an activity stream for.</param>
		/// <param name="scope">The scope of the activity stream.</param>
		/// <param name="lastId">he last id returned by the last call to this method.</param>
		/// <param name="count">The maximum number of results to return.</param>
		/// <param name="extras">The extra fields to be included in the object.</param>
		/// <returns>Returns an <seealso cref="RdioActivity"/> object with a collection of updates.
		/// Each update is an object whose class is derivated from <seealso cref="RdioActivityUpdate"/>.</returns>
		public Task<RdioActivity> GetActivityStreamAsync(string user, RdioActivityScope scope = RdioActivityScope.User, int lastId = 0, int count = 0, params string[] extras)
		{
			if (string.IsNullOrEmpty(user))
				throw new ArgumentNullException("user");

			var parameters = new Dictionary<string, string>
			{
				{ "user", user },
				{ "scope", scope.ToPascalCase() },
				{ "extras", extras.ToCommaSeparatedList() }
			};

			if (lastId > 0)
				parameters["last_id"] = lastId.ToString();

			if (count > 0)
				parameters["count"] = count.ToString();

			return PostAsync<RdioActivity>("getActivityStream", parameters);
		}

		/// <summary>
		/// Finds the most popular artists for a user, their friends or the whole site.
		/// </summary>
		/// <param name="user">The user, or everyone if this is missing.</param>
		/// <param name="friends">The user's friends's heavy rotation instead of the user's.</param>
		/// <param name="limit">The maximum number of results to return.</param>
		/// <param name="start">The offset of the first result to return</param>
		/// <param name="count">The maximum number of results to return.</param>
		/// <param name="extras">The extra fields to be included in the object.</param>
		/// <returns>Returns a list of <seealso cref="RdioArtist"/> objects, ordered by descending popularity.
		/// Additionally those objects have a Hits integer property indicating a relative popularity weight.</returns>
		public Task<IList<RdioArtist>> GetHeavyRotationByArtistsAsync(string user = null, bool friends = false, int limit = 0, int start = 0, int count = 0, params string[] extras)
		{
			var parameters = new Dictionary<string, string>
			{
				{ "user", user },
				{ "type", "artists" },
				{ "friends", Serializer.Serialize(friends) },
				{ "extras", extras.ToCommaSeparatedList() }
			};

			if (limit > 0)
				parameters["limit"] = limit.ToString();

			if (start > 0)
				parameters["start"] = start.ToString();

			if (count > 0)
				parameters["count"] = count.ToString();

			return PostAsync<IList<RdioArtist>>("getHeavyRotation", parameters);
		}

		/// <summary>
		/// Finds the most popular albums for a user, their friends or the whole site.
		/// </summary>
		/// <param name="user">The user, or everyone if this is missing.</param>
		/// <param name="friends">The user's friends's heavy rotation instead of the user's.</param>
		/// <param name="limit">The maximum number of results to return.</param>
		/// <param name="start">The offset of the first result to return</param>
		/// <param name="count">The maximum number of results to return.</param>
		/// <param name="extras">The extra fields to be included in the object.</param>
		/// <returns>Returns a list of <seealso cref="RdioAlbum"/> objects, ordered by descending popularity.
		/// Additionally those objects have a Hits integer property indicating a relative popularity weight.</returns>
		public Task<IList<RdioAlbum>> GetHeavyRotationByAlbumsAsync(string user = null, bool friends = false, int limit = 0, int start = 0, int count = 0, params string[] extras)
		{
			var parameters = new Dictionary<string, string>
			{
				{ "user", user },
				{ "type", "albums" },
				{ "friends", Serializer.Serialize(friends) },
				{ "extras", extras.ToCommaSeparatedList() }
			};

			if (limit > 0)
				parameters["limit"] = limit.ToString();

			if (start > 0)
				parameters["start"] = start.ToString();

			if (count > 0)
				parameters["count"] = count.ToString();

			return PostAsync<IList<RdioAlbum>>("getHeavyRotation", parameters);
		}

		/// <summary>
		/// Return new albums released across a timeframe.
		/// </summary>
		/// <param name="time">The timeframe</param>
		/// <param name="start">The offset of the first result to return</param>
		/// <param name="count">The maximum number of results to return.</param>
		/// <param name="extras">The extra fields to be included in the object.</param>
		/// <returns>Returns a list of <seealso cref="RdioAlbum"/> objects.</returns>
		public Task<IList<RdioAlbum>> GetNewReleasesAsync(RdioTimeframe time = RdioTimeframe.ThisWeek, int start = 0, int count = 0, params string[] extras)
		{
			var parameters = new Dictionary<string, string>
			{
				{ "time", time.ToString().ToLower() },
				{ "extras", extras.ToCommaSeparatedList() }
			};

			if (start > 0)
				parameters["start"] = start.ToString();

			if (count > 0)
				parameters["count"] = count.ToString();

			return PostAsync<IList<RdioAlbum>>("getNewReleases", parameters);
		}

		/// <summary>
		/// Return the site-wide most popular artists.
		/// </summary>
		/// <param name="start">The offset of the first result to return</param>
		/// <param name="count">The maximum number of results to return.</param>
		/// <param name="extras">The extra fields to be included in the object.</param>
		/// <returns>Returns a list of <seealso cref="RdioArtist"/> objects.</returns>
		public Task<IList<RdioArtist>> GetTopChartsByArtistAsync(int start = 0, int count = 0, params string[] extras)
		{
			return GetTopChartsAsync<RdioArtist>(RdioObjectType.Artist, start, count, extras);
		}

		/// <summary>
		/// Return the site-wide most popular albums.
		/// </summary>
		/// <param name="start">The offset of the first result to return</param>
		/// <param name="count">The maximum number of results to return.</param>
		/// <param name="extras">The extra fields to be included in the object.</param>
		/// <returns>Returns a list of <seealso cref="RdioAlbum"/> objects.</returns>
		public Task<IList<RdioAlbum>> GetTopChartsByAlbumAsync(int start = 0, int count = 0, params string[] extras)
		{
			return GetTopChartsAsync<RdioAlbum>(RdioObjectType.Album, start, count, extras);
		}

		/// <summary>
		/// Return the site-wide most popular tracks.
		/// </summary>
		/// <param name="start">The offset of the first result to return</param>
		/// <param name="count">The maximum number of results to return.</param>
		/// <param name="extras">The extra fields to be included in the object.</param>
		/// <returns>Returns a list of <seealso cref="RdioTrack"/> objects.</returns>
		public Task<IList<RdioTrack>> GetTopChartsByTrackAsync(int start = 0, int count = 0, params string[] extras)
		{
			return GetTopChartsAsync<RdioTrack>(RdioObjectType.Track, start, count, extras);
		}

		/// <summary>
		/// Return the site-wide most popular playlists.
		/// </summary>
		/// <param name="start">The offset of the first result to return</param>
		/// <param name="count">The maximum number of results to return.</param>
		/// <param name="extras">The extra fields to be included in the object.</param>
		/// <returns>Returns a list of <seealso cref="RdioPlaylist"/> objects.</returns>
		public Task<IList<RdioPlaylist>> GetTopChartsByPlaylistAsync(int start = 0, int count = 0, params string[] extras)
		{
			return GetTopChartsAsync<RdioPlaylist>(RdioObjectType.Playlist, start, count, extras);
		}

		/// <summary>
		/// Return the site-wide most popular items for a given type.
		/// </summary>
		/// <param name="type">The types to include in results. Valid values are Artist, Album, Track and Playlist.</param>
		/// <param name="start">The offset of the first result to return</param>
		/// <param name="count">The maximum number of results to return.</param>
		/// <param name="extras">The extra fields to be included in the object.</param>
		/// <returns>Returns a list of <seealso cref="RdioArtist"/>, <seealso cref="RdioAlbum"/>, <seealso cref="RdioTrack"/> or 
		/// <seealso cref="RdioPlaylist"/> objects, depending on the <see cref="type"/> argument.</returns>
		public Task<IList<T>> GetTopChartsAsync<T>(RdioObjectType type, int start = 0, int count = 0, params string[] extras)
			where T : RdioObject
		{
			if (type != RdioObjectType.Album && type != RdioObjectType.Artist && type != RdioObjectType.Playlist && type != RdioObjectType.Track)
				throw new ArgumentOutOfRangeException("type", string.Format("The {0} object type is not supported.", type));

			var parameters = new Dictionary<string, string>
			{
				{ "type", type.ToString() },
				{ "extras", extras.ToCommaSeparatedList() }
			};

			if (start > 0)
				parameters["start"] = start.ToString();

			if (count > 0)
				parameters["count"] = count.ToString();

			return PostAsync<IList<T>>("getTopCharts", parameters);
		}

		#endregion
	}
}