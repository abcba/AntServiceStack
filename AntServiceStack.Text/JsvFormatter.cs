//
// ServiceStack.Text: .NET C# POCO JSON, JSV and CSV Text Serializers.
//
// Authors:
//   William Yang (b.yang@ctrip.com)
//
// Copyright 2012 CTrip Ltd.
//
//

using System;
using System.Collections.Generic;
using System.Text;
using AntServiceStack.Text.Common;

namespace AntServiceStack.Text
{
	public static class JsvFormatter
	{
		public static string Format(string serializedText)
		{
			if (string.IsNullOrEmpty(serializedText)) return null;

			var tabCount = 0;
			var sb = new StringBuilder();
			var firstKeySeparator = true;

			for (var i = 0; i < serializedText.Length; i++)
			{
				var current = serializedText[i];
				var previous = i - 1 >= 0 ? serializedText[i - 1] : 0;
				var next = i < serializedText.Length - 1 ? serializedText[i + 1] : 0;

				if (current == JsWriter.MapStartChar || current == JsWriter.ListStartChar)
				{
					if (previous == JsWriter.MapKeySeperator)
					{
						if (next == JsWriter.MapEndChar || next == JsWriter.ListEndChar)
						{
							sb.Append(current);
							sb.Append(serializedText[++i]); //eat next
							continue;
						}

						AppendTabLine(sb, tabCount);
					}

					sb.Append(current);
					AppendTabLine(sb, ++tabCount);
					firstKeySeparator = true;
					continue;
				}

				if (current == JsWriter.MapEndChar || current == JsWriter.ListEndChar)
				{
					AppendTabLine(sb, --tabCount);
					sb.Append(current);
					firstKeySeparator = true;
					continue;
				}

				if (current == JsWriter.ItemSeperator)
				{
					sb.Append(current);
					AppendTabLine(sb, tabCount);
					firstKeySeparator = true;
					continue;
				}

				sb.Append(current);

				if (current == JsWriter.MapKeySeperator && firstKeySeparator)
				{
					sb.Append(" ");
					firstKeySeparator = false;
				}
			}

			return sb.ToString();
		}

		private static void AppendTabLine(StringBuilder sb, int tabCount)
		{
			sb.AppendLine();

			if (tabCount > 0)
			{
				sb.Append(new string('\t', tabCount));
			}
		}
	}
}