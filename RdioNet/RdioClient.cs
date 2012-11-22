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
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Web;

using OAuth;

using RdioNet.Extensions;
using RdioNet.Methods;
using RdioNet.OAuth;

#endregion

namespace RdioNet
{
	/// <summary>
	/// A Rdio Web Services client.
	/// </summary>
	public class RdioClient
	{
		#region Member Variables

		private RdioServiceDescription _serviceDescription;

		#endregion

		#region Public Properties

		/// <summary>
		/// The Rdio Web Services description.
		/// </summary>
		public RdioServiceDescription ServiceDescription
		{
			get
			{
				return _serviceDescription.Copy();
			}
		}

		/// <summary>
		/// The users credentials to access the service.
		/// </summary>
		public OAuthCredentials Credentials
		{
			get;
			private set;
		}

		/// <summary>
		/// The Core methods of the Rdio API.
		/// </summary>
		public CoreMethods Core
		{
			get;
			private set;
		}

		/// <summary>
		/// Catalog methods of the Rdio API.
		/// </summary>
		public CatalogMethods Catalog
		{
			get;
			private set;
		}

		/// <summary>
		/// Collection methods of the Rdio API.
		/// </summary>
		public CollectionMethods Collection
		{
			get;
			private set;
		}

		/// <summary>
		/// Playlists methods of the Rdio API.
		/// </summary>
		public PlaylistsMethods Playlists
		{
			get;
			private set;
		}

		/// <summary>
		/// Social Network methods of the Rdio API.
		/// </summary>
		public SocialNetworkMethods SocialNetwork
		{
			get;
			private set;
		}

		/// <summary>
		/// Activity and Statistics methods of the Rdio API.
		/// </summary>
		public ActivityMethods Activity
		{
			get;
			private set;
		}

		/// <summary>
		/// Playback methods of the Rdio API.
		/// </summary>
		public PlaybackMethods Playback
		{
			get;
			private set;
		}

		#endregion

		#region Construction and Initialization

		/// <summary>
		/// Creates a new instance of RdioClient with just Consumer information. To access
		/// protected methods, you must request user authorization first.
		/// </summary>
		/// <param name="consumerKey">The OAuth consumer's key.</param>
		/// <param name="consumerSecret">The OAuth consumer's secret.</param>
		public RdioClient(string consumerKey, string consumerSecret)
			: this(consumerKey, consumerSecret, RdioServiceDescription.Default)
		{
		}

		/// <summary>
		/// Creates a new instance of RdioClient with just Consumer information. To access
		/// protected methods, you must request user authorization first.
		/// </summary>
		/// <param name="consumerKey">The OAuth consumer's key.</param>
		/// <param name="consumerSecret">The OAuth consumer's secret.</param>
		/// <param name="serviceDescription">A custom <seealso cref="RdioServiceDescription"/> object defining
		/// API endpoints.</param>
		public RdioClient(string consumerKey, string consumerSecret, RdioServiceDescription serviceDescription)
		{
			if (string.IsNullOrEmpty(consumerKey))
				throw new ArgumentNullException("consumerKey");

			if (serviceDescription == null)
				throw new ArgumentNullException("serviceDescription");

			_serviceDescription = serviceDescription;

			Credentials = new OAuthCredentials
			{
				ConsumerKey = consumerKey,
				ConsumerSecret = consumerSecret
			};

			InitializeMethods();
		}

		/// <summary>
		/// Creates a new instance of RdioClient with Consumer and Access information.
		/// </summary>
		/// <param name="consumerKey">The OAuth consumer's key.</param>
		/// <param name="consumerSecret">The OAuth consumer's secret.</param>
		/// <param name="accessSecret">The OAuth access secret.</param>
		/// <param name="accessToken">The OAuth access token.</param>
		public RdioClient(string consumerKey, string consumerSecret, string accessToken, string accessSecret)
			: this(consumerKey, consumerSecret, accessToken, accessSecret, RdioServiceDescription.Default)
		{
		}


		/// <summary>
		/// Creates a new instance of RdioClient with Consumer and Access information.
		/// </summary>
		/// <param name="consumerKey">The OAuth consumer's key.</param>
		/// <param name="consumerSecret">The OAuth consumer's secret.</param>
		/// <param name="accessSecret">The OAuth access secret.</param>
		/// <param name="accessToken">The OAuth access token.</param>
		/// <param name="serviceDescription">A custom <seealso cref="RdioServiceDescription"/> object defining
		/// API endpoints.</param>
		public RdioClient(string consumerKey, string consumerSecret, string accessToken, string accessSecret, RdioServiceDescription serviceDescription)
			: this(consumerKey, consumerSecret, serviceDescription)
		{
			if (string.IsNullOrEmpty(accessToken))
				throw new ArgumentNullException("accessToken");

			if (string.IsNullOrEmpty(accessSecret))
				throw new ArgumentNullException("accessSecret");

			Credentials.Token = new OAuthToken
			{
				Token = accessToken,
				Secret = accessSecret,
				Type = OAuthTokenType.Access
			};
		}

		#endregion

		#region Public Methods

