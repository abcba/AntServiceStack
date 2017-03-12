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
	public static class TextExtensions
	{
        public static string ToCsvField(this string text)
        {
            return string.IsNullOrEmpty(text) || !CsvWriter.HasAnyEscapeChars(text)
                       ? text
                       : string.Concat
                             (
                                 CsvConfig.ItemDelimiterString,
                                 text.Replace(CsvConfig.ItemDelimiterString, CsvConfig.EscapedItemDelimiterString),
                                 CsvConfig.ItemDelimiterString
                             );
        }

        public static object ToCsvField(this object text)
        {
            return text == null || !JsWriter.HasAnyEscapeChars(text.ToString())
                       ? text
                       : string.Concat
                             (
                                 JsWriter.QuoteString,
                                 text.ToString().Replace(JsWriter.QuoteString, TypeSerializer.DoubleQuoteString),
                                 JsWriter.QuoteString
                             );
        }

	    public static string FromCsvField(this string text)
		{
            return string.IsNullOrEmpty(text) || !text.StartsWith(CsvConfig.ItemDelimiterString, StringComparison.Ordinal)
			       	? text
					: text.Substring(CsvConfig.ItemDelimiterString.Length, text.Length - CsvConfig.EscapedItemDelimiterString.Length)
						.Replace(CsvConfig.EscapedItemDelimiterString, CsvConfig.ItemDelimiterString);
		}

		public static List<string> FromCsvFields(this IEnumerable<string> texts)
		{
			var safeTexts = new List<string>();
			foreach (var text in texts)
			{
				safeTexts.Add(FromCsvField(text));
			}
			return safeTexts;
		}

		public static string[] FromCsvFields(params string[] texts)
		{
			var textsLen = texts.Length;
			var safeTexts = new string[textsLen];
			for (var i = 0; i < textsLen; i++)
			{
				safeTexts[i] = FromCsvField(texts[i]);
			}
			return safeTexts;
		}

		public static string SerializeToString<T>(this T value)
		{
			return JsonSerializer.SerializeToString(value);
		}
	}
}