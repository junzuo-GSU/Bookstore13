﻿using System.Text;

namespace Bookstore.Models
{
    // a series of extension methods that make it easier to create slugs, compare strings, capitalize strings, 
    // and cast a string to an int. Note that the EqualsNoCase() method doesn't work in EF Core code such as
    // 'Where(b => b.GenreId.EqualsNoCase("novel"))' In that case, must use old fashioned equality operator.

    public static class StringExtensions
    {
        //creating a slug from a string by replacing spaces with dashes and removing punctuation, except for dashes
        // and converting to lower case
        public static string Slug(this string str)
        {
            var sb = new StringBuilder();
            foreach (char c in str)
            {
                if (!char.IsPunctuation(c) || c == '-') { 
                    sb.Append(c);
                }
            }
            return sb.ToString().Replace(' ', '-').ToLower();
        }

        public static bool EqualsNoCase(this string str, string tocompare) =>
            str?.ToLower() == tocompare?.ToLower();

        public static int ToInt(this string str)
        {
            int.TryParse(str, out int value);
            return value;
        }

        public static string Capitalize(this string str) =>
            str?.Substring(0, 1)?.ToUpper() + str?.Substring(1)?.ToLower();
    }
}