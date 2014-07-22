using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Orchard.Comments.Projections
{
    public static class CommentUrlHelper
    {
        public static bool IsSamePageAs(this string currentUrl, string commentUrl)
        {
            if (string.IsNullOrEmpty(currentUrl) || string.IsNullOrEmpty(commentUrl))
                return false;
            else
            {
                var currentUrlHostAndPath = currentUrl.Split(new string[] { "?" }, StringSplitOptions.RemoveEmptyEntries)[0];
                var commentUrlHostAndPath = commentUrl.Split(new string[] { "?" }, StringSplitOptions.RemoveEmptyEntries)[0];
                return currentUrlHostAndPath.ToLower()== commentUrlHostAndPath.ToLower();
            }
        }

        public static string PreprocessUrlForCompare(string url)
        {
            return url.ToLower();
        }
    }
}