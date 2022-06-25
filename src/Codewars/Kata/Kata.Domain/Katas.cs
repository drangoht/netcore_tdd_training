using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Kata.Domain
{
    public class Katas
    {
        public static string ToCamelCase(string str)
        {
            var result = "";
            if (str.Contains("_"))
                result = ArrayToUpperCase(str.Split("_"));
            if (str.Contains("-"))
                result = ArrayToUpperCase(str.Split("-"));
            return result;
      }
        private static string ArrayToUpperCase(string[] arrStr)
        {
            var camelCaseStr = arrStr[0];
            for (int i=1;i<arrStr?.Length;i++)
            {
                camelCaseStr += arrStr[i].Substring(0,1).ToUpperInvariant() + arrStr[i].Substring(1);
            }
            return camelCaseStr;
        }
    }
}