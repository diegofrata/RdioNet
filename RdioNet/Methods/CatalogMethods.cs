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
	/// Catalog methods of the Rdio API.
	/// </summary>
	public sealed class CatalogMethods : MethodsBase
	{
		#region Construction and Initialization

		public CatalogMethods(RdioClient client)
			: base(client)
		{
		}

		#endregion

		#region Public Methods

		/// <summary>
		/// Finds and returns albums based on their Universal Product Code (UPC).
		/// </summary>
		/// <param name="upc">The UPC code to search for.</param>
		/// <param name="extras">The extra fields to be included in the object.</param>
		/// <returns>A list of Album objects that have the supplied UPC.</returns>
		public Task<IList<RdioAlbum>> GetAlbumsByUpcAsync(string upc, params string[] extras)
		{
			if (string.IsNullOrEmpty(upc))
				throw new ArgumentNullException("upc");

			return PostAsync<IList<RdioAlbum>>("getAlbumsByUPC", new Dictionary<string, string>
			{
				{ "upc", upc },
				{ "extras", extras.ToCommaSeparatedList() }
			});
		}

		/// <summary>
		/// Gets the albums by (or featuring) an artist.
		/// </summary>
		/// <param name="artist">The artist's key</param>
		/// <param name="start">The offset of the first result to return.</param>
		/// <param name="count">The maximum number of results to return.</param>
		/// <param name="featuring">Return only albums featuring the artist rather than albums credited to the artist.</param>
		/// <param name="extras">The extra fields to be included in the object.</param>
		/// <returns>Returns a list of albums.</returns>
		public Task<IList<RdioAlbum>> GetAlbumsForArtistAsync(string artist, bool featuring = false, int start = 0, int count = 0, params string[] extras)
		{
			if (string.IsNullOrEmpty(artist))
				throw new ArgumentNullException("artist");

			var parameters = new Dictionary<string, string>
			{
				{ "artist", artist },
				{ "featuring", Serializer.Serialize(featuring) },
				{ "extras", extras.ToCommaSeparatedList() }
			};

			if (start > 0)
				parameters["start"] = start.ToString();

			if (count > 0)
				parameters["count"] = count.ToString();

			return PostAsync<IList<RdioAlbum>>("getAlbumsForArtist", parameters);
		}

		/// <summary>
		/// 	Gets the albums for a label.
		/// </summary>
		/// <param name="label">The label's key.</param>
		/// <param name="start">The offset of the first result to return.</param>
		/// <param name="count">The maximum number of results to return.</param>
		/// <param name="extras">The extra fields to be included in the object.</param>
		/// <returns>Returns a list of albums.</returns>
		public Task<IList<RdioAlbum>> GetAlbumsForLabelAsync(string label, int start = 0, int count = 0, params string[] extras)
		{
			if (string.IsNullOrEmpty(label))
				throw new ArgumentNullException("label");

			var parameters = new Dictionary<string, string>
			{
				{ "label", label },
				{ "extras", extras.ToCommaSeparatedList() }
			};

			if (start > 0)
				parameters["start"] = start.ToString();

			if (count > 0)
				parameters["count"] = count.ToString();

			return PostAsync<IList<RdioAlbum>>("getAlbumsForLabel", parameters);
		}

		/// <summary>
		/// 	Gets the artists for a label.
		/// </summary>
		/// <param name="label">The label's key.</param>
		/// <param name="start">The offset of the first result to return.</param>
		/// <param name="count">The maximum number of results to return.</param>
		/// <param name="extras">The extra fields to be included in the object.</param>
		/// <returns>Returns a list of artists.</returns>
		public Task<IList<RdioArtist>> GetArtistsForLabelAsync(string label, int start = 0, int count = 0, params string[] extras)
		{
			if (string.IsNullOrEmpty(label))
				throw new ArgumentNullException("label");

			var parameters = new Dictionary<string, string>
			{
				{ "label", label },
				{ "extras", extras.ToCommaSeparatedList() }
			};

			if (start > 0)
				parameters["start"] = start.ToString();

			if (count > 0)
				parameters["count"] = count.ToString();

			return PostAsync<IList<RdioArtist>>("getArtistsForLabel", parameters);
		}

		/// <summary>
		/// Finds and returns tracks based on their International Standard Recording Code (ISRC).
		/// </summary>
		/// <param name="isrc">The ISRC code to search for.</param>
		/// <returns>Returns a list of tracks that have the supplied ISRC.</returns>
		public Task<IList<RdioTrack>> GetTracksByIsrcAsync(string isrc, params string[] extras)
		{
			if (string.IsNullOrEmpty(isrc))
				throw new ArgumentNullException("isrc");

			return PostAsync<IList<RdioTrack>>("getTracksByISRC", new Dictionary<string, string>
			{
				{ "isrc", isrc },
				{ "extras", extras.ToCommaSeparatedList() }
			});
		}

		/// <summary>
		/// Gets all the tracks by a given artist.
		/// </summary>
		/// <param name="artist">The artist's key.</param>
		/// <param name="appearsOn">Returns tracks that the artist appears on rather than tracks credited to the artist.</param>
		/// <param name="start">The offset of the first result to return.</param>
		/// <param name="count">The maximum number of results to return.</param>
		/// <param name="extras">The extra fields to be included in the object.</param>
		/// <returns>Returns a list of tracks.</returns>
		public Task<IList<RdioTrack>> GetTracksForArtistAsync(string artist, bool appearsOn = false, int start = 0, int count = 0, params string[] extras)
		{
			if (string.IsNullOrEmpty(artist))
				throw new ArgumentNullException("artist");

			var parameters = new Dictionary<string, string>
			{
				{ "artist", artist },
				{ "appears_on", Serializer.Serialize(appearsOn) },
				{ "extras", extras.ToCommaSeparatedList() }
			};

			if (start > 0)
				parameters["start"] = start.ToString();

			if (count > 0)
				parameters["count"] = count.ToString();

			return PostAsync<IList<RdioTrack>>("getTracksForArtist", parameters);
		}

		/// <summary>
		/// Search for artists, albums, tracks, users or all kinds of objects
		/// </summary>
		/// <typeparam name="T">The type of the object expected to return or <seealso cref="RdioObject"/> if multiple types are expected.</typeparam>
		/// <param name="query">The search query.</param>
		/// <param name="types">The types to include in results.</param>
		/// <param name="neverOr">Search uses an AND query that falls back to an OR query if there are no results, passing true here will disable that fallback.</param>
		/// <param name="start">The offset of the first result to return.</param>
		/// <param name="count">The maximum number of results to return.</param>
		/// <param name="extras">The extra fields to be included in the object.</param>
		/// <returns>Returns a list of objects.</returns>
		public Task<RdioSearchResult<T>> SearchAsync<T>(string query, RdioObjectType types, bool neverOr = false, int start = 0, int count = 0, params string[] extras)
			where T : RdioObject
		{
			if (string.IsNullOrEmpty(query))
				throw new ArgumentNullException("query");

			if (types == RdioObjectType.Unknown)
				throw new ArgumentException("Types must have at least one value set.", "types");

			var parameters = new Dictionary<string, string>
			{
				{ "query", query },
				{ "types", types.ToCommaSeparatedList() },
				{ "never_or", Serializer.Serialize(neverOr) },
				{ "extras", extras.ToCommaSeparatedList() }
			};

			if (start > 0)
				parameters["start"] = start.ToString();

			if (count > 0)
				parameters["count"] = count.ToString();

			return PostAsync<RdioSearchResult<T>>("search", parameters);
		}

		/// <summary>
		/// Match the supplied prefix against artists, albums, tracks, playlists and people in the Rdio system. Return the first ten matches.
		/// </summary>
		/// <typeparam name="T">The type of the object expected to return or <seealso cref="RdioObject"/> if multiple types are expected.</typeparam>
		/// <param name="query">The search query.</param>
		/// <param name="types">The types to include in results.</param>
		/// <param name="extras">The extra fields to be included in the object.</param>
		/// <returns>Returns an list of objects matching the search prefix.</returns>
		public Task<IList<T>> SearchSuggestionsAsync<T>(string query, RdioObjectType types, params string[] extras)
			where T : RdioObject
		{
			if (string.IsNullOrEmpty(query))
				throw new ArgumentNullException("query");

			if (types == RdioObjectType.Unknown)
				throw new ArgumentException("Types must have at least one value set.", "types");

			return PostAsync<IList<T>>("searchSuggestions", new Dictionary<string, string>
			{
				{ "query", query },
				{ "types", types.ToCommaSeparatedList() },
				{ "extras", extras.ToCommaSeparatedList() }
			});
		}

		#endregion
	}
}