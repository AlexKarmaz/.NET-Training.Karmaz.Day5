using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    /// <summary>
    /// Contains methods for calculating greatest common divisor by Euclidean algorithm
    /// </summary>
    public static class GCDAlgorithms
    {
        #region Public Methods

        #region Euclidean
        /// <summary>
        /// Calculate the greatest common divisor by Euclidean algorithm and algorithm execution time
        /// </summary>
        /// <param name="a">The first number</param>
        /// <param name="b">The second number</param>
        /// <param name="time">The algorithm execution time</param>
        /// <returns>The greatest common divisor</returns>
        public static long Euclidean(long a, long b, out long time) => CalculateEuclid(a, b,out time);

        /// <summary>
        /// Calculate the greatest common divisor by Euclidean algorithm
        /// </summary>
        /// <param name="a">The first number</param>
        /// <param name="b">The second number</param>
        /// <returns>The greatest common divisor</returns>
        public static long Euclidean(long a, long b) => CalculateEuclid(a, b);

        /// <summary>
        /// Calculate the greatest common divisor by Euclidean algorithm and algorithm execution time
        /// </summary>
        /// <param name="time">The algorithm execution time</param>
        /// <param name="array">Array of parameters for calculating the greatest common divisor</param>
        /// <returns>The greatest common divisor</returns>
        public static long Euclidean(out long time, params long[] array) => CalculateEuclid(out time, array);

        /// <summary>
        /// Calculate the greatest common divisor by Euclidean algorithm
        /// </summary>
        /// <param name="array">Array of parameters for calculating the greatest common divisor</param>
        /// <returns>The greatest common divisor</returns>
        public static long Euclidean( params long[] array) => CalculateEuclid(array);
        #endregion

        #region Stein
        /// <summary>
        /// Calculate the greatest common divisor by Stein algorithm
        /// </summary>
        /// <param name="a">The first number</param>
        /// <param name="b">The second number</param>
        /// <returns>The greatest common divisor</returns>
        public static long Stein(long a, long b) => CalculateStein(a, b);

        /// <summary>
        /// Calculate the greatest common divisor by Stein algorithm and algorithm execution time
        /// </summary>
        /// <param name="a">The first number</param>
        /// <param name="b">The second number</param>
        /// <param name="time">The algorithm execution time</param>
        /// <returns>The greatest common divisor</returns>
        public static long Stein(long a, long b, out long time) => CalculateStein(a, b, out time);

        /// <summary>
        /// Calculate the greatest common divisor by Stein algorithm
        /// </summary>
        /// <param name="array">Array of parameters for calculating the greatest common divisor</param>
        /// <returns>The greatest common divisor</returns>
        public static long Stein(params long[] array) => CalculateStein(array);

        /// <summary>
        /// Calculate the greatest common divisor by Stein algorithm and algorithm execution time
        /// </summary>
        /// <param name="time">The algorithm execution time</param>
        /// <param name="array">Array of parameters for calculating the greatest common divisor</param>
        /// <returns>The greatest common divisor</returns>
        public static long Stein(out long time, params long[] array) => CalculateStein(out time, array);
        #endregion

        #endregion

        #region Private Methods

        #region Euclidean
        private static long CalculateEuclid(long a, long b, out long time)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            if (a < 0)
            {
                a *= -1;
            }

            if (b < 0)
            {
                b *= -1;
            }

            if (a == b)
            {
                timer.Stop();
                time = timer.ElapsedTicks;
                return b;
            }

            if (a == 0)
            {
                timer.Stop();
                time = timer.ElapsedTicks;
                return b;
            }
            else if(b == 0)
            {
                timer.Stop();
                time = timer.ElapsedTicks;
                return a;
            }

            long result;

            if (a < b)
            {
                result = EuclideanAlgorithm(b, a);
            }
            else
            {
                result = EuclideanAlgorithm(a, b);
            }
             
            timer.Stop();
            time = timer.ElapsedTicks;
            return result;
        }

        private static long CalculateEuclid(long a, long b)
        {
            if (a < 0)
            {
                a *= -1;
            }

            if (b < 0)
            {
                b *= -1;
            }

            if (a == b)
            {
                return b;
            }

            if (a == 0)
            {
                return b;
            }
            else if (b == 0)
            {
                return a;
            }

            long result;

            if (a < b)
            {
                result = EuclideanAlgorithm(b, a);
            }
            else
            {
                result = EuclideanAlgorithm(a, b);
            }
          
            return result;
        }

        private static long CalculateEuclid(out long time, long[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            long result = 0;
            time = 0;

            foreach (long element in array)
            {
                long t;
                result = CalculateEuclid(result, element, out t);
                time += t;
            }
            return result;
        }

        private static long CalculateEuclid(long[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            long result = 0;


            foreach (long element in array)
            {
                result = CalculateEuclid(result, element);
            }
            return result;
        }

        private static long EuclideanAlgorithm(long a, long b)
        {
            long temp;
            while (b != 0)
            {
                temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
        #endregion

        #region Stein
        private static long CalculateStein(long a, long b)
        {
            if (a < 0)
            {
                a *= -1;
            }

            if (b < 0)
            {
                b *= -1;
            }

            if (a == b)
            {
                return b;
            }

            if (a == 0)
            {
                return b;
            }
            else if (b == 0)
            {
                return a;
            }

            return SteinAlgorithm(a, b);
        }

        private static long CalculateStein(long a, long b,  out long time)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            if (a < 0)
            {
                a *= -1;
            }

            if (b < 0)
            {
                b *= -1;
            }

            if (a == b)
            {
                timer.Stop();
                time = timer.ElapsedTicks;
                return b;
            }

            if (a == 0)
            {
                timer.Stop();
                time = timer.ElapsedTicks;
                return b;
            }
            else if (b == 0)
            {
                timer.Stop();
                time = timer.ElapsedTicks;
                return a;
            }

            long result = SteinAlgorithm(a, b);

            timer.Stop();
            time = timer.ElapsedTicks;
            return result;
        }

        private static long CalculateStein(out long time, long[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            long result = 0;
            time = 0;

            foreach (long element in array)
            {
                long t;
                result = CalculateStein(result, element, out t);
                time += t;
            }
            return result;
        }

        private static long CalculateStein(long[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            long result = 0;


            foreach (long element in array)
            {
                result = CalculateStein(result, element);
            }
            return result;
        }

        private static long SteinAlgorithm(long a, long b)
        {
            int shift;
            for (shift = 0; ((a | b) & 1) == 0; ++shift)
            {
                a >>= 1;
                b >>= 1;
            }
            while ((a & 1) == 0)
                a >>= 1;
            do
            {
                while ((b & 1) == 0)
                    b >>= 1;
                if (a > b)
                {
                    long t = b;
                    b = a;
                    a = t;
                }
                b = b - a;
            } while (b != 0);
            return a << shift;
        }
        #endregion

        #endregion
    }
}
