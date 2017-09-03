using System;

namespace Leetcodes.Problems
{
    public class ReverseInteger
    {
        /*Source: https://leetcode.com/problems/reverse-integer/description/
         * 
         * Description: Reverse digits of an integer.
            Example1: x = 123, return 321
            Example2: x = -123, return -321
            Note:
            The input is assumed to be a 32-bit signed integer. Your function should return 0 when the reversed integer overflows.
         */

        //recommended
        //compare with longer-bit data
        public static int Reverse(int num)
        {
            //save the reversed result with 64-bit in case of discarding the higher bits when overflow happens. 
            //Then campare the result with the max or min value to figure out whether the operation overflows.
            long result = 0;
            while (num != 0)
            {
                result = result * 10 + num % 10;
                if (result > int.MaxValue || result < int.MinValue)
                    return 0;
                num /= 10;
            }
            return (int)result;
        }
        [Obsolete]
        public static int Reverse_unit(int num)
        {
            // this method does not work.
            //NOT THE DOMAIN, BUT THE LENGTH OF BITS MATTERS!
            uint uresult = 0;
            bool isNegative = false;
            if (num < 0)
            {
                num *= -1;
                isNegative = true;
            }
            uint udata = (uint)(num);
            while (udata != 0)
            {
                uresult = uresult * 10 + udata % 10;
                if (uresult > int.MaxValue)
                    return 0;
                udata /= 10;
                Console.WriteLine("RESULT: " + uresult);
            }
            int result = (int)uresult;
            if (isNegative)
                return -1 * result;
            return result;
        }
        //overflow with Exception in checked context
        public static int Reverse_checked(int num)
        {
            try
            {
                int result = 0;
                while (num != 0)
                {
                    result = checked(result * 10 + num % 10);
                    num /= 10;
                }
                return result;
            }
            catch
            {
                return 0;
            }
        }


        //set what happens when add some number with the max value
        public static void TestAddition()
        {
            //-2147483648 ~ 2147483647
            Console.WriteLine("Range of signed 32-bit integer: {0} ~ {1}", int.MinValue, int.MaxValue);

            // ref: https://msdn.microsoft.com/en-us/library/system.overflowexception(v=vs.110).aspx
            //If the operation occurs in an unchecked context, the result is truncated by discarding any high-order bits that do not fit into the destination type.
            int max_value = int.MaxValue;
            int max_plus_1 = max_value + 1;  //-2147483648
            Console.WriteLine("Max + 1:" + max_plus_1);

            int min_value = int.MinValue;
            int min_minum_1 = min_value - 1;    //2147483647
            Console.WriteLine("Min - 1:" + min_minum_1);

            try
            {
                // OverflowException must occur in a checked context. By default, arithmetic operations and overflows in C# are not checked.
                int max_plus_checked_mode = checked(max_value + 1); //Arithmetic operation resulted in an overflow.
                Console.WriteLine("checked max + 1:" + max_plus_checked_mode);
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
