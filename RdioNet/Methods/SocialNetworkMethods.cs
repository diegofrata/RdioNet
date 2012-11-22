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
	/// Social Network methods of the Rdio API.
	/// </summary>
	public class SocialNetworkMethods : MethodsBase
	{
		#region Construction and Initialization

		public SocialNetworkMethods(RdioClient client)
			: base(client)
		{
		}

		#endregion

		#region Public Methods

		/// <summary>
		/// Adds a friend to the current user. Authentication is required.
		/// </summary>
		/// <param name="user">The user's key to add.</param>
		/// <returns>Returns <value>true</value> on success or <value>false</value> on failure.</returns>
		public Task<bool> AddFriendAsync(string user)
		{
			if (string.IsNullOrEmpty(user))
				throw new ArgumentNullException("user");

			return PostAsync<bool>("addFriend", new Dictionary<string, string>
			{
				{ "user", user }
			});
		}

		/// <summary>
		/// Gets information about the currently logged in user. Authentication is required.
		/// </summary>
		/// <param name="extras">The extra fields to be included in the returned <seealso cref="RdioUser"/>.</param>
		/// <returns>Returns an <seealso cref="RdioUser"/> object of the current user.</returns>
		public Task<RdioUser> GetCurrentUserAsync(params string[] extras)
		{
			return PostAsync<RdioUser>("currentUser", new Dictionary<string, string>
			{
				{ "extras", extras.ToCommaSeparatedList() }
			});
		}

		/// <summary>
		///  Finds a user by email address.
		/// </summary>
		/// <param name="email">The email address of the user.</param>
		/// <param name="extras">The extra fields to be included in the returned <seealso cref="RdioUser"/>.</param>
		/// <returns>Returns an <seealso cref="RdioUser"/> object of the user or <value>null</value>
		/// if no user is found.</returns>
		public Task<RdioUser> FindUserByEmailAsync(string email, params string[] extras)
		{
			if (string.IsNullOrEmpty(email))
				throw new ArgumentNullException("email");

			return PostAsync<RdioUser>("findUser", new Dictionary<string, string>
			{
				{ "email", email },
				{ "extras", extras.ToCommaSeparatedList() }
			});
		}

		/// <summary>
		///  Finds a user by username.
		/// </summary>
		/// <param name="vanityName">The username of the user.</param>
		/// <param name="extras">The extra fields to be included in the returned <seealso cref="RdioUser"/>.</param>
		/// <returns>Returns an <seealso cref="RdioUser"/> object of the user or <value>null</value>
		/// if no user is found.</returns>
		public Task<RdioUser> FindUserByVanityNameAsync(string vanityName, params string[] extras)
		{
			if (string.IsNullOrEmpty(vanityName))
				throw new ArgumentNullException("vanityName");

			return PostAsync<RdioUser>("findUser", new Dictionary<string, string>
			{
				{ "vanityName", vanityName },
				{ "extras", extras.ToCommaSeparatedList() }
			});
		}

		/// <summary>
		/// Removes a friend from the current user. Authentication is required.
		/// </summary>
		/// <param name="user">The user's key to remove.</param>
		/// <returns>Returns <value>true</value> on success or <value>false</value> on failure.</returns>
		public Task<bool> RemoveFriendAsync(string user)
		{
			if (string.IsNullOrEmpty(user))
				throw new ArgumentNullException("user");

			return PostAsync<bool>("removeFriend", new Dictionary<string, string>
			{
				{ "user", user }
			});
		}

		/// <summary>
		/// Get a list of users following a user.
		/// </summary>
		/// <param name="user">The user's key.</param>
		/// <param name="start">The offset of the first result to return.</param>
		/// <param name="count">The maximum number of results to return.</param>
		/// <param name="inCommon">If present, return followers of both the user argument and this user.</param>
		/// <param name="extras">The extra fields to be included in the returned <seealso cref="RdioUser"/>.</param>
		/// <returns>A list of <seealso cref="RdioUser"/> objects, sorted by descending add time.</returns>
		public Task<IList<RdioUser>> GetUserFollowers(string user, int start = 0, int count = 0, bool inCommon = false, params string[] extras)
		{
			if (string.IsNullOrEmpty(user))
				throw new ArgumentNullException("user");

			var parameters = new Dictionary<string, string>
			{
				{ "user", user },
				{ "inCommon", Serializer.Serialize(inCommon) },
				{ "extras", extras.ToCommaSeparatedList() }
			};

			if (start > 0)
				parameters["start"] = start.ToString();

			if (count > 0)
				parameters["count"] = count.ToString();

			return PostAsync<IList<RdioUser>>("userFollowers", parameters);
		}

		/// <summary>
		/// Get a list of users that a user follows.
		/// </summary>
		/// <param name="user">The user's key.</param>
		/// <param name="start">The offset of the first result to return.</param>
		/// <param name="count">The maximum number of results to return.</param>
		/// <param name="inCommon">If present, return friends being followed by both the user argument and this user.</param>
		/// <param name="extras">The extra fields to be included in the returned <seealso cref="RdioUser"/>.</param>
		/// <returns>A list of <seealso cref="RdioUser"/> objects, sorted by descending add time.</returns>
		public Task<IList<RdioUser>> GetUserFollowing(string user, int start = 0, int count = 0, bool inCommon = false, params string[] extras)
		{
			if (string.IsNullOrEmpty(user))
				throw new ArgumentNullException("user");

			var parameters = new Dictionary<string, string>
			{
				{ "user", user },
				{ "inCommon", Serializer.Serialize(inCommon) },
				{ "extras", extras.ToCommaSeparatedList() }
			};

			if (start > 0)
				parameters["start"] = start.ToString();

			if (count > 0)
				parameters["count"] = count.ToString();

			return PostAsync<IList<RdioUser>>("userFollowing", parameters);
		}

		#endregion
	}
}