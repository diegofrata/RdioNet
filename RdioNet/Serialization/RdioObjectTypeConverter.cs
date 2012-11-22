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
	public class RdioObjectTypeConverter : JsonConverter
	{
		#region Constants

		public const string Unknown = "";
		public const string Album = "a";
		public const string Artist = "r";
		public const string ArtistStation = "rr";
		public const string ArtistTopSongsStation = "tr";
		public const string CollectionAlbum = "al";
		public const string CollectionArtist = "rl";
		public const string HeavyRotationStation = "h";
		public const string HeavyRotationUserStation = "e";
		public const string Label = "l";
		public const string LabelStation = "lr";
		public const string Playlist = "p";
		public const string Track = "t";
		public const string User = "s";
		public const string UserCollectionStation = "c";

		#endregion

		#region Public Methods

		public override bool CanConvert(Type objectType)
		{
			return typeof(RdioObjectType).IsAssignableFrom(objectType);
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			return FromString((string) reader.Value);
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			writer.WriteComment(ToString((RdioObjectType) value));
		}

		public static RdioObjectType FromString(string type)
		{
			switch (type)
			{
				case Album:
					return RdioObjectType.Album;
				case Artist:
					return RdioObjectType.Artist;
				case ArtistStation:
					return RdioObjectType.ArtistStation;
				case ArtistTopSongsStation:
					return RdioObjectType.ArtistTopSongsStation;
				case CollectionAlbum:
					return RdioObjectType.CollectionAlbum;
				case CollectionArtist:
					return RdioObjectType.CollectionArtist;
				case HeavyRotationStation:
					return RdioObjectType.HeavyRotationStation;
				case HeavyRotationUserStation:
					return RdioObjectType.HeavyRotationUserStation;
				case Label:
					return RdioObjectType.Label;
				case LabelStation:
					return RdioObjectType.LabelStation;
				case Playlist:
					return RdioObjectType.Playlist;
				case Track:
					return RdioObjectType.Track;
				case User:
					return RdioObjectType.User;
				case UserCollectionStation:
					return RdioObjectType.UserCollectionStation;
				default:
					return RdioObjectType.Unknown;
			}
		}

		public static string ToString(RdioObjectType type)
		{
			switch (type)
			{
				case RdioObjectType.Album:
					return Album;
				case RdioObjectType.Artist:
					return Artist;
				case RdioObjectType.ArtistStation:
					return ArtistStation;
				case RdioObjectType.ArtistTopSongsStation:
					return ArtistTopSongsStation;
				case RdioObjectType.CollectionAlbum:
					return CollectionAlbum;
				case RdioObjectType.CollectionArtist:
					return CollectionArtist;
				case RdioObjectType.HeavyRotationStation:
					return HeavyRotationStation;
				case RdioObjectType.HeavyRotationUserStation:
					return HeavyRotationUserStation;
				case RdioObjectType.Label:
					return Label;
				case RdioObjectType.LabelStation:
					return LabelStation;
				case RdioObjectType.Playlist:
					return Playlist;
				case RdioObjectType.Track:
					return Track;
				case RdioObjectType.User:
					return User;
				case RdioObjectType.UserCollectionStation:
					return UserCollectionStation;
				default:
					return Unknown;
			}
		}

		#endregion
	}
}