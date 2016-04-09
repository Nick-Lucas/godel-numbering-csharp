using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace GodelNumbering {
    class Program {
        static void Main(string[] args) {
            // Construct some data to work on
            if (args.Count() == 0) {
                Console.WriteLine("Please pass in the string that you want to encode");
                Console.ReadKey();
                return;
            }
            string input = args[0];

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
            Console.WriteLine("Godel Digits: " + godel.ToString().Length.ToString());

            Single input_bytes = (Single)(Single)UnicodeEncoding.UTF8.GetByteCount(input) / 1024;
            Single godel_bytes = (Single)checked((Single)godel.ToByteArray().Count() / 1024);
            Single ratio = (Single)Math.Round((godel_bytes / input_bytes), 2);
            Console.WriteLine(Math.Round(input_bytes, 3) + "KB -> " + Math.Round(godel_bytes, 3) + "KB");
            Console.WriteLine("That's a 1:" + ratio + " compression ratio!");

            Console.Read();
        }
    }
}

