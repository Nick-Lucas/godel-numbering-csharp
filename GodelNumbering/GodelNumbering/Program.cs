using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace GodelNumbering {
    class Program {
        static void Main(string[] args) {
            // Construct some data to work on
            string input = "Mary had a little lamb, its fleece was white as snow";
            List<int> uni_chars = Godel_Helpers.StringToUnicodeList(input);

            // to godel
            Console.WriteLine("Encoding as Unicode: " + Godel_Helpers.UnicodeListToString(uni_chars).ToString());
            BigInteger godel = Godel.CodesListToGodel(uni_chars);
            Console.WriteLine("Godel Number Generated");

            // back from godel
            List<int> chars = Godel.GodelToCodesList(godel);
            string text = Godel_Helpers.UnicodeListToString(chars);
            Console.WriteLine("Decoded to Unicode: " + text);

            // Some stats
            Console.WriteLine("\n... and now some stats!");
            Console.WriteLine("Godel Digits: " + godel.ToString().Length + " || 000,000 points: " + (godel.ToString().Length / 3).ToString());

            Single input_bytes = (Single)Math.Round((Single)UnicodeEncoding.UTF8.GetByteCount(input) / 1024, 2);
            Single godel_bytes = (Single)checked(Math.Round((Single)godel.ToByteArray().Count() / 1024, 2));
            Single ratio = (Single)Math.Round((godel_bytes / input_bytes), 0);
            Console.WriteLine(input_bytes + "KB -> " + godel_bytes + "KB");
            Console.WriteLine("That's a 1:" + ratio + " compression ratio!");

            Console.Read();
        }
    }
}

