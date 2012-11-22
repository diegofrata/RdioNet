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
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RdioNet.Models.Extras;
using RdioNet.Util;

#endregion

namespace RdioNet.Models
{
	/// <summary>
	/// Represents an Rdio user.
	/// </summary>
	[DebuggerDisplay("{FirstName,nq} {LastName,nq}")]
	public class RdioUser : RdioObject
	{
		#region Public Properties

		/// <summary>
		/// The first name of the user.
		/// </summary>
		public string FirstName
		{
			get;
			set;
		}

		/// <summary>
		/// The last name of the user.
		/// </summary>
		public string LastName
		{
			get;
			set;
		}

		/// <summary>
		/// The URL of an image of the user.
		/// </summary>
		public Uri Icon
		{
			get;
			set;
		}

		/// <summary>
		/// The relative URL of an image of the user.
		/// </summary>
		public string BaseIcon
		{
			get;
			set;
		}

		/// <summary>
		/// The library version of the user, used to determine if a user's collection has changed.
		/// </summary>
		public int LibraryVersion
		{
			get;
			set;
		}

		/// <summary>
		/// The relative URL of the user on Rdio web site.
		/// </summary>
		public string Url
		{
			get;
			set;
		}

		/// <summary>
		/// The gender of the user.
		/// </summary>
		public RdioUserGender Gender
		{
			get;
			set;
		}

		/// <summary>
		/// Extra. The relative URL of the user's following page.
		/// </summary>
		public string FollowingUrl
		{
			get;
			set;
		}

		/// <summary>
		/// Extra. Identifies if the user is an trial period.
		/// </summary>
		public bool? IsTrial
		{
			get;
			set;
		}

		/// <summary>
		/// Extra. The number of artists in the user's collection.
		/// </summary>
		public int? ArtistCount
		{
			get;
			set;
		}

		/// <summary>
		/// Extra. The last song the user has played.
		/// </summary>
		public RdioTrack LastSongPlayed
		{
			get;
			set;
		}

		/// <summary>
		/// Extra. The key of the station for user's heavy rotation.
		/// </summary>
		public string HeavyRotationKey
		{
			get;
			set;
		}

		/// <summary>
		/// Extra. The key of the station for user's network's heavy rotation.
		/// </summary>
		public string NetworkHeavyRotationKey
		{
			get;
			set;
		}

		/// <summary>
		/// Extra. The number of albums in the user's collection.
		/// </summary>
		public int? AlbumCount
		{
			get;
			set;
		}

		/// <summary>
		/// Extra. The number of tracks in the user's collection.
		/// </summary>
		public int? TrackCount
		{
			get;
			set;
		}

		/// <summary>
		/// Extra. When the last song was played.
		/// </summary>
		public DateTime? LastSongPlayTime
		{
			get;
			set;
		}

		/// <summary>
		/// Extra. The user's vanity name.
		/// </summary>
		public string Username
		{
			get;
			set;
		}

		/// <summary>
		/// Extra. The number of reviews the user has created.
		/// </summary>
		public int? ReviewCount
		{
			get;
			set;
		}

		/// <summary>
		/// Extra. The relative URL of the user's collection page.
		/// </summary>
		public string CollectionUrl
		{
			get;
			set;
		}

		/// <summary>
		/// Extra. The relative URL of the user's playlists page.
		/// </summary>
		public string PlaylistsUrl
		{
			get;
			set;
		}

		/// <summary>
		/// Extra. The key of the station for the user's collection.
		/// </summary>
		public string CollectionKey
		{
			get;
			set;
		}

		/// <summary>
		/// Extra. The relative URL of the user's followers page.
		/// </summary>
		public string FollowersUrl
		{
			get;
			set;
		}

		/// <summary>
		/// Extra. The user's display name.
		/// </summary>
		public string DisplayName
		{
			get;
			set;
		}

		/// <summary>
		/// Extra. Identifies if the user has an unlimited subscription plan.
		/// </summary>
		public bool? IsUnlimited
		{
			get;
			set;
		}

		/// <summary>
		/// Extra. Identifies if the user has a subscription plan.
		/// </summary>
		public bool? IsSubscriber
		{
			get;
			set;
		}

		/// <summary>
		/// List of extra properties.
		/// </summary>
		public static RdioUserExtras Extras
		{
			get
			{
				return Singleton<RdioUserExtras>.Instance;
			}
		}

		#endregion
	}
}