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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RdioNet.Models;

#endregion

namespace RdioNet.Tests
{
	[TestClass]
	public class RdioClientTests
	{
		#region Public Methods

		// Uncomment this test to test the login and also to obtain the access token required
		// for the other tests.
		//[TestMethod]
		public async Task Authenticate()
		{
			var client = new RdioClient(Constants.ConsumerKey, Constants.ConsumerSecret);

			var response = await client.RequestUserAuthorizationAsync();

			Assert.IsNotNull(response.AuthorizationUrl);
			Assert.IsNotNull(response.RequestToken);
			Assert.IsTrue(response.CallbackConfirmed);
			Assert.AreEqual(OAuth.OAuthTokenType.Request, response.RequestToken.Type);
			Assert.IsNotNull(response.RequestToken.Token);
			Assert.IsNotNull(response.RequestToken.Secret);

			Process.Start(response.AuthorizationUrl.ToString()).WaitForExit();

			var verifier = Microsoft.VisualBasic.Interaction.InputBox("Fill the verification code.", "RdioNet", "", 0, 0);

			var token = await client.CompleteUserAuthorizationAsync(verifier);

			Assert.IsNotNull(token);
			Assert.AreEqual(OAuth.OAuthTokenType.Access, token.Type);
			Assert.IsNotNull(token.Token);
			Assert.IsNotNull(token.Secret);

			Microsoft.VisualBasic.Interaction.InputBox("", "RdioNet", "AccessToken = " + token.Token + "; AccessSecret = " + token.Secret, 0, 0);
		}

		#endregion
	}
}