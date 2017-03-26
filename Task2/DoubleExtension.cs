using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    ///<summary>
    /// Provides extension method for binary representation of
    /// double-precision floating-point value
    /// </summary>
    public static class DoubleExtension
    {
        /// <summary>
        /// Returns the binary representation of the number in string format.
        /// </summary>
        /// <param name="number">Source double-precision floating-point value</param>
        /// <returns>The string with binary representation</returns>
        public static string DoubleToBinary(this double number)
        {
            var bits = BitConverter.DoubleToInt64Bits(number);

            var sign = (bits >> 63) & 1;

            var exponent = (bits >> 52) & (long)Math.Pow(2, 11) - 1;

            var mantissa = (bits & (long)Math.Pow(2, 52) - 1);

            return $"{Convert.ToString(sign, 2)}{Convert.ToString(exponent, 2).PadLeft(11, '0')}{Convert.ToString(mantissa, 2).PadLeft(52, '0')}";
        }
    }
}
