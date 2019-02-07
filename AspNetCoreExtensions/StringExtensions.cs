﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace NeuroSpeech
{
    /// <summary>
    /// 
    /// </summary>
    public static class StringExtensions
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="comparison"></param>
        /// <returns></returns>
        public static string Extract(
            this string text,
            string start,
            string end,
            StringComparison comparison = StringComparison.OrdinalIgnoreCase)
        {

            if (String.IsNullOrWhiteSpace(text))
                return null;
            if (string.IsNullOrWhiteSpace(start))
                throw new ArgumentNullException(nameof(start));
            if (string.IsNullOrWhiteSpace(end))
                throw new ArgumentNullException(nameof(end));
            int index = text.IndexOf(start, 0, comparison);
            if (index == -1)
                return null;
            text = text.Substring(index + start.Length);

            index = text.IndexOf(end, start.Length, comparison);
            if (index == -1)
                return "";

            return text.Substring(0, index);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="test"></param>
        /// <returns></returns>
        public static bool StartsWithIgnoreCase(this string text, string test)
        {
            return text.StartsWith(test, StringComparison.OrdinalIgnoreCase);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="test"></param>
        /// <returns></returns>
        public static bool EqualsIgnoreCase(this string text, string test)
        {
            if (string.IsNullOrWhiteSpace(text))
                return string.IsNullOrWhiteSpace(test);
            if (string.IsNullOrWhiteSpace(test))
                return false;
            return text.Equals(test, StringComparison.OrdinalIgnoreCase);
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="charLength"></param>
        /// <returns></returns>
        public static string Last(this string text, int charLength)
        {
            if (text == null)
                return null;
            if (text.Length <= charLength)
                return text;
            return text.Substring(text.Length - charLength);
        }

        /// <summary>
        ///  Split Ids
        /// </summary>
        public static List<T> SplitAs<T>(
            this string ctIDs,
            Func<string, T> converter = null)
        {
            List<T> ids = new List<T>();

            if (string.IsNullOrWhiteSpace(ctIDs))
                return ids;

            if (converter == null)
            {
                converter = (value) =>
                {
                    return (T)Convert.ChangeType(value, typeof(T));
                };
            }

            foreach (string token in ctIDs.Split(',', ';'))
            {
                if (string.IsNullOrWhiteSpace(token))
                    continue;
                T v = converter(token);
                ids.Add(v);
            }
            return ids;
        }
    }
}
