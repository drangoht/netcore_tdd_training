using System.Text.RegularExpressions;

namespace Kata.Domain
{
    public interface IKatas
    {
        string ToCamelCase(string str);
        bool Narcissistic(int value);

        string DuplicateEncode(string word);
    }
    public class Katas : IKatas
    {
        #region ToCamelCase
        public string ToCamelCase(string str)
        {
            var result = str;
            if (result.Contains("_") || result.Contains("-"))
                result = ArrayToUpperCase(result.Split('_','-'));
            return result;
        }
        private string ArrayToUpperCase(string[] arrStr)
        {
            var camelCaseStr = arrStr[0];
            for (int i=1;i<arrStr?.Length;i++)
            {
                // Set first char of each word from second word to uppercase
                camelCaseStr += arrStr[i].Substring(0,1).ToUpperInvariant() + arrStr[i].Substring(1);
            }
            return camelCaseStr;
        }
        #endregion

        #region Narcissistic
        public bool Narcissistic(int value)
        {

            // not optimal but ok for learning TDD
            var str = value.ToString();
            int nbDigits = str.Length;
            long result = 0;
            foreach(char c in str)
            {
                result += Convert.ToInt64(
                    Math.Pow(
                        Convert.ToDouble(c.ToString()), 
                        Convert.ToDouble(nbDigits)
                        )
                    );
            }
            return result == value;
        }
        #endregion

        #region DuplicateEncode
        public string DuplicateEncode(string word)
        {
            // Lower case alphanumeric chars
            word=Regex.Replace(word, @"[A-Z]", m => m.ToString().ToLower());

            // Store idx of char found once
            List<int> indexesOnce = new List<int>();
            int idx = 0;
            foreach (var c in word)
            {
                if (CharFoundOnceInString(c, word))
                    indexesOnce.Add(idx);
                idx++;
            }

            // Replace char found once by ( else by )
            var charToInsert = Char.MinValue;
            char[] arrResult = new char[word.Length];
            for (int i = 0; i < word.Length; i++)
            {
                if (indexesOnce.Any(idx => idx == i))
                    charToInsert = '(';
                else
                    charToInsert = ')';
                arrResult[i] = charToInsert;
            }
            return new string(arrResult);
        }
        /// <summary>
        /// Search for char c found once in string str
        /// </summary>
        /// <param name="c"></param>
        /// <param name="str"></param>
        /// <returns>true if char c found once only</returns>
        private bool CharFoundOnceInString(char c,string str)
        {
            return str.Count(ch => ch == c) == 1;
        }
        #endregion
    }
}