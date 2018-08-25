using System;
using System.Text;

namespace TheBlueSky.DotNet.Tools.SwiftHash
{
	internal static class Extensions
	{
		public static string ToBase64String(this byte[] @this)
		{
			return Convert.ToBase64String(@this);
		}

		public static string ToHexString(this byte[] @this)
		{
			var HexValue = new StringBuilder(@this.Length * 2);

			for (var i = 0; i < @this.Length; ++i)
			{
				if ((@this[i] & 0xFF) < 0x10)
				{
					HexValue.Append("0");
				}

				HexValue.Append((@this[i] & 0xFF).ToString("X"));
			}

			return HexValue.ToString();
		}
	}
}
