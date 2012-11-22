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

using Newtonsoft.Json;

using RdioNet.Models;

#endregion

namespace RdioNet.Serialization
{
	public class RdioUserGenderConverter : JsonConverter
	{
		#region Public Methods

		public override bool CanConvert(Type objectType)
		{
			return typeof(RdioUserGender) == objectType || typeof(RdioUserGender?) == objectType;
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			if (reader.Value is string)
			{
				switch ((string) reader.Value)
				{
					case "m":
						return RdioUserGender.Male;
					case "f":
						return RdioUserGender.Female;
				}
			}

			return existingValue;
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			writer.WriteValue(ConvertGenderToString((RdioUserGender) value));
		}

		#endregion

		#region Private Methods

		private static string ConvertGenderToString(RdioUserGender value)
		{
			switch (value)
			{
				case RdioUserGender.Male:
					return "m";
				case RdioUserGender.Female:
					return "f";
				default:
					return "";
			}
		}

		#endregion
	}
}