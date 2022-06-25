namespace Kata.Domain
{
    public class Katas
    {
        #region ToCamelCase
        public static string ToCamelCase(string str)
        {
            var result = str;
            if (result.Contains("_") || result.Contains("-"))
                result = ArrayToUpperCase(result.Split('_','-'));
            return result;
        }
        private static string ArrayToUpperCase(string[] arrStr)
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
        public static bool Narcissistic(int value)
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
    }
}