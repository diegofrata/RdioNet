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

using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

using RdioNet.Models;

#endregion

namespace RdioNet.Serialization
{
	public class RdioObjectCreationConverter : JsonCreationConverter<RdioObject>
	{
		#region Protected Methods

		protected override RdioObject Create(Type objectType, JObject jObject)
		{
			var type = RdioObjectTypeConverter.FromString((string) jObject.Property("type"));

			switch (type)
			{
				case RdioObjectType.Album:
					return new RdioAlbum();
				case RdioObjectType.Artist:
					return new RdioArtist();
				case RdioObjectType.ArtistStation:
					return new RdioArtistStation();
				case RdioObjectType.ArtistTopSongsStation:
					return new RdioArtistTopSongsStation();
				case RdioObjectType.CollectionAlbum:
					return new RdioCollectionAlbum();
				case RdioObjectType.CollectionArtist:
					return new RdioCollectionArtist();
				case RdioObjectType.HeavyRotationStation:
					return new RdioHeavyRotationStation();
				case RdioObjectType.HeavyRotationUserStation:
					return new RdioHeavyRotationUserStation();
				case RdioObjectType.Label:
					return new RdioLabel();
				case RdioObjectType.LabelStation:
					return new RdioLabelStation();
				case RdioObjectType.Playlist:
					return new RdioPlaylist();
				case RdioObjectType.Track:
					return new RdioTrack();
				case RdioObjectType.User:
					return new RdioUser();
				case RdioObjectType.UserCollectionStation:
					return new RdioUserCollectionStation();
				default:
					return new RdioObject();
			}
		}

		#endregion
	}
}