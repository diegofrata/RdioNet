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

#endregion

namespace RdioNet.Util
{
	public static class EnumExtensions
	{
		#region Public Methods

		public static IEnumerable<RdioObjectType> ToList(this RdioObjectType types)
		{
			foreach (RdioObjectType value in Enum.GetValues(typeof(RdioObjectType)))
			{
				if (value != RdioObjectType.Unknown && types.HasFlag(value))
					yield return value;
			}
		}

		public static string ToCommaSeparatedList(this RdioObjectType types)
		{
			return types.ToList().ToCommaSeparatedList();
		}

		public static string ToCommaSeparatedList(this IEnumerable<RdioObjectType> types)
		{
			return types.Select(p => p.ToString()).ToCommaSeparatedList();
		}

		public static string ToPascalCase(this Enum instance)
		{
			var value = instance.ToString();

			return char.ToLower(value[0]) + value.Substring(1);
		}

		#endregion
	}
}