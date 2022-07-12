namespace LeetCode_8_StringToInteger
{
    public class Class1
    {
        public int MyAtoi(string s)
        {
            /*
            The algorithm for myAtoi(string s) is as follows:
            - Read in and ignore any leading whitespace.
            - Check if the next character(if not already at the end of the string) is '-' or '+'.Read this character in if it is either.This determines if the final result is negative or positive respectively. Assume the result is positive if neither is present.
            - Read in next the characters until the next non - digit character or the end of the input is reached.The rest of the string is ignored.
            - Convert these digits into an integer(i.e. "123"-> 123, "0032"-> 32). If no digits were read, then the integer is 0.Change the sign as necessary (from step 2).
            - If the integer is out of the 32 - bit signed integer range[-231, 231 - 1], then clamp the integer so that it remains in the range. Specifically, integers less than - 231 should be clamped to -231, and integers greater than 231 - 1 should be clamped to 231 - 1.
            - Return the integer as the final result.
            */

            // Get rid of any leading whitespace
            s = s.TrimStart();

            // Check for any '-' or '+' sign
            bool isNegative = false;
            if ((s.Length >= 1) && ((s[0] == '-') || (s[0] == '+')))
            {
                if (s[0] == '-')
                {
                    isNegative = true;
                }

                // Remove the leading sign
                s = s.Substring(1);
            }

            // Read the remaining characters one by one until there are no numeric digits left
            string numPartString = string.Empty;
            bool endOfDigitsReached = false;
            for (int i = 0; i < s.Length && !endOfDigitsReached; i++)
            {
                switch (s[i])
                {
                    case '0':
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                    case '9':
                        // Collect all the numeric digits
                        numPartString += s[i];
                        break;
                    default:
                        endOfDigitsReached = true;
                        break;
                }
            }

            // If any digits were found, convert the digits into a 32-bit signed integer.
            // But first, to make sure we don't overflow, convert to Int64.
            Int64 convertedNum = 0;
            if (numPartString.Length > 10)
            {
                // To make sure we don't also exceed the Int64 size, cap our search at 10 digits
                if (isNegative)
                {
                    convertedNum = Int32.MinValue;
                }
                else
                {
                    convertedNum = Int32.MaxValue;
                }
            }
            else if (numPartString.Length > 0)
            {
                convertedNum = Convert.ToInt64(numPartString);

                // Reapply the negative sign, if appropriate
                if (isNegative)
                {
                    convertedNum *= -1;
                }

            }
            else
            {
                convertedNum = 0;
            }

            // Now check to see if we're out of the 32-bit int range
            if (convertedNum > Int32.MaxValue)
            {
                convertedNum = Int32.MaxValue;
            }
            else if (convertedNum < Int32.MinValue)
            {
                convertedNum = Int32.MinValue;
            }

            // Return the converted number as a 32-bit int
            return (Int32)convertedNum;
        }

    }
}