		/// <summary>
		/// Initiates an OAuth authorization request.
		/// </summary>
		/// <param name="callbackUrl">The callbackUrl if it's a web authentication (must have HttpContext.Current != null). 
		/// Otherwise should be <value>null</value>.</param>
		/// <returns>Returns the state of the authorization request.</returns>
		public async Task<OAuthRequestState> RequestUserAuthorizationAsync(Uri callbackUrl = null)
		{
			OAuthRequest request;

			if (callbackUrl != null)
				request = OAuthRequest.ForRequestToken(Credentials.ConsumerKey, Credentials.ConsumerSecret, callbackUrl.ToString());
			else
				request = OAuthRequest.ForRequestToken(Credentials.ConsumerKey, Credentials.ConsumerSecret, "oob");

			var httpRequest = request.CreateRequestWithAuthorizationHeader(_serviceDescription.RequestTokenEndpoint);

			using (var httpResponse = await httpRequest.GetHttpWebResponseAsync())
			{
				httpResponse.EnsureSuccessStatusCode();

				var state = httpResponse.GetAuthorizationState();

				Credentials.Token = state.RequestToken.Copy();

				return state;
			}
		}

		/// <summary>
		/// Completes the OAuth authorization request using HttpContext.Current.
		/// </summary>
		/// <returns>The <seealso cref="OAuthToken"/> containing the Access Token.</returns>
		public Task<OAuthToken> CompleteUserAuthorizationAsync()
		{
			if (Credentials.Token == null || Credentials.Token.Type != OAuthTokenType.Request)
				throw new RdioException("You must acquire a RequestToken before calling CompleteUserAuthorizationAsync.");

			return CompleteUserAuthorizationAsync(new OAuthRequestState { RequestToken = Credentials.Token });
		}

		/// <summary>
		/// Completes the OAuth authorization request using HttpContext.Current.
		/// </summary>
		/// <param name="state">The original <seealso cref="OAuthRequestState"/> object containing the request token.</param> 
		/// <returns>The <seealso cref="OAuthToken"/> containing the Access Token.</returns>
		public Task<OAuthToken> CompleteUserAuthorizationAsync(OAuthRequestState state)
		{
			if (HttpContext.Current == null)
				throw new RdioException("HttpContext.Current must not be null.");

			var verifier = HttpContext.Current.Request.Params["oauth_verifier"];

			return CompleteUserAuthorizationAsync(verifier);
		}

		/// <summary>
		/// Completes the OAuth authorization request using the verifier supplied by the user.
		/// </summary>
		/// <param name="verifier">The verification code informed by the user.</param>
		/// <returns>The <seealso cref="OAuthToken"/> containing the Access Token.</returns>
		public Task<OAuthToken> CompleteUserAuthorizationAsync(string verifier)
		{
			if (string.IsNullOrEmpty(verifier))
				throw new ArgumentNullException("verifier");

			if (Credentials.Token == null || Credentials.Token.Type != OAuthTokenType.Request)
				throw new RdioException("You must acquire a RequestToken before calling CompleteUserAuthorizationAsync.");

			return CompleteUserAuthorizationAsync(new OAuthRequestState { RequestToken = Credentials.Token }, verifier);
		}

		/// <summary>
		/// Completes the OAuth authorization request using the verifier supplied by the user.
		/// </summary>
		/// <param name="state">The original <seealso cref="OAuthRequestState"/> object containing the request token.</param>
		/// <param name="verifier">The verification code informed by the user.</param>
		/// <returns>The <seealso cref="OAuthToken"/> containing the Access Token.</returns>
		public async Task<OAuthToken> CompleteUserAuthorizationAsync(OAuthRequestState state, string verifier)
		{
			if (string.IsNullOrEmpty(verifier))
				throw new ArgumentNullException("verifier");

			if (state == null)
				throw new ArgumentNullException("state");

			var request = OAuthRequest.ForAccessToken(Credentials.ConsumerKey, Credentials.ConsumerSecret, state.RequestToken.Token, state.RequestToken.Secret, verifier);

			var httpRequest = request.CreateRequestWithAuthorizationHeader(_serviceDescription.AccessTokenEndpoint);

			using (var httpResponse = await httpRequest.GetHttpWebResponseAsync())
			{
				httpResponse.EnsureSuccessStatusCode();

				var accessToken = httpResponse.GetToken();

				Credentials.Token = accessToken.Copy();

				return accessToken;
			}
		}

		#endregion

		#region Protected Methods

		/// <summary>
		/// Overriden in a derived class, this method allows the user to initiliaze
		/// custom method properties.
		/// </summary>
		protected virtual void OnInitializeMethods()
		{
		}

		#endregion

		#region Private Methods

		private void InitializeMethods()
		{
			Core = new CoreMethods(this);
			Catalog = new CatalogMethods(this);
			Collection = new CollectionMethods(this);
			Playlists = new PlaylistsMethods(this);
			SocialNetwork = new SocialNetworkMethods(this);
			Activity = new ActivityMethods(this);
			Playback = new PlaybackMethods(this);

			OnInitializeMethods();
		}

		#endregion
	}
}