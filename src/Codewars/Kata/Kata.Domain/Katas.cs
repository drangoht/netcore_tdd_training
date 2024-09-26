using System;
using System.Text.RegularExpressions;

namespace Kata.Domain
{
    public interface IKatas
    {
        string ToCamelCase(string str);
        bool Narcissistic(int value);

        string DuplicateEncode(string word);

        public int MaxSequence(int[] arr);
        public bool IsValidIP(string ipAddres);

        public int StrCount(string str, string searchedStr);
        public string RangeExtraction(int[] numbers);
        public List<string> GetPINs(string observed);

        public bool Scramble(string str, string strToSearch);
        public string AddBigNumber(string a, string b);

        public int SumIntervals((int, int)[] intervals);
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

        #region MaxSequence

        public int MaxSequence(int[] arr)
        {
            var currSum = 0;
            var maxSum = int.MinValue;
            foreach (var i in arr)
            {
                currSum += i;
                if (currSum < 0) currSum = 0;
                if ((currSum >= 0) && (currSum > maxSum)) maxSum = currSum;
                else if (maxSum < i) maxSum = i;
            }
            
            return maxSum==int.MinValue?0:maxSum;
        }
        #endregion

        #region IsValidIP
        // ^(?!0.)\d{1,3}\.(?!0.)\d{1,3}\.(?!0.)\d{1,3}\.(?!0.)\d{1,3}$
        // ^((25[0-5]|(2[0-4]|1/d|[1-9]|)/d)(/.(?!$)|$)){4}
        public bool IsValidIP(string ipAddres)
        {
            return Regex.Match(ipAddres, "^0.0.0.0|^(?!0+)(0|25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.(?!0+)(0|25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.(?!0+)(0|25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.(?!0+)(0|25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$", RegexOptions.None).Success;
        }
        #endregion

        #region StrCount
        public int StrCount(string str, string searchedStr)
        {
            return str.Where(c => c.ToString() == searchedStr).Count();
        }
        #endregion

        #region RangeExtraction
        public string RangeExtraction(int[] numbers)
        {
            int minIndex = -1;
            int precIndex = int.MinValue;
            string result = string.Empty;
            string tempResult = string.Empty;
            bool minSelected = false;
            for(int index =0;index<numbers.Count();index++)
            {
                if (precIndex != int.MinValue)
                {
                    if (Math.Abs(numbers[index] - numbers[precIndex]) > 1)
                    {
                        if (!string.IsNullOrWhiteSpace(result))
                            result += ",";
                        if (Math.Abs(numbers[precIndex] - numbers[minIndex]) > 1)
                            result += $"{numbers[minIndex]}-{numbers[precIndex]}";
                        else
                            result += tempResult;
                        minSelected = false;
                        tempResult = string.Empty;
                    }
                }
                if (!minSelected)
                {
                    minSelected = true;
                    minIndex = index;
                }
                if (!string.IsNullOrWhiteSpace(tempResult))
                    tempResult += ",";
                tempResult += $"{numbers[index]}";
                precIndex = index;
            }

            if (!string.IsNullOrWhiteSpace(result))
                result += ",";
            if (Math.Abs(numbers[precIndex] - numbers[minIndex]) > 1)
                result += $"{numbers[minIndex]}-{numbers[precIndex]}";
            else
                result += tempResult;

            return result;
        }
        #endregion

        #region GetPINS
        public List<string> GetPINs(string observed)
        {
            PinPad pad = new PinPad();
            List<string> results = new List<string>();
            return pad.GetCombination(observed).OrderBy(c => c).ToList();
        }
        #endregion

        #region Scramble
        public bool Scramble(string str, string strToSearch)
        {
            int found = 0;
            foreach (var c in strToSearch)
            {
                var idx = str.IndexOf(c);
                if (idx != -1)
                {
                    str = str.Remove(idx, 1);
                    found++;
                }
            }
            return strToSearch.Length == found ? true : false;
        }
        #endregion

        #region AddBigNumber
        public string AddBigNumber(string a, string b)
        {
            var retainValue = 0;
           
            string strToAdd = a.Length >= b.Length ? a : b;
            string strToBrowse = a.Length >= b.Length ? b : a;
            int indexSecondString = strToBrowse.Length-1;
            string result = string.Empty;
            /// Looping on the longest number
            for (int index = strToAdd.Length - 1; index >= 0; index--)
            {
                int numberToAdd;
                // If the smallest number finished replace current digit by a 0
                if ( indexSecondString < 0)
                    numberToAdd = 0;
                else
                    numberToAdd = Convert.ToInt16(strToBrowse[indexSecondString].ToString());

                // add last chars
                var valAdded = Convert.ToInt16(strToAdd[index].ToString()) + numberToAdd;
                // Calculation of the retain
                valAdded += retainValue;
                retainValue = Convert.ToInt16(valAdded / 10);
                // Concatenate the right part
                result = (valAdded - (retainValue * 10)).ToString() + result;
                indexSecondString--;
            }
            // If a retainValue exist concat it 
            if (retainValue > 0)
                result = retainValue.ToString() + result;

            return result; 
        }


        #endregion
        #region SumIntervals
        public int SumIntervals((int, int)[] intervals)
        {
            int resultSumOfIntervals = 0;
            var compiledIntervals = CompileIntervals(intervals);
            foreach (var interval in compiledIntervals)
            {
                resultSumOfIntervals += Math.Abs(interval.Item2 - interval.Item1);
            }
            return resultSumOfIntervals;
        }
        private (int, int)[] CompileIntervals((int, int)[] intervals)
        {
            for (int i = 0; i < intervals.Length; i++)
            {
                for (int j = i + 1; j < intervals.Length; j++)
                {

                    if ((intervals[j].Item1 >= intervals[i].Item1) && (intervals[j].Item1 <= intervals[i].Item2))
                    {
                        intervals[j].Item1 = intervals[i].Item2;
                    }
                    if ((intervals[j].Item2 >= intervals[i].Item1) && (intervals[j].Item2 <= intervals[i].Item2))
                    {
                        intervals[j].Item2 = intervals[i].Item1;
                    }
                    // Full overlaped so cancel the interval
                    if (((intervals[j].Item1 >= intervals[i].Item1) && (intervals[j].Item1 <= intervals[i].Item2)) &&
                       ((intervals[j].Item2 >= intervals[i].Item1) && (intervals[j].Item2 <= intervals[i].Item2)))
                    {
                        intervals[j].Item1 = intervals[j].Item2 = 0;
                    }
                    if (((intervals[i].Item1 >= intervals[j].Item1) && (intervals[i].Item1 <= intervals[j].Item2)) &&
                     ((intervals[i].Item2 >= intervals[j].Item1) && (intervals[i].Item2 <= intervals[j].Item2)))
                    {
                        intervals[i].Item1 = intervals[i].Item2 = 0;
                    }

                }
            }
            return intervals;
        }
        #endregion
    }
}