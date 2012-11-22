﻿#region Header

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

namespace RdioNet.Models
{
	#region Enumerations

	/// <summary>
	/// Defines a possible sorting mechanisms for Rdio items.
	/// </summary>
	public enum RdioSortingFields
	{
		/// <summary>
		/// Items are sorted by the name.
		/// </summary>
		Name,

		/// <summary>
		/// Items are sorted by the release date.
		/// </summary>
		ReleaseDate,

		/// <summary>
		/// Items are sorted by the date they were added to the collection.
		/// </summary>
		DateAdded,

		/// <summary>
		/// Items are sorted by the number of times it has been played.
		/// </summary>
		PlayCount,

		/// <summary>
		/// Items are sorted by artist.
		/// </summary>
		Artist,

		/// <summary>
		/// Items are sorted by album.
		/// </summary>
		Album,

		/// <summary>
		/// Items are sorted by the time they were last updated.
		/// </summary>
		LastUpdated
	}

	#endregion
}