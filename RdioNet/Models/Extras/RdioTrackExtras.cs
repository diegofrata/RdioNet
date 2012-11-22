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

#endregion

namespace RdioNet.Models.Extras
{
	/// <summary>
	/// Defines the constants for all the extra fields in <seealso cref="RdioTrack"/>.
	/// </summary>
	public class RdioTrackExtras : RdioExtras
	{
		#region Member Variables

		public readonly string IsInCollection = "isInCollection";
		public readonly string IsOnCompilation = "isOnCompilation";
		public readonly string IFrameUrl = "iframeUrl";
		public readonly string PlayCount = "playCount";
		public readonly string BigIcon = "bigIcon";

		#endregion

		#region Public Properties

		/// <summary>
		/// A collection of all extra fields.
		/// </summary>
		public override string[] All
		{
			get
			{
				return new[] { IsInCollection, IsOnCompilation, IFrameUrl, PlayCount, BigIcon };
			}
		}

		#endregion
	}
}