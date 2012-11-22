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
	/// The base class for all stations.
	/// </summary>
	[DebuggerDisplay("{Name,nq} ({Count,nq})")]
	public class RdioStation : RdioObject
	{
		#region Public Properties

		/// <summary>
		/// The number of tracks in the station.
		/// </summary>
		public int Count
		{
			get;
			set;
		}

		/// <summary>
		/// The name of the station.
		/// </summary>
		public string Name
		{
			get;
			set;
		}

		/// <summary>
		/// The tracks for the station.
		/// </summary>
		public IList<RdioTrack> Tracks
		{
			get;
			set;
		}

		/// <summary>
		/// The station should be reloaded when it completes playing and repeat is enabled.
		/// </summary>
		public bool ReloadOnRepeat
		{
			get;
			set;
		}

		/// <summary>
		/// Extra. The keys of the tracks for the station.
		/// </summary>
		public IList<string> TrackKeys
		{
			get;
			set;
		}

		/// <summary>
		/// List of extra properties.
		/// </summary>
		public static RdioStationExtras Extras
		{
			get
			{
				return Singleton<RdioStationExtras>.Instance;
			}
		}

		#endregion
	}
}