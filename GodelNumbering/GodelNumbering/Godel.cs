using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Numerics;

namespace GodelNumbering {
    public static class Godel {
        //####################################################  
        // GODEL CALCULATIONS: CONVERT TO
        //####################################################

        /// <summary>
        /// Converts a list of unicode chars into a godel number
        /// </summary>
        public static BigInteger CodesListToGodel(List<int> codes) {
            object[,] parameters = CodesToParameters(codes);
            BigInteger godel = ParametersToGodel(parameters);
            return godel;
        }

        /// <summary>
        /// Turn a list of unicode chars into an array of [unicode chars , list of parameters] 
        /// </summary>
        private static object[,] CodesToParameters(List<int> codes) {
            object[,] parameters  = new object[2, codes.Count];

            int position = 1;
            foreach (int code in codes) {
                parameters[0, position - 1] = code;
                parameters[1, position - 1] = CodeToParameters(position, code);
                position++;
            }

            return parameters;
        }

        /// <summary>
        /// Calculate a list of parameters for a single unicode char
        /// </summary>
        private static List<int> CodeToParameters(int position, int code) {
            List<int> parameters = new List<int>();

            for (int i = 0; i < code; i++) {
                parameters.Add((4 * (position - 1)) + 1);
            }

            return parameters;
        }

        /// <summary>
        /// Turn an array of [unicode chars , list of parameters] into a godel number
        /// </summary>
        private static BigInteger ParametersToGodel(object[,] parameters) {
            int param_number = 0;
            int param_sum = 0;
            BigInteger Godel = 0;
            int codes_count = parameters.GetLength(1);

            for (int i = 0; i < codes_count; i++) {
                List<int> code_params = (List<int>) parameters[1, i];
                
                foreach (int p in code_params) {
                    param_sum += p;
                    BigInteger addGodel = GodelCalculaton(param_number, param_sum);
                    Godel = checked(Godel + addGodel);
                    param_number += 1;
                }
            }
            
            return Godel - 1;
        }

        /// <summary>
        /// Used as a nested function when calculating a godel number
        /// </summary>
        private static BigInteger GodelCalculaton(int iterator, int param_sum_so_far) {
            int exponent = (param_sum_so_far + iterator);
            BigInteger result = checked(BigInteger.Pow(2, exponent));
            return result;
        }

        //####################################################  
        // GODEL CALCULATIONS: CONVERT FROM
        //####################################################

        /// <summary>
        /// Decode a Godel Number to its original string
        /// </summary>
        public static List<int> GodelToCodesList(BigInteger godel) {
            godel++;

            List<int> bits = IntToBitsList(godel);
            List<int> true_positions = BitsListToTruePositions(bits);
            List<int> powers = TruePositionsToPowersList(true_positions);
            List<int> code_positions = PowersListToCodePositions(powers);
            List<int> codes = CodePositionsToCharCodes(code_positions);
            return codes;
        }

        /// <summary>
        /// Convert a number to a list of bits
        /// </summary>
        private static List<int> IntToBitsList(BigInteger godel) {
            List<int> bits = new List<int>();
            
            byte[] bytes = godel.ToByteArray();
            BitArray bit_array = new BitArray(bytes);
            foreach (bool b in bit_array) {
                bits.Add(b ? 1 : 0);                
            }
            
            return bits;
        }

        /// <summary>
        /// Create a list of the positions of True Bits in a list
        /// </summary>
        private static List<int> BitsListToTruePositions(List<int> bits) {
            List<int> true_positions = new List<int>();

            int position = 0;
            foreach(int bit in bits) {
                if (bit == 1) true_positions.Add(position);
                position++;
            }

            return true_positions;
        }

        /// <summary>
        /// Create a list of the power difference between each true bit relative to the previous
        /// </summary>
        private static List<int> TruePositionsToPowersList(List<int> true_positions) {
            List<int> powers = new List<int>();

            int last_position = 0;
            foreach (int position in true_positions) {
                powers.Add(position - last_position);
                last_position = position + 1;
            }

            return powers;
        }

        /// <summary>
        /// Convert the powers list, to a list of absolute positions in the output 'string' which each value contributes to
        /// </summary>
        private static List<int> PowersListToCodePositions(List<int> powers) {
            List<int> code_positions = new List<int>();

            foreach (int power in powers) {
                code_positions.Add(((power - 1) / 4) + 1);
            }

            return code_positions;
        }

        /// <summary>
        /// Count how many values there are for each absolute position in the output 'string'
        /// The result of this count is the original numeric code
        /// </summary>
        private static List<int> CodePositionsToCharCodes(List<int> code_positions) {
            SortedDictionary<int, int> code_values = new SortedDictionary<int, int>();
            
            foreach (int position in code_positions) {
                if (code_values.ContainsKey(position)) {
                    code_values[position] += 1;
                } else {
                    code_values.Add(position, 1);
                }
            }

            return code_values.Values.ToList<int>();
        }
    }
}