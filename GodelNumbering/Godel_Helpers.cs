using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GodelNumbering {
    public static class Godel_Helpers {
        /// <summary>
        /// Convert a string to a list of Unicode int chars
        /// </summary>
        public static List<int> StringToUnicodeList(String input) {
            Char[] input_arr = input.ToCharArray();
            int chars = input_arr.Count();

            List<int> uni_chars = new List<int>();
            for (int i = 0; i < chars; i++) {
                uni_chars.Add((int)input_arr[i]);
            }

            return uni_chars;
        }

        /// <summary>
        /// Convert a list of Unicode int chars to a string
        /// </summary>
        public static string UnicodeListToString(List<int> uni_chars) {
            string output = "";

            foreach (int i in uni_chars) {
                output += Convert.ToChar(i);
            }

            return output;
        }

    }
}